// Title: Building ASP.NET Server Controls
//
// Chapter: 4 - State Management
// File: ClientState.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ControlsBookWeb.Ch04
{
   public class ClientState : System.Web.UI.Page
   {
      protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenName;
      protected System.Web.UI.WebControls.HyperLink URLEncodeLink;
      protected System.Web.UI.WebControls.Label CookieLabel;
      protected System.Web.UI.WebControls.Label URLLabel;
      protected System.Web.UI.WebControls.Label HiddenLabel;
      protected System.Web.UI.WebControls.Button SetStateButton;
      protected System.Web.UI.WebControls.Button SubmitPageButton;
      protected System.Web.UI.WebControls.TextBox NameTextBox;
      protected System.Web.UI.WebControls.Label ViewStateLabel;

      private void Page_Load(object sender, System.EventArgs e)
      {
         GetClientState();
      }

      #region Web Form Designer generated code
      override protected void OnInit(EventArgs e)
      {
         //
         // CODEGEN: This call is required by the ASP.NET Web Form Designer.
         //
         InitializeComponent();
         base.OnInit(e);
      }

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.SetStateButton.Click += new System.EventHandler(this.SetStateButton_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void SetStateButton_Click(object sender, System.EventArgs e)
      {
         SetClientState();
      }

      private void SetClientState()
      {
         string name = NameTextBox.Text;

         // set the name Cookie value
         Response.Cookies["cookiename"].Value = name;

         // encode the name in the redirect URL
         URLEncodeLink.NavigateUrl = "ClientState.aspx?urlname=" + name;

         // put the name in the hidden variable
         HiddenName.Value = name;

         // put the name in ViewState
         ViewState["viewstatename"] = name;
      }

      private void GetClientState()
      {
         // check the cookiename Cookie
         CookieLabel.Text = "";
         if (Request.Cookies["cookiename"] != null)
            CookieLabel.Text = Request.Cookies["cookiename"].Value;

         // check the URL for urlname variable
         URLLabel.Text = "";
         if (Request.QueryString["urlname"] != null)
            URLLabel.Text = Request.Params["urlname"];

         // check the form data for hiddenname variable
         HiddenLabel.Text = "";
         if (Context.Request.Form["hiddenname"] != null)
            HiddenLabel.Text = Request.Params["hiddenname"];

         // check the Viewstate for the viewstatename variable
         ViewStateLabel.Text = "";
         if (ViewState["viewstatename"] != null)
            ViewStateLabel.Text = ViewState["viewstatename"].ToString();
      }
   }
}
