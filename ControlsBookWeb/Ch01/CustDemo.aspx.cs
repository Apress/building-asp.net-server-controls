// Title: Building ASP.NET Server Controls
//
// Chapter: 1 - User Interface Reuse
// File: CustDemo.aspx.cs
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

namespace ControlsBookWeb.Ch01
{
   public class CustDemo : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.DataGrid DataGrid1;
      protected System.Web.UI.WebControls.Button QueryButton;
      protected System.Web.UI.WebControls.TextBox CustName;

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
         this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private SqlDataReader GetCustomersReader(string name)
      {
         SqlConnection conn =
            new SqlConnection("Server=(local);Database=Northwind;Integrated Security=true;");
         conn.Open();

         SqlCommand cmd =
            new SqlCommand("SELECT ContactName, CompanyName FROM Customers WHERE ContactName LIKE '%" + name.Trim() + "%'",
            conn);

         SqlDataReader rdr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);

         return rdr;
      }

      private void QueryButton_Click(object sender, System.EventArgs e)
      {
         DataGrid1.DataSource = GetCustomersReader(CustName.Text);
         DataGrid1.DataBind();
      }
   }
}
