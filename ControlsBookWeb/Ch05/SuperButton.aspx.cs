// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: SuperButton.aspx.cs
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

namespace ControlsBookWeb.Ch05
{
   public class SuperButton : System.Web.UI.Page
   {
      protected ControlsBookLib.Ch05.SuperButton superlink;
      protected System.Web.UI.WebControls.Label ClickLabel;
      protected ControlsBookLib.Ch05.SuperButton superbtn;

      private void Page_Load(object sender, System.EventArgs e)
      {
         ClickLabel.Text = "Waiting...";
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
         this.superbtn.Click += new System.EventHandler(this.superbtn_Click);
         this.superlink.Click += new System.EventHandler(this.superlink_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void superbtn_Click(object sender, System.EventArgs e)
      {
         ClickLabel.Text = "superbtn was clicked!";
      }

      private void superlink_Click(object sender, System.EventArgs e)
      {
         ClickLabel.Text = "superlink was clicked!";
      }
   }
}
