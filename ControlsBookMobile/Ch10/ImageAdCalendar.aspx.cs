// Title: Building ASP.NET Server Controls
//
// Chapter: 10 - Mobile Controls
// File: ImageAdCalendar.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace ControlsBookMobile.Ch10
{
   public class ImageAddCalendar : System.Web.UI.MobileControls.MobilePage
   {
      protected System.Web.UI.MobileControls.Form MainForm;
      protected System.Web.UI.MobileControls.Link Link1;
      protected System.Web.UI.MobileControls.Form ImageAdForm;
      protected System.Web.UI.MobileControls.Link Link2;
      protected System.Web.UI.MobileControls.Image Image1;
      protected System.Web.UI.MobileControls.AdRotator AdRotator1;
      protected System.Web.UI.MobileControls.Calendar Calendar1;
      protected System.Web.UI.MobileControls.Label CalResult;
      protected System.Web.UI.MobileControls.Label ChoiceLabel;
      protected System.Web.UI.MobileControls.Form CalendarForm;


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
         this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);

      }
      #endregion

      private void Calendar1_SelectionChanged(object sender, System.EventArgs e)
      {
         DateTime date = Calendar1.SelectedDate;
         CalResult.Text = "Selected " + date.ToShortDateString();
      }
   }
}