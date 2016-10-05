// Title: Building ASP.NET Server Controls
//
// Chapter: 9 - Validation Controls
// File: PhoneCustomValidator.aspx.cs
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
using System.Text.RegularExpressions;

namespace ControlsBookWeb.Ch09
{

   public class PhoneCustomValidator : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Button Submit;
      protected System.Web.UI.WebControls.TextBox PhoneNumber;
      protected System.Web.UI.WebControls.CustomValidator CustomValidator;
      protected System.Web.UI.WebControls.Label Status;
      protected System.Web.UI.WebControls.TextBox Name;
      protected System.Web.UI.WebControls.RadioButtonList Sex;
      protected System.Web.UI.WebControls.TextBox Comments;
      protected System.Web.UI.WebControls.TextBox Password1;
      protected System.Web.UI.WebControls.TextBox Password2;
      protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
      protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
      protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
      protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
      protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
      protected System.Web.UI.WebControls.DropDownList Job;
      protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
      protected System.Web.UI.WebControls.RequiredFieldValidator NameReqValidator;
      protected System.Web.UI.WebControls.RequiredFieldValidator SexReqValidator;
      protected System.Web.UI.WebControls.RequiredFieldValidator AgeReqValidator;
      protected System.Web.UI.WebControls.RangeValidator AgeRangeValidator;
      protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
      protected System.Web.UI.WebControls.TextBox Age;
      protected System.Web.UI.WebControls.Button NoValidationSubmit;
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
         this.NoValidationSubmit.Click += new System.EventHandler(this.NoValidationSubmit_Click);
         this.Submit.Click += new System.EventHandler(this.Submit_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void ServerPhoneValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
      {
         Regex expr = new Regex(@"^\(?\d{3}\)?(\s|-)\d{3}\-\d{4}$");
         MatchCollection matches = expr.Matches(args.Value, 0);
         args.IsValid = (matches != null && matches[0].Value == args.Value);

      }

      private void Submit_Click(object sender, System.EventArgs e)
      {
         if (Page.IsValid)
            Status.Text = "Valid number: " + PhoneNumber.Text;
      }

      private void NoValidationSubmit_Click(object sender, System.EventArgs e)
      {
         Status.Text = "Submitted without validation!";
      }
   }
}
