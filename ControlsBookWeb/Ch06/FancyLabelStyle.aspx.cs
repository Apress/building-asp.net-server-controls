// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: FancyLabelStyle.aspx.cs
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

namespace ControlsBookWeb.Ch06
{
   public class FancyLabelStyle : System.Web.UI.Page
   {
      protected ControlsBookLib.Ch06.FancyLabel AutoLabel;
      protected ControlsBookLib.Ch06.FancyLabel CrosshairLabel;
      protected ControlsBookLib.Ch06.FancyLabel HandLabel;
      protected ControlsBookLib.Ch06.FancyLabel MoveLabel;
      protected ControlsBookLib.Ch06.FancyLabel TextLabel;
      protected ControlsBookLib.Ch06.FancyLabel WaitLabel;
      protected System.Web.UI.WebControls.Button Button1;
      protected ControlsBookLib.Ch06.FancyLabel DefaultLabel;
      protected ControlsBookLib.Ch06.FancyLabel HelpLabel;

      private void Page_Load(object sender, System.EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            AutoLabel.Cursor = ControlsBookLib.Ch06.CursorStyle.auto;
            CrosshairLabel.Cursor = ControlsBookLib.Ch06.CursorStyle.crosshair;
            HandLabel.Cursor = ControlsBookLib.Ch06.CursorStyle.hand;
            HelpLabel.Cursor = ControlsBookLib.Ch06.CursorStyle.help;
            MoveLabel.Cursor = ControlsBookLib.Ch06.CursorStyle.move;
            TextLabel.Cursor = ControlsBookLib.Ch06.CursorStyle.text;
            WaitLabel.Cursor = ControlsBookLib.Ch06.CursorStyle.wait;
         }
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
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion
   }
}
