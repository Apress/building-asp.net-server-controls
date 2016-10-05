// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: UpDown.aspx.cs
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
   public class UpDown : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Label timelabel;
      protected System.Web.UI.WebControls.Button submitbtn;
      protected System.Web.UI.WebControls.Label changelabel;
      protected ControlsBookWeb.ControlsBookHeader Header ;
      protected ControlsBookLib.Ch08.UpDown updown1;

      private void Page_Load(object sender, System.EventArgs e)
      {

         timelabel.Text = DateTime.Now.ToString();
         changelabel.Text = "";
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
         this.updown1.ValueChanged += new System.EventHandler(this.updown1_ValueChanged);
         this.Load += new System.EventHandler(this.Page_Load);
      }
      #endregion

      private void updown1_ValueChanged(object sender, System.EventArgs e)
      {
         changelabel.Text = " UpDown value is now " + updown1.Value + "!";
      }
   }
}
