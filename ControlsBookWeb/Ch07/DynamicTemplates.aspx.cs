// Title: Developing Server Controls with ASP.Net
//
// Chapter: 7 - Templates and Databinding
// File: DynamicTemplates.aspx.cs
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
using ControlsBookLib.Ch07;

namespace ControlsBookWeb.Ch07
{
   public class DynamicTemplates : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.DropDownList templateList;
      protected ControlsBookLib.Ch07.Repeater repeaterRdrCust;

      private void Page_Load(object sender, System.EventArgs e)
      {
         LoadRepeater();
      }

      private void LoadRepeater()
      {
         string templateName = templateList.SelectedItem.Text;
         if (templateName.IndexOf(".ascx") > 0)
         {
            repeaterRdrCust.ItemTemplate = Page.LoadTemplate(templateName);
         }
         else
         {
            repeaterRdrCust.HeaderTemplate = new CustCodeHeaderTemplate();

            repeaterRdrCust.ItemTemplate = new CustCodeItemTemplate(true);

            repeaterRdrCust.AlternatingItemTemplate = new CustCodeItemTemplate(false);

            repeaterRdrCust.FooterTemplate = new CustCodeFooterTemplate();
         }

         SqlDataReader dr = GetCustomerDataReader();
         repeaterRdrCust.DataSource = dr;
         repeaterRdrCust.DataBind();
         dr.Close();
      }

      private SqlDataReader GetCustomerDataReader()
      {
         SqlConnection conn =
            new SqlConnection("Server=(local);Database=Northwind;Integrated Security=true;");
         conn.Open();

         SqlCommand cmd =
            new SqlCommand("SELECT CustomerID, ContactName, ContactTitle, CompanyName FROM Customers WHERE CustomerID LIKE '[AB]%'",
            conn);
         SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

         return dr;
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
