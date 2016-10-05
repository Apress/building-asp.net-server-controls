// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: InputBoxStyle.aspx.cs
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
   public class InputBoxStyle : System.Web.UI.Page
   {
      protected ControlsBookLib.Ch06.InputBox NameInputBox;
      protected System.Web.UI.WebControls.RadioButtonList LabelActionList;
      protected System.Web.UI.WebControls.DropDownList LabelFontDropDownList;
      protected System.Web.UI.WebControls.DropDownList LabelForeColorDropDownList;
      protected System.Web.UI.WebControls.CheckBox LabelBoldCheckbox;
      protected System.Web.UI.WebControls.CheckBox LabelItalicCheckbox;
      protected System.Web.UI.WebControls.RadioButtonList TextboxActionList;
      protected System.Web.UI.WebControls.DropDownList TextboxFontDropDownList;
      protected System.Web.UI.WebControls.DropDownList TextboxForeColorDropDownList;
      protected System.Web.UI.WebControls.CheckBox TextboxBoldCheckbox;
      protected System.Web.UI.WebControls.CheckBox TextboxItalicCheckbox;
      protected System.Web.UI.WebControls.Button SetStyleButton;
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

      private void SetLabelStyle()
      {
         NameInputBox.LabelStyle.Font.Name = LabelFontDropDownList.SelectedItem.Value;
         NameInputBox.LabelStyle.Font.Bold = (LabelBoldCheckbox.Checked == true);
         NameInputBox.LabelStyle.Font.Italic = (LabelItalicCheckbox.Checked == true);
         Color labelColor =
            (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(
            LabelForeColorDropDownList.SelectedItem.Value);
         NameInputBox.LabelStyle.ForeColor = labelColor;
      }

      private void SetTextboxStyle()
      {
         NameInputBox.TextboxStyle.Font.Name = TextboxFontDropDownList.SelectedItem.Value;
         NameInputBox.TextboxStyle.Font.Bold = (TextboxBoldCheckbox.Checked == true);
         NameInputBox.TextboxStyle.Font.Italic = (TextboxItalicCheckbox.Checked == true);

         // Use the TypeConverter for the System.Drawing.Color class
         // to get the typed Color value from the string value
         Color textboxColor =
            (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(
            TextboxForeColorDropDownList.SelectedItem.Value);
         NameInputBox.TextboxStyle.ForeColor = textboxColor;
      }

      private void SetStyleButton_Click(object sender, System.EventArgs e)
      {
         if (LabelActionList.SelectedIndex > 0)
            SetLabelStyle();

         if (TextboxActionList.SelectedIndex > 0)
            SetTextboxStyle();
      }
   }
}
