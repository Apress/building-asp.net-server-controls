// Title: Building ASP.NET Server Controls
//
// Chapter: 4 - State Management
// File: PostbackData.aspx.cs
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

namespace ControlsBookWeb.Ch04
{
   public class PostbackData : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Button SetLabelButton;
      protected ControlsBookLib.Ch04.StatefulLabel StatefulLabel1;
      protected ControlsBookLib.Ch04.Textbox NameTextBox;
      protected ControlsBookLib.Ch04.StatelessLabel StatelessLabel1;
      protected System.Web.UI.WebControls.Button SubmitPageButton;

      private void Page_Load(object sender, System.EventArgs e)
      {

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
         this.SetLabelButton.Click += new System.EventHandler(this.SetLabelButton_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void SetLabelButton_Click(object sender, System.EventArgs e)
      {
         string name = NameTextBox.Text;

         StatelessLabel1.Text = "Set by " + name;
         StatefulLabel1.Text = "Set by " + name;
      }
   }
}
