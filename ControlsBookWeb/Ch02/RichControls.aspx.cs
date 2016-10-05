// Title: Building ASP.NET Server Controls
//
// Chapter: 2 - Server Control Basics
// File: RichControls.aspx.cs
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

namespace ControlsBookWeb.Ch02
{
   public class RichControls : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Label Label1;
      protected System.Web.UI.WebControls.Calendar Calendar1;
      protected ControlsBookWeb.ControlsBookHeader Header ;

      private void Page_Load(object sender, System.EventArgs e)
      {
         Header.ChapterNumber = 2 ;
         Header.ChapterTitle = "Server Control Basics" ;
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
         this.Calendar1.SelectionChanged += new System.EventHandler(this.Date_Selected);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Date_Selected(object sender, System.EventArgs e)
      {
         Label1.Text = "Selected: " + Calendar1.SelectedDate.ToLongDateString();
      }
   }
}
