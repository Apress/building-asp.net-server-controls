// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: UserControlHost.aspx.cs
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

namespace ControlsBookMobile.Ch11
{
   public class UserControlHost : System.Web.UI.MobileControls.MobilePage
   {
      protected System.Web.UI.MobileControls.Label Label1;
      protected System.Web.UI.MobileControls.List CustList;
      protected System.Web.UI.MobileControls.TextBox NameTextBox;
      protected System.Web.UI.MobileControls.Form QueryForm;
      protected System.Web.UI.MobileControls.Form LabelForm;
      protected System.Web.UI.MobileControls.Label Label3;
      protected System.Web.UI.MobileControls.Label Label4;
      protected System.Web.UI.MobileControls.Form MainForm;
      protected System.Web.UI.MobileControls.Form ResultsForm;
      protected System.Web.UI.MobileControls.Link Link1;
      protected System.Web.UI.MobileControls.Link Link2;
      protected System.Web.UI.MobileControls.Label Label5;
      protected System.Web.UI.MobileControls.Label Label6;
      protected System.Web.UI.MobileControls.Label Label7;
      protected System.Web.UI.MobileControls.StyleSheet InlineStyleSheet;
      protected System.Web.UI.MobileControls.Command QueryCmd;

      private void Page_Load(object sender, System.EventArgs e)
      {
         // Put user code to initialize the page here
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
         this.QueryCmd.Click += new System.EventHandler(this.QueryCmd_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private DataSet GetCustomersByName(String Name)
      {
         return ControlsBookMobile.Ch10.CustDB.GetCustomersByName(Name,"40");
      }

      private void QueryCmd_Click(object sender, System.EventArgs e)
      {
         ActiveForm = ResultsForm;

         CustList.DataSource = GetCustomersByName(NameTextBox.Text);
         CustList.DataMember = "Customers";
         CustList.DataTextField = "ContactName";
         CustList.DataBind();
      }
   }
}
