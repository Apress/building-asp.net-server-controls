// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: DeviceSpecific.aspx.cs
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
   public class DeviceSpecific : System.Web.UI.MobileControls.MobilePage
   {
      protected System.Web.UI.MobileControls.ObjectList ObjectList1;
      protected System.Web.UI.MobileControls.Form ObjectListForm;
      protected System.Web.UI.MobileControls.Command SelListCmd;
      protected System.Web.UI.MobileControls.TextBox NameTextBox;
      protected System.Web.UI.MobileControls.Label Label1;
      protected System.Web.UI.MobileControls.Form InputForm;
      protected System.Web.UI.MobileControls.Label Label2;
      protected System.Web.UI.MobileControls.Label PrefRendLabel;
      protected System.Web.UI.MobileControls.Label Label3;
      protected System.Web.UI.MobileControls.Label AgentLabel;
      protected System.Web.UI.MobileControls.Label Label5;
      protected System.Web.UI.MobileControls.Label PrefImageLabel;
      protected System.Web.UI.MobileControls.Image Image1;

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
         this.SelListCmd.Click += new System.EventHandler(this.SelListCmd_Click);
         this.InputForm.Activate += new System.EventHandler(this.InputForm_Activate);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private DataSet GetCustomersByName(String Name)
      {
         return ControlsBookMobile.Ch10.CustDB.GetCustomersByName(Name,"40");
      }

      private void SelListCmd_Click(object sender, System.EventArgs e)
      {
         ActiveForm = ObjectListForm;
         DataSet ds = GetCustomersByName(NameTextBox.Text);
         ObjectList1.DataSource = ds;
         ObjectList1.DataMember = "Customers";
         ObjectList1.DataBind();
      }

      private void InputForm_Activate(object sender, System.EventArgs e)
      {
         AgentLabel.Text = HttpContext.Current.Request.Headers["User-Agent"];

         MobileCapabilities caps = (MobileCapabilities)
            HttpContext.Current.Request.Browser;
         if (caps != null) //Cast succeeds
         {
            PrefRendLabel.Text = caps.PreferredRenderingType.ToString();
            PrefImageLabel.Text = caps.PreferredImageMime.ToString();
         }
      }
   }
}
