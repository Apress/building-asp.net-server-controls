// Title: Building ASP.NET Server Controls
//
// Chapter: 2 - Server Control Basics
// File: HelloWorld.aspx.cs
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

namespace ControlsBookWeb.Ch02
{
   public class HelloWorld : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.TextBox TextBox1;
      protected System.Web.UI.WebControls.Button Button1;
      protected System.Web.UI.WebControls.DropDownList DropDownList1;
      protected System.Web.UI.WebControls.Label Label2;
      protected System.Web.UI.WebControls.Label Label1;

      private void Page_Load(object sender, System.EventArgs e)
      {
         Label1.Text = "";

         if (!Page.IsPostBack)
            LoadDropDownList();

         DataBind();
      }

      private void LoadDropDownList()
      {
         ArrayList list = new ArrayList();
         list.Add("Hello");
         list.Add("Goodbye");

         DropDownList1.DataSource = list;
      }

      protected string GetTitle()
      {
         return "Ch02 Hello World!";
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
         this.TextBox1.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
         this.Button1.Click += new System.EventHandler(this.Button1_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Button1_Click(object sender, System.EventArgs e)
      {
         Label1.Text = DropDownList1.SelectedItem.Value + "&nbsp;" + TextBox1.Text + "!";
      }

      private void TextBox_TextChanged(object sender, System.EventArgs e)
      {
         Label2.Text = "Changed to " + TextBox1.Text;
      }
   }
}
