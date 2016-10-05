// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: TemplateMenu.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;

namespace ControlsBookWeb.Ch07
{
   public class TemplateMenu : System.Web.UI.Page
   {
      protected ControlsBookLib.Ch07.TemplateMenu menu1;

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
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion
   }
}