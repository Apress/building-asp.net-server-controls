// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: AdvancedRepeater.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ControlsBookWeb.Ch07
{
   public class AdvancedRepeater : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Label status;
      protected System.Web.UI.WebControls.Button contact1;
      protected ControlsBookLib.Ch07.Repeater repeaterRdrCust;

      private void Page_Load(object sender, System.EventArgs e)
      {
         status.Text = "";

         if (!Page.IsPostBack)
         {
            SqlDataReader dr = GetCustomerDataReader();
            repeaterRdrCust.DataSource = dr;
            repeaterRdrCust.DataBind();
            dr.Close();

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
         this.repeaterRdrCust.ItemCreated += new ControlsBookLib.Ch07.RepeaterItemEventHandler(this.RepeaterItemCreated);
         this.repeaterRdrCust.ItemDataBound += new ControlsBookLib.Ch07.RepeaterItemEventHandler(this.RepeaterItemDataBound);
         this.repeaterRdrCust.ItemCommand += new ControlsBookLib.Ch07.RepeaterCommandEventHandler(this.RepeaterCommand);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void RepeaterCommand(object o, ControlsBookLib.Ch07.RepeaterCommandEventArgs tce)
      {
         ControlsBookLib.Ch07.RepeaterItem item = tce.Item;
         Label lblID = (Label) item.FindControl("lblID");
         status.Text = lblID.Text + " was clicked!";
      }

      private void RepeaterItemCreated(object o, ControlsBookLib.Ch07.RepeaterItemEventArgs rie)
      {
         ControlsBookLib.Ch07.RepeaterItem item = rie.Item;
         if (item.ItemType == ListItemType.Item)
         {
            Label lblID = new Label();
            lblID.ID = "lblID";
            item.Controls.Add(lblID);
            item.Controls.Add(new LiteralControl("&nbsp;"));
         }
      }

      private void RepeaterItemDataBound(object o, ControlsBookLib.Ch07.RepeaterItemEventArgs rie)
      {
         ControlsBookLib.Ch07.RepeaterItem item = rie.Item;
         DbDataRecord row = (DbDataRecord) item.DataItem;
         string ID = (string) row["CustomerID"];
         Label lblID = (Label) item.FindControl("lblID");
         lblID.Text = ID;
      }
   }
}
