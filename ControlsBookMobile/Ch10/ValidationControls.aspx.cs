// Title: Building ASP.NET Server Controls
//
// Chapter: 10 - Mobile Controls
// File: ValidationControls.aspx.cs
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

namespace ControlsBookMobile.Ch10
{
   public class ValidationControls : System.Web.UI.MobileControls.MobilePage
   {
      protected System.Web.UI.MobileControls.Form InputForm;
      protected System.Web.UI.MobileControls.RequiredFieldValidator RequiredFieldValidator1;
      protected System.Web.UI.MobileControls.RangeValidator RangeValidator1;
      protected System.Web.UI.MobileControls.Form ErrorForm;
      protected System.Web.UI.MobileControls.Label Label1;
      protected System.Web.UI.MobileControls.ValidationSummary ValidationSummary1;
      protected System.Web.UI.MobileControls.TextBox NumberTextBox;
      protected System.Web.UI.MobileControls.Form SuccessForm;
      protected System.Web.UI.MobileControls.Label ResultNumber;
      protected System.Web.UI.MobileControls.Command Command1;


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
         this.SuccessForm.Activate += new System.EventHandler(this.SuccessForm_Activate);
         this.Command1.Click += new System.EventHandler(this.Command1_Click);

      }
      #endregion

      private void Command1_Click(object sender, System.EventArgs e)
      {
         if (Page.IsValid)
            this.ActiveForm = SuccessForm;
         else
            this.ActiveForm = ErrorForm;
      }

      private void SuccessForm_Activate(object sender, System.EventArgs e)
      {
         ResultNumber.Text = NumberTextBox.Text;
      }
   }
}