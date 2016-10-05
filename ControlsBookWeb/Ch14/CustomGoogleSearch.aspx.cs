// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Packaging and Deploying Controls
// File: CustomGoogleSearch.cs
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
using Apress.GoogleControls;

namespace ControlsBookWeb.Ch13
{
   public class CustomGoogleSearch : System.Web.UI.Page
   {
      protected Search search;
      protected Result result;
      private int resultIndex = 0;

      private void Page_Load(object sender, System.EventArgs e)
      {
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
         this.search.GoogleSearched += new Apress.GoogleControls.GoogleSearchedEventHandler(this.search_GoogleSearched);
         this.result.ItemCreated += new Apress.GoogleControls.ResultItemEventHandler(this.result_ItemCreated);
         this.result.GoogleSearched += new Apress.GoogleControls.GoogleSearchedEventHandler(this.result_GoogleSearched);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void result_ItemCreated(object o, Apress.GoogleControls.ResultItemEventArgs rie)
      {
         ResultItem item = rie.Item;

         if (item.ItemType == ResultItemType.Item ||
            item.ItemType == ResultItemType.AlternatingItem)
         {
            item.Controls.AddAt(0, new LiteralControl(resultIndex.ToString() + "."));
            resultIndex++;
         }
      }

      private void search_GoogleSearched(object o, Apress.GoogleControls.GoogleSearchedEventArgs gsea)
      {
         resultIndex = gsea.Result.startIndex;
      }

      private void result_GoogleSearched(object o, Apress.GoogleControls.GoogleSearchedEventArgs gsea)
      {
         resultIndex = gsea.Result.startIndex;
      }
   }
}