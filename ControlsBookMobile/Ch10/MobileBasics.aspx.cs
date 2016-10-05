// Title: Building ASP.NET Server Controls
//
// Chapter: 10 - Mobile Controls
// File: MobileBasics.aspx.cs
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

   public class MobileBasics : System.Web.UI.MobileControls.MobilePage
   {
      protected System.Web.UI.MobileControls.Form Form2;
      protected System.Web.UI.MobileControls.TextBox TextBox1;
      protected System.Web.UI.MobileControls.Command cmdHello;
      protected System.Web.UI.MobileControls.Label Label1;
      protected System.Web.UI.MobileControls.Label Label2;
      protected System.Web.UI.MobileControls.Link Link1;
      protected System.Web.UI.MobileControls.Form Form1;



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
         this.cmdHello.Click += new System.EventHandler(this.cmdHello_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void cmdHello_Click(object sender, System.EventArgs e)
      {
         this.Label2.Text = "Hello " + TextBox1.Text;
         this.ActiveForm = Form2;
      }
   }
}
