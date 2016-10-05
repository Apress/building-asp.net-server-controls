// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: WebControlStyle.aspx.cs
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
   public class WebControlStyle : System.Web.UI.Page
   {
      protected ControlsBookLib.Ch06.Textbox NameTextbox;
      protected ControlsBookLib.Ch06.Label NameLabel;
      protected System.Web.UI.WebControls.CheckBox BoldCheckbox;
      protected System.Web.UI.WebControls.CheckBox ItalicCheckBox;
      protected System.Web.UI.WebControls.DropDownList FontDropDownList;
      protected System.Web.UI.WebControls.CheckBox ItalicCheckbox;
      protected System.Web.UI.WebControls.CheckBox UnderlineCheckbox;
      protected System.Web.UI.WebControls.DropDownList ForeColorDropDownList;
      protected System.Web.UI.WebControls.Button SetStyleButton;
      protected System.Web.UI.WebControls.TextBox CssClassTextBox;
      protected System.Web.UI.WebControls.Label StylePropsLabel;
      protected System.Web.UI.WebControls.Label ControlStylePropsLabel;
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
         this.SetStyleButton.Click += new System.EventHandler(this.SetStyleButton_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void SetStyleButton_Click(object sender, System.EventArgs e)
      {
         NameLabel.Text = NameTextbox.Text;

         NameLabel.CssClass = CssClassTextBox.Text;

         NameLabel.Font.Name = FontDropDownList.SelectedItem.Value;
         NameLabel.Font.Bold = (BoldCheckbox.Checked == true);
         NameLabel.Font.Italic = (ItalicCheckbox.Checked == true);

         // Use the TypeConverter for the System.Drawing.Color class
         // to get the typed Color value from the string value
         Color c =
            (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(
            ForeColorDropDownList.SelectedItem.Value);
         NameLabel.ForeColor = c;

         // set the text-decoration CSS style attribute
         // using manual manipulation of the Style property
         string textdecoration = "none";
         if (UnderlineCheckbox.Checked == true)
            textdecoration = "underline";
         NameLabel.Style["text-decoration"] = textdecoration;
      }
   }
}
