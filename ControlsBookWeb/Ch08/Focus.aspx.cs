// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: Focus.aspx.cs
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
using System.Data.SqlClient;

namespace ControlsBookWeb.Ch08
{
   public class Focus : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.DropDownList DropDownList1;
      protected ControlsBookLib.Ch08.Focus focus1;
      protected System.Web.UI.WebControls.Label TopLabel;
      protected System.Web.UI.WebControls.Label BottomLabel;
      protected System.Web.UI.WebControls.DropDownList DropDownlist2;
      protected System.Web.UI.WebControls.DropDownList DropDownList2;
      protected System.Web.UI.WebControls.DataGrid dataGrid1;
      protected System.Web.UI.WebControls.Button Button1;
      protected ControlsBookWeb.ControlsBookHeader Header ;

      private void Page_Load(object sender, System.EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            dataGrid1.DataSource = GetCustomerData();
            dataGrid1.DataBind();
         }
      }

      private DataSet GetCustomerData()
      {
         SqlConnection conn =
            new SqlConnection("Server=(local);Database=Northwind;Integrated Security=true;");
         conn.Open();

         SqlDataAdapter da =
            new SqlDataAdapter("SELECT CustomerID, ContactName, ContactTitle, CompanyName FROM Customers",
            conn);
         DataSet ds = new DataSet();
         da.Fill(ds,"Customers");

         return ds;
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
         this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
         this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
         this.Load += new System.EventHandler(this.Page_Load);
      }
      #endregion

      private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         focus1.TargetControl = DropDownList1.SelectedItem.Value;
         ResetLists();
      }

      private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         focus1.TargetControl = DropDownList2.SelectedItem.Value;
         ResetLists();
      }

      private void ResetLists()
      {
         DropDownList1.SelectedIndex = 0;
         DropDownList2.SelectedIndex = 1;
      }
   }
}
