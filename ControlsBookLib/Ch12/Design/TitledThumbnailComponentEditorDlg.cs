// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: TitledThmbnailComponentEditorDlg.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch12
{
   public class TitledThumbnailComponentEditorDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.DateTimePicker dtpImageTaken;
      private System.Windows.Forms.TextBox textLocation;
      private System.Windows.Forms.TextBox textLongImageDesc;
      private System.Windows.Forms.ComboBox cboAlignment;
      private System.Windows.Forms.TextBox textImageTitle;
      private System.Windows.Forms.TextBox textPhotographerFullName;

      private TitledThumbnail titledThumbnail;

      public TitledThumbnailComponentEditorDlg(TitledThumbnail component)
      {
         InitializeComponent();

         titledThumbnail = component;

         PopulateAlignment();

         cboAlignment.Text = Enum.GetName(typeof(TitleAlignment),titledThumbnail.Align);
         textImageTitle.Text = titledThumbnail.Title;
         textLocation.Text = titledThumbnail.ImageInfo.ImageLocation.ToString();
         textPhotographerFullName.Text = titledThumbnail.ImageInfo.PhotographerFullName;
         dtpImageTaken.Value = titledThumbnail.ImageInfo.ImageDate;
         textLongImageDesc.Text = titledThumbnail.ImageInfo.ImageLongDescription;
      }

      private void PopulateAlignment()
      {
         foreach (object Align in Enum.GetValues(typeof(TitleAlignment)))
         {
            cboAlignment.Items.Add(Align);
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
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.cboAlignment = new System.Windows.Forms.ComboBox();
         this.textImageTitle = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.textLongImageDesc = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.textPhotographerFullName = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.textLocation = new System.Windows.Forms.TextBox();
         this.dtpImageTaken = new System.Windows.Forms.DateTimePicker();
         this.label3 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         //
         // buttonCancel
         //
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(384, 344);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "&Cancel";
         //
         // buttonOK
         //
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(288, 344);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.TabIndex = 0;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         //
         // label1
         //
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 16);
         this.label1.TabIndex = 2;
         this.label1.Text = "Image Title:";
         //
         // cboAlignment
         //
         this.cboAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboAlignment.Location = new System.Drawing.Point(344, 40);
         this.cboAlignment.Name = "cboAlignment";
         this.cboAlignment.Size = new System.Drawing.Size(121, 21);
         this.cboAlignment.TabIndex = 3;
         //
         // textImageTitle
         //
         this.textImageTitle.Location = new System.Drawing.Point(16, 40);
         this.textImageTitle.Name = "textImageTitle";
         this.textImageTitle.Size = new System.Drawing.Size(304, 20);
         this.textImageTitle.TabIndex = 4;
         this.textImageTitle.Text = "";
         //
         // label2
         //
         this.label2.Location = new System.Drawing.Point(344, 16);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(100, 16);
         this.label2.TabIndex = 5;
         this.label2.Text = "Alignment";
         //
         // groupBox1
         //
         this.groupBox1.Controls.Add(this.textLongImageDesc);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.textPhotographerFullName);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.textLocation);
         this.groupBox1.Controls.Add(this.dtpImageTaken);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Location = new System.Drawing.Point(16, 80);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(448, 248);
         this.groupBox1.TabIndex = 6;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Image Info";
         //
         // textLongImageDesc
         //
         this.textLongImageDesc.Location = new System.Drawing.Point(8, 120);
         this.textLongImageDesc.Multiline = true;
         this.textLongImageDesc.Name = "textLongImageDesc";
         this.textLongImageDesc.Size = new System.Drawing.Size(424, 112);
         this.textLongImageDesc.TabIndex = 14;
         this.textLongImageDesc.Text = "";
         //
         // label6
         //
         this.label6.Location = new System.Drawing.Point(8, 96);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(136, 16);
         this.label6.TabIndex = 13;
         this.label6.Text = "Long Image Description:";
         //
         // label5
         //
         this.label5.Location = new System.Drawing.Point(272, 32);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(152, 16);
         this.label5.TabIndex = 12;
         this.label5.Text = "Photographer Full Name:";
         //
         // textPhotographerFullName
         //
         this.textPhotographerFullName.Location = new System.Drawing.Point(272, 56);
         this.textPhotographerFullName.Name = "textPhotographerFullName";
         this.textPhotographerFullName.Size = new System.Drawing.Size(160, 20);
         this.textPhotographerFullName.TabIndex = 11;
         this.textPhotographerFullName.Text = "";
         //
         // label4
         //
         this.label4.Location = new System.Drawing.Point(136, 32);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(128, 16);
         this.label4.TabIndex = 10;
         this.label4.Text = "Location Image Taken:";
         //
         // textLocation
         //
         this.textLocation.Location = new System.Drawing.Point(136, 56);
         this.textLocation.Name = "textLocation";
         this.textLocation.Size = new System.Drawing.Size(112, 20);
         this.textLocation.TabIndex = 9;
         this.textLocation.Text = "0N,0W";
         //
         // dtpImageTaken
         //
         this.dtpImageTaken.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dtpImageTaken.Location = new System.Drawing.Point(8, 56);
         this.dtpImageTaken.Name = "dtpImageTaken";
         this.dtpImageTaken.Size = new System.Drawing.Size(112, 20);
         this.dtpImageTaken.TabIndex = 8;
         this.dtpImageTaken.Value = new System.DateTime(2003, 4, 8, 0, 0, 0, 0);
         //
         // label3
         //
         this.label3.Location = new System.Drawing.Point(8, 32);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(100, 16);
         this.label3.TabIndex = 7;
         this.label3.Text = "Date Image Taken:";
         //
         // TitledThumbnailComponentEditorDlg
         //
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(480, 382);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.textImageTitle);
         this.Controls.Add(this.cboAlignment);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Name = "TitledThumbnailComponentEditorDlg";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Titled Thumbnail Property Builder";
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private void buttonOK_Click(object sender, System.EventArgs e)
      {
         PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(titledThumbnail);

         PropertyDescriptor Title = properties["Title"];
         if (Title != null)
         {
            try
            {
               Title.SetValue(titledThumbnail,textImageTitle.Text);
            }
            catch (Exception err)
            {
               MessageBox.Show(this,
                  "Problem setting title property: Source:"+
                  err.Source+" Message: "+err.Message,"Error",
                  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         }

         PropertyDescriptor alignment = properties["Align"];
         if (alignment != null)
         {
            try
            {
               alignment.SetValue(titledThumbnail,Enum.Parse(typeof(TitleAlignment),cboAlignment.Text));
            }
            catch (Exception err)
            {
               MessageBox.Show(this,"Problem setting align property: Source:"+
                  err.Source+" Message: "+err.Message,"Error",
                  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         }

         PropertyDescriptorCollection imageInfoProps =
            TypeDescriptor.GetProperties(titledThumbnail.ImageInfo);

         PropertyDescriptor imageDescription = imageInfoProps["ImageLongDescription"];
         if (imageDescription != null)
         {
            try
            {
               imageDescription.SetValue(titledThumbnail.ImageInfo,textLongImageDesc.Text);
            }
            catch (Exception err)
            {
               MessageBox.Show(this,
                  "Problem setting image Long Description property: Source:"+
                  err.Source+" Message: "+err.Message,"Error",
                  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         }

         PropertyDescriptor imageDate = imageInfoProps["ImageDate"];
         if (imageDate != null)
         {
            try
            {
               imageDate.SetValue(titledThumbnail.ImageInfo,dtpImageTaken.Value);
            }
            catch (Exception err)
            {
               MessageBox.Show(this,
                  "Problem setting image date property: Source:"+err.Source+" Message: "
                  +err.Message,"Error",
                  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         }

         PropertyDescriptor photographerFullName = imageInfoProps["PhotographerFullName"];
         if (photographerFullName != null)
         {
            try
            {
               photographerFullName.SetValue(titledThumbnail.ImageInfo,textPhotographerFullName.Text);
            }
            catch (Exception err)
            {
               MessageBox.Show(this,
                  "Problem setting photographer's full name property: Source:"+
                  err.Source+" Message: "+err.Message,"Error",
                  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         }

         PropertyDescriptor imageLocation = imageInfoProps["ImageLocation"];
         if (imageLocation != null)
         {
            try
            {
               LocationConverter converter = new LocationConverter();
               imageLocation.SetValue(titledThumbnail.ImageInfo,converter.ConvertFrom(null,Application.CurrentCulture,textLocation.Text));
            }
            catch (Exception err)
            {
               MessageBox.Show(this,
                  "Problem setting image location property: Source:"+
                  err.Source+" Message: "+err.Message,"Error",
                  MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         }
      }
   }
}