// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: DataboundRepeater.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ControlsBookWeb.Ch07
{
   public class DataboundRepeater : System.Web.UI.Page
   {
      protected ControlsBookLib.Ch07.Repeater RepeaterDesignTime;
      protected System.Data.SqlClient.SqlDataAdapter dataAdapterEmp;
      protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
      protected System.Data.SqlClient.SqlConnection connEmp;
      protected ControlsBookWeb.Ch07.dataSetEmp dataSetEmp;
      protected ControlsBookLib.Ch07.Repeater repeaterA;
      protected ControlsBookLib.Ch07.Repeater repeaterAl;
      protected ControlsBookLib.Ch07.Repeater repeaterDtEmp;
      protected ControlsBookLib.Ch07.Repeater repeaterRdrCust;
      protected System.Web.UI.WebControls.Button Button1;

      private void Page_Load(object sender, System.EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            string[] array = new String[] { "one", "two", "three" };
            repeaterA.DataSource = array;
            repeaterA.DataBind();

            ArrayList list = new ArrayList();
            list.Add("four");
            list.Add("five");
            list.Add("six");
            repeaterAl.DataSource = list;
            repeaterAl.DataBind();

            SqlDataReader dr = GetCustomerDataReader();
            repeaterRdrCust.DataSource = dr;
            repeaterRdrCust.DataBind();
            dr.Close();

            DataSet ds = new DataSet();
            FillEmployeesDataSet(ds);

            repeaterDtEmp.DataSource = ds;
            repeaterDtEmp.DataMember = "Employees";
            repeaterDtEmp.DataBind();

            connEmp.Open();
            dataAdapterEmp.Fill(dataSetEmp);
            RepeaterDesignTime.DataBind();
            connEmp.Close();
         }
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

      private void FillEmployeesDataSet(DataSet ds)
      {
         SqlConnection conn =
            new SqlConnection("Server=(local);Database=Northwind;Integrated Security=true;");
         conn.Open();

         SqlDataAdapter da =
            new SqlDataAdapter("SELECT EmployeeID, FirstName, LastName, Title FROM Employees WHERE EmployeeID < 5",
            conn);
         da.Fill(ds,"Employees");

         conn.Close();
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
         System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
         this.dataAdapterEmp = new System.Data.SqlClient.SqlDataAdapter();
         this.connEmp = new System.Data.SqlClient.SqlConnection();
         this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
         this.dataSetEmp = new ControlsBookWeb.Ch07.dataSetEmp();
         ((System.ComponentModel.ISupportInitialize)(this.dataSetEmp)).BeginInit();
         // 
         // dataAdapterEmp
         // 
         this.dataAdapterEmp.SelectCommand = this.sqlSelectCommand1;
         this.dataAdapterEmp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
                                                                                                 new System.Data.Common.DataTableMapping("Table", "Employees", new System.Data.Common.DataColumnMapping[] {
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("LastName", "LastName"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Title", "Title"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("TitleOfCourtesy", "TitleOfCourtesy"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("BirthDate", "BirthDate"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("HireDate", "HireDate"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Address", "Address"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("City", "City"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Region", "Region"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Country", "Country"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("HomePhone", "HomePhone"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Extension", "Extension"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Photo", "Photo"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("Notes", "Notes"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("ReportsTo", "ReportsTo"),
                                                                                                                                                                                                             new System.Data.Common.DataColumnMapping("PhotoPath", "PhotoPath")})});
         // 
         // connEmp
         // 
         this.connEmp.ConnectionString = ((string)(configurationAppSettings.GetValue("connEmp.ConnectionString", typeof(string))));
         // 
         // sqlSelectCommand1
         // 
         this.sqlSelectCommand1.CommandText = "SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDa" +
            "te, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Not" +
            "es, ReportsTo, PhotoPath FROM Employees";
         this.sqlSelectCommand1.Connection = this.connEmp;
         // 
         // dataSetEmp
         // 
         this.dataSetEmp.DataSetName = "dataSetEmp";
         this.dataSetEmp.Locale = new System.Globalization.CultureInfo("en-US");
         this.Load += new System.EventHandler(this.Page_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dataSetEmp)).EndInit();

      }
      #endregion
   }
}