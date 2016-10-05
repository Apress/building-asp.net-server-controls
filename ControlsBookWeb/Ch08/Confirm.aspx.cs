// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: Confirm.aspx.cs
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

namespace ControlsBookWeb.Ch08
{
   public class Confirm : System.Web.UI.Page
   {
      protected ControlsBookLib.Ch08.ConfirmedLinkButton confirmlink1;
      protected System.Web.UI.WebControls.Button submitbtn;
      protected System.Web.UI.WebControls.Label status;
      protected System.Web.UI.WebControls.LinkButton linkbutton1;
      protected ControlsBookLib.Ch08.FormConfirmation confirm1;
      protected System.Web.UI.WebControls.Button button1;
      protected ControlsBookWeb.ControlsBookHeader Header ;

      private void Page_Load(object sender, System.EventArgs e)
      {
         status.Text = "";
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
         this.button1.Click += new System.EventHandler(this.Button_Click);
         this.linkbutton1.Click += new System.EventHandler(this.LinkButton_Click);
         this.confirmlink1.Click += new System.EventHandler(this.ConfirmLinkButton_ClickClick);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Button_Click(object sender, System.EventArgs e)
      {
         status.Text = "Regular Button Clicked!";
      }

      private void LinkButton_Click(object sender, System.EventArgs e)
      {
         status.Text = "LinkButton Clicked!";
      }

      private void ConfirmLinkButton_ClickClick(object sender, System.EventArgs e)
      {
         status.Text = "ConfirmLinkButton Clicked!";
      }
   }
}
