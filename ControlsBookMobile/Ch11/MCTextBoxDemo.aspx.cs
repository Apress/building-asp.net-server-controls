// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: MCTextBoxDemo.aspx.cs
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
using ControlsBookLib.Ch11;

namespace ControlsBookMobile.Ch11
{
   public class MCTextBox : System.Web.UI.MobileControls.MobilePage
   {
      protected ControlsBookLib.Ch11.MCTextBox MCTextBox1;
      protected System.Web.UI.MobileControls.Command Command1;
      protected System.Web.UI.MobileControls.Label ChangeLabel;
      protected System.Web.UI.MobileControls.Label Label1;
      protected System.Web.UI.MobileControls.TextBox TextBox1;
      protected System.Web.UI.MobileControls.Form Form1;

      private void Page_Load(object sender, System.EventArgs e)
      {
         ChangeLabel.Text = DateTime.Now.ToLongTimeString() + ": MCTextBox No change.";
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
//      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.MCTextBox1.TextChanged += new System.EventHandler(this.MCTextBox1_TextChanged);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void MCTextBox1_TextChanged(object sender, System.EventArgs e)
      {
         ChangeLabel.Text = DateTime.Now.ToLongTimeString() + ": MCTextbox Changed! "+ MCTextBox1.Text ;
      }
   }
}