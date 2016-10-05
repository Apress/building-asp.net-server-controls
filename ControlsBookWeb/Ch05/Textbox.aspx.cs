// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: Textbox.aspx.cs
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
   public class Textbox : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Button SubmitPageButton;
      protected ControlsBookLib.Ch05.Textbox NameTextbox;
      protected System.Web.UI.WebControls.Label ChangeLabel;

      private void Page_Load(object sender, System.EventArgs e)
      {
         ChangeLabel.Text = DateTime.Now.ToLongTimeString() + ": No change.";
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
         this.NameTextbox.TextChanged += new System.EventHandler(this.Name_TextChanged);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Name_TextChanged(object sender, System.EventArgs e)
      {
         ChangeLabel.Text = DateTime.Now.ToLongTimeString() + ": Changed!";
      }
   }
}
