// Title: Building ASP.NET Server Controls
//
// Chapter: 3 - Building Server Controls
// File: MenuCustomControlDemo.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright � 2003, Apress L.P.
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

namespace ControlsBookWeb.Ch03
{

   public class MenuCustomControlDemo : System.Web.UI.Page
   {
      protected internal ControlsBookLib.Ch03.MenuCustomControl menu1;
      protected internal ControlsBookWeb.ControlsBookHeader Header ;

      private void Page_Load(object sender, System.EventArgs e)
      {
         Header.ChapterNumber = 3 ;
         Header.ChapterTitle = "Building Server Controls" ;
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
