// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: SimpletextEditor.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ControlsBookLib.Ch12.Design
{
   public class formSimpleTextEditorDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TextBox textString;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;

      private System.ComponentModel.Container components = null;

      public formSimpleTextEditorDialog()
      {
         InitializeComponent();
      }

      public string TextValue
      {
         get
         {
            return textString.Text;
         }
         set
         {
            textString.Text = value;
         }
      }

      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.textString = new System.Windows.Forms.TextBox();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         //
         // textString
         //
         this.textString.Location = new System.Drawing.Point(16, 16);
         this.textString.Multiline = true;
         this.textString.Name = "textString";
         this.textString.Size = new System.Drawing.Size(264, 200);
         this.textString.TabIndex = 0;
         this.textString.Text = "";
         //
         // buttonCancel
         //
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(200, 232);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "&Cancel";
         //
         // buttonOK
         //
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(112, 232);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "&Ok";
         //
         // formSimpleTextEditorDialog
         //
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.textString);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "formSimpleTextEditorDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Simple Text Editor";
         this.ResumeLayout(false);

      }
      #endregion
   }
}