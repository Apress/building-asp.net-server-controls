// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: ExternalStyleSheetClass.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
namespace ControlsBookMobile.Ch11
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.Mobile;
	using System.Web.UI.MobileControls;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public abstract class ExternalStyleSheetClass : System.Web.UI.MobileControls.MobileUserControl
	{
      protected System.Web.UI.MobileControls.StyleSheet ExternalStyleSheet;

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

      }
		#endregion
	}
}
