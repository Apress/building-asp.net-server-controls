// Title: Building ASP.NET Server Controls
//
// Chapter: 10 - Mobile Controls
// File: ListControls.aspx.cs
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
   public class ListControls : System.Web.UI.MobileControls.MobilePage
   {
      protected System.Web.UI.MobileControls.Form ListForm;
      protected System.Web.UI.MobileControls.Form SelectionListForm;
      protected System.Web.UI.MobileControls.SelectionList SelectionList1;
      protected System.Web.UI.MobileControls.Form ObjectListForm;
      protected System.Web.UI.MobileControls.ObjectList ObjectList1;
      protected System.Web.UI.MobileControls.Form MainForm;
      protected System.Web.UI.MobileControls.Label ListResult;
      protected System.Web.UI.MobileControls.Command SelListCmd;
      protected System.Web.UI.MobileControls.Label SelectionListResults;
      protected System.Web.UI.MobileControls.Link Link1;
      protected System.Web.UI.MobileControls.Link Link2;
      protected System.Web.UI.MobileControls.Link Link3;
      protected System.Web.UI.MobileControls.Link Link4;
      protected System.Web.UI.MobileControls.Link Link5;
      protected System.Web.UI.MobileControls.Link Link6;
      protected System.Web.UI.MobileControls.List List1;

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
         this.List1.ItemCommand += new System.Web.UI.MobileControls.ListCommandEventHandler(this.List1_ItemCommand);
         this.ListForm.Activate += new System.EventHandler(this.Form1_Activate);
         this.SelListCmd.Click += new System.EventHandler(this.SelListCmd_Click);
         this.SelectionListForm.Activate += new System.EventHandler(this.SelectionListForm_Activate);
         this.ObjectListForm.Activate += new System.EventHandler(this.ObjectListForm_Activate);

      }
      #endregion


      private DataSet GetCustomersData()
      {
         return ControlsBookMobile.Ch10.CustDB.GetCustomersByName("[AB]","10");
      }

      private void Form1_Activate(object sender, System.EventArgs e)
      {
         DataSet ds = GetCustomersData();
         List1.DataSource = ds;
         List1.DataMember = "Customers";
         List1.DataTextField = "ContactName";
         List1.DataBind();
      }

      private void SelectionListForm_Activate(object sender, System.EventArgs e)
      {
         DataSet ds = GetCustomersData();
         SelectionList1.DataSource = ds;
         SelectionList1.DataMember = "Customers";
         SelectionList1.DataTextField = "ContactName";
         SelectionList1.DataBind();
      }

      private void ObjectListForm_Activate(object sender, System.EventArgs e)
      {
         DataSet ds = GetCustomersData();
         ObjectList1.DataSource = ds;
         ObjectList1.DataMember = "Customers";
         ObjectList1.DataBind();
      }

      private void List1_ItemCommand(object sender, System.Web.UI.MobileControls.ListCommandEventArgs e)
      {
         ListResult.Text = "Selected name:" + e.ListItem.Text;
      }

      private void SelListCmd_Click(object sender, System.EventArgs e)
      {
         string results = "";
         foreach (MobileListItem item in SelectionList1.Items)
         {
            if (item.Selected)
            {
               if (results.Length == 0)
                  results += " " + item.Text;
               else
                  results += ", " + item.Text;
            }
         }
         SelectionListResults.Text = "Selected names:" + results;
      }
   }
}
