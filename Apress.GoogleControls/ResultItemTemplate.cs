// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ResultItemTemplate.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apress.GoogleControls
{
   /// <summary>
   ///		Default ResultItemTemplate implementation used by a 
   ///		stock GoogleLib Result control without a ItemTemplate
   /// </summary>
   public class ResultItemTemplate : ITemplate
   {
      /// <summary>
      /// Method puts template controls into container control
      /// </summary>
      /// <param name="container">Outside control container to template items</param>
      public void InstantiateIn(Control container)
      {
         HyperLink link = new HyperLink();
         link.DataBinding += new EventHandler(BindLink);
         container.Controls.Add(link);
         container.Controls.Add(new LiteralControl("<br>"));

         Label snippet = new Label();
         snippet.DataBinding += new EventHandler(BindSnippet);
         container.Controls.Add(snippet);
         container.Controls.Add(new LiteralControl("<br>"));

         Label url = new Label();
         url.DataBinding += new EventHandler(BindUrl);
         container.Controls.Add(url);
         container.Controls.Add(new LiteralControl("<br>"));
         container.Controls.Add(new LiteralControl("<br>"));
      }

      private Service.ResultElement GetResultElement(Control container)
      {
         ResultItem item = (ResultItem) container;
         return (Service.ResultElement) item.DataItem;
      }

      private void BindLink(object source, EventArgs e)
      {
         HyperLink link = (HyperLink) source;
         Service.ResultElement elem = GetResultElement(link.NamingContainer);
         link.Text = elem.title;
         link.NavigateUrl = elem.URL;
      }

      private void BindSnippet(object source, EventArgs e)
      {
         Label snippet = (Label) source;
         Service.ResultElement elem = GetResultElement(snippet.NamingContainer);
         snippet.Text = elem.snippet;
      }

      private void BindUrl(object source, EventArgs e)
      {
         Label url = (Label) source;
         Service.ResultElement elem = GetResultElement(url.NamingContainer);
         url.Text = elem.URL;
      }
   }
}