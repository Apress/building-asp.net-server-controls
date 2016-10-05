// Title: Building ASP.NET Server Controls
//
// Chapter: 9 - Validation Controls
// File: PhoneBaseValidator.aspx.cs
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

namespace ControlsBookWeb.Ch09
{
   public class PhoneBaseValidator : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.TextBox PhoneNumber;
      protected System.Web.UI.WebControls.Button Submit;
      protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator;
      protected System.Web.UI.WebControls.Label Status;
      protected System.Web.UI.WebControls.TextBox IntlPhoneNumber;
      protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
      protected System.Web.UI.WebControls.TextBox USPhoneNumber;
      protected ControlsBookLib.Ch09.PhoneValidator PhoneValidatorUS;
      protected ControlsBookLib.Ch09.PhoneValidator PhonevalidatorIntl;
      protected System.Web.UI.WebControls.ValidationSummary Summary;

      private void Page_Load(object sender, System.EventArgs e)
      {
         Status.Text = "";
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
         this.Submit.Click += new System.EventHandler(this.Submit_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Submit_Click(object sender, System.EventArgs e)
      {
         if (Page.IsValid)
            Status.Text = "Valid numbers US: " + USPhoneNumber.Text +
               " Intl: " + IntlPhoneNumber.Text;
      }
   }
}
