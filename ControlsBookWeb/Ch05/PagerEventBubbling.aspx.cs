// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: PagerEventBubbling.aspx.cs
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
   public class PagerEventBubbling : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.Label DirectionLabel;
      protected ControlsBookLib.Ch05.Pager pager1;
      protected ControlsBookLib.Ch05.Pager pager2;

      private void Page_Load(object sender, System.EventArgs e)
      {
         DirectionLabel.Text = "<none>";
         pager2.Display = ControlsBookLib.Ch05.ButtonDisplay.Hyperlink;
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
         this.pager1.PageCommand += new ControlsBookLib.Ch05.PageCommandEventHandler(this.Pagers_PageCommand);
         this.pager2.PageCommand += new ControlsBookLib.Ch05.PageCommandEventHandler(this.Pagers_PageCommand);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Pagers_PageCommand(object o, ControlsBookLib.Ch05.PageCommandEventArgs pce)
      {
         DirectionLabel.Text =
            Enum.GetName(typeof(ControlsBookLib.Ch05.PageDirection),
            pce.Direction);
      }
   }
}
