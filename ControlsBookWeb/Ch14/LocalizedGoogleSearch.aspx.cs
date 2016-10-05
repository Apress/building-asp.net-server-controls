// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Packaging and Deploying Controls
// File: LocalizedGoogleSearch.cs
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
using System.Threading;
using System.Globalization;

namespace ControlsBookWeb.Ch13
{
   public class LocalizedGoogleSearch : System.Web.UI.Page
   {
      protected Apress.GoogleControls.Result result;
      protected Apress.GoogleControls.Search Search1;
      protected Apress.GoogleControls.Search Search2;
      protected System.Web.UI.WebControls.DropDownList CultureList;
      protected System.Web.UI.WebControls.Label CultureLabel;
      protected System.Web.UI.WebControls.Label DateTimeLabel;
      protected Apress.GoogleControls.Search search;

      private void Page_Load(object sender, System.EventArgs e)
      {
         CultureLabel.Text = Thread.CurrentThread.CurrentCulture.DisplayName;
         DateTimeLabel.Text = DateTime.Now.ToLongDateString();
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
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion
   }
}