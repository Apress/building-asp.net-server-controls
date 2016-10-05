// Title: Building ASP.NET Server Controls
//
// Chapter: 10 - Mobile Controls
// File: ContainerControls.aspx.cs
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
   public class ContainerControls : System.Web.UI.MobileControls.MobilePage
   {
      protected System.Web.UI.MobileControls.Form PanelForm;
      protected System.Web.UI.MobileControls.List PanelList;
      protected System.Web.UI.MobileControls.Panel ResultsPanel;
      protected System.Web.UI.MobileControls.Label Label1;
      protected System.Web.UI.MobileControls.TextBox PanelFormTextBox;
      protected System.Web.UI.MobileControls.Command PanelFormCmd;
      protected System.Web.UI.MobileControls.Panel QueryPanel;


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
         this.PanelFormCmd.Click += new System.EventHandler(this.PanelFormCmd_Click);
         this.PanelForm.Activate += new System.EventHandler(this.PanelForm_Activate);

      }
      #endregion

      private DataSet GetCustomersData(string Name)
      {
         return CustDB.GetCustomersByName(Name,"20");
      }

      private void PanelForm_Activate(object sender, System.EventArgs e)
      {
         PanelList.DataSource = GetCustomersData(PanelFormTextBox.Text);
         PanelList.DataMember = "Customers";
         PanelList.DataTextField = "ContactName";
         PanelList.DataBind();
      }

      private void PanelFormCmd_Click(object sender, System.EventArgs e)
      {
         ActiveForm = PanelForm;
         QueryPanel.Visible = false;
         ResultsPanel.Visible = true;
      }
   }
}