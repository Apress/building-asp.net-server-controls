// Title: Building ASP.NET Server Controls
//
// Chapter: 2 - Server Control Basics
// File: ListControls.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ControlsBookWeb.Ch02
{
   public class ListControls : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Button Button1;
      protected System.Web.UI.WebControls.Repeater Repeater1;

      private void Page_Load(object sender, System.EventArgs e)
      {
         Repeater1.DataSource = GetCustomerData();
         Repeater1.DataBind();
      }

      private DataSet GetCustomerData()
      {
         SqlConnection conn =
            new SqlConnection("Server=(local);Database=Northwind;Integrated Security=true;");
         conn.Open();

         SqlDataAdapter da =
            new SqlDataAdapter("SELECT CustomerID, ContactName, ContactTitle, CompanyName FROM Customers WHERE CustomerID LIKE '[AB]%'",
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
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion
   }
}
