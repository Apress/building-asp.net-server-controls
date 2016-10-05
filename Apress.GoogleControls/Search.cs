// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: Search.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Reflection;
using System.ComponentModel;
using System.Configuration;
using System.Resources;

namespace Apress.GoogleControls
{
   /// <summary>
   ///		Search control displays input textbox and button to capture input and start search process.
   /// </summary>
   [ParseChildren(true),
   ToolboxData("<{0}:Search runat=server></{0}:Search>"),
   Designer(typeof(SearchDesigner)),
#if LICENSED
   RsaLicenseData(
      "ffb30135-b07c-496b-8663-af996f7bff58",
      
      "<RSAKeyValue><Modulus>tLMxOSJaiyTiEWtCWGuVVW7Q0aV59jDMvEIm4aILR9SlwD6DUG8FdnfbTftvMJZYGoI2XSaIyz5W6/20zjNyzZJdnNKN8V3zqT8BUBnVqrgyVAdA3mtjwdCk4MfpjEryeJAm19spgov4dB5KUJ0iDoKhbFVWZAyeXboHaE9uNWU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
      ),
   LicenseProvider(typeof(RsaLicenseProvider)),
#endif
   DefaultEvent("GoogleSearched")
   ]
   public class Search : WebControl, INamingContainer
   {
      private const string GoogleWebPageUrl = "http://www.google.com";
      private const string GoogleWebSearchUrl = 
         "http://www.google.com/search";
      private const string Google25PtLogoImageUrl = 
         "http://www.google.com/logos/Logo_25wht.gif";
      private const string Google40PtLogoImageUrl = 
         "http://www.google.com/logos/Logo_40wht.gif";
      private const int SearchTextBoxWidth = 200;
      private const bool DefaultFilteringValue = false;
      private const bool DefaultRedirectToGoogleValue = false;
      private bool searchHandled = false;

      private HyperLink googleLinkImage;
      private TextBox searchTextBox;
      private Button searchButton;
      private static readonly object GoogleSearchedKey = new object();

#if LICENSED
      private License license;
      private bool disposed = false;
#endif


      /// <summary>
      /// Default constructor for Search control
      /// </summary>
      public Search()
      {

#if LICENSED

         // initiate license validation
         license =
            LicenseManager.Validate(typeof(Search), this);

#endif

      }

      /// <summary>
      ///   Override bases Search control on div HTML tag
      /// </summary>
      protected override HtmlTextWriterTag TagKey
      {
         get
         {
            return HtmlTextWriterTag.Div;
         }
      }

#if LICENSED

      /// <summary>
      /// Internal resource cleanup routine called by Dispose and Finalize
      /// </summary>
      /// <param name="disposing"></param>
      protected virtual void Dispose(bool disposing)
      {
         if (!disposed)
         {
            // license resource cleanup
            if (license != null)
               license.Dispose();
            license = null;
         }
         disposed = true;
      }

      /// <summary>
      ///   Public method to cleanup licensing resources of control
      /// </summary>
      public override void Dispose()
      {
         // cleanup resources
         Dispose(true);

         // once disposed, no need to finalize
         GC.SuppressFinalize(this);
      }

      /// <summary>
      /// Finalize implementation that calls Dispose cleanup
      /// </summary>
      ~Search()
      {
         // cleanup resources
         Dispose(false);
      }

#endif

      /// <summary>
      ///		GoogleControls Result control to bind search results to for display
      /// </summary>
      [DescriptionAttribute("Result control to bind search results to for display."),
      CategoryAttribute("Search")]
      virtual public string ResultControl
      {
         get
         {
            object control = ViewState["ResultControl"];
            if (control == null)
               return "";
            else
               return (string) control;
         }
         set
         {
            ViewState["ResultControl"] = value;
         }
      }

      /// <summary>
      ///		Search query string
      /// </summary>
      [DescriptionAttribute("Search query string."),
      CategoryAttribute("Search")]
      virtual public string Query
      {
         get
         {
            EnsureChildControls();
            return searchTextBox.Text;
         }
         set
         {
            EnsureChildControls();
            searchTextBox.Text = value;
         }
      }


      /// <summary>
      ///		Redirect search query to Google site web pages.
      /// </summary>
      [DescriptionAttribute("Redirect search query to Google site web pages."),
      CategoryAttribute("Search")]
      virtual public bool RedirectToGoogle
      {
         get
         {
            object redirect = ViewState["RedirectToGoogle"];
            if (redirect == null)
               return DefaultRedirectToGoogleValue;
            else
               return (bool) redirect;
         }
         set
         {
            ViewState["RedirectToGoogle"] = value;
         }
      }

      /// <summary>
      /// Click event handler for search button
      /// </summary>
      /// <param name="s">Search button</param>
      /// <param name="e">Event arguments</param>
      protected void SearchButtonClick(object s, EventArgs e)
      {
         HandleSearch();
      }

      /// <summary>
      /// TextChanged event handler for query textbox
      /// </summary>
      /// <param name="s">Query textbox </param>
      /// <param name="e">Event arguments</param>
      protected void SearchTextBoxTextChanged(object s, EventArgs e)
      {
         HandleSearch();
      }

      private void HandleSearch()
      {
         // check to see if search was handled on this postback
         // (this prevents TextChanged and ButtonClicked from
         // double-tapping Google web service for the same query)
         if (searchHandled == true)
            return;

         // check for redirect of query processing to Google web site
         if (RedirectToGoogle == true)
         {
            this.Page.Response.Redirect(
               GoogleWebSearchUrl + "?q=" +
               HttpContext.Current.Server.UrlEncode(Query), true);
         }

         if (ResultControl.Length != 0)
         {
            // lookup the Result control we are linked to
            // and get the PageSize and Filtering property values
            Result resControl = (Result) Page.FindControl(ResultControl);
            int pageSize = resControl.PageSize;
            bool filtering = resControl.Filtering;

            // get search results from Google web service proxy
            Service.GoogleSearchResult result =
               Service.SearchUtil.SearchGoogleService(
               Query,0,pageSize,filtering);

            // raise search results for any interested parties as well
            OnGoogleSearched(new GoogleSearchedEventArgs(result));

            // databind search results with the Result control
            // we are linked with
            resControl.DataSource = result;
            resControl.DataBind();

         }


         // set bool that tells us the search has been handled on this
         // postback
         searchHandled = true;
      }

      /// <summary>
      /// GoogleSearched event occurs when a Search control conducts a search
      /// with google and wants to notify interested parties about the search results
      /// </summary>
      public event GoogleSearchedEventHandler GoogleSearched
      {
         add
         {
            Events.AddHandler(GoogleSearchedKey, value);
         }
         remove
         {
            Events.RemoveHandler(GoogleSearchedKey, value);
         }
      }

      /// <summary>
      ///   Protected method for invoking GoogleSearched event from within Result control
      /// </summary>
      /// <param name="e">Event arguments including search results</param>
      protected virtual void OnGoogleSearched(GoogleSearchedEventArgs e)
      {
         GoogleSearchedEventHandler del =
            (GoogleSearchedEventHandler) Events[GoogleSearchedKey];
         if (del != null)
         {
            del(this, e);
         }

      }

      /// <summary>
      /// Called by framework for composite controls to create control heirarchy
      /// </summary>
      protected override void CreateChildControls()
      {
         googleLinkImage = new HyperLink();
         googleLinkImage.ImageUrl = Google40PtLogoImageUrl;
         googleLinkImage.NavigateUrl = GoogleWebPageUrl;
         this.Controls.Add(googleLinkImage);

         LiteralControl br = new LiteralControl("<br>");
         this.Controls.Add(br);

         searchTextBox = new TextBox();
         searchTextBox.Width = SearchTextBoxWidth;
         searchTextBox.TextChanged +=new 
            EventHandler(SearchTextBoxTextChanged);
         this.Controls.Add(searchTextBox);

         br = new LiteralControl("&nbsp;");
         this.Controls.Add(br);

         // search button Text is localized
         ResourceManager rm = ResourceFactory.Manager;
         searchButton = new Button();
         searchButton.Text = rm.GetString("Search.searchButton.Text");
         searchButton.Click += new EventHandler(SearchButtonClick);
         this.Controls.Add(searchButton);

         br = new LiteralControl("<br>");
         this.Controls.Add(br);

      }

      /// <summary>
      /// Overridden to ensure Controls collection is created before external access
      /// </summary>
      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }
   }
}