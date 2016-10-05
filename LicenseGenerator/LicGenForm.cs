using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace LicenseGenerator
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class LicGenForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TextBox PublicKey;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox PrivateKey;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox GUID;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.DateTimePicker Expires;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox License;
      private System.Windows.Forms.SaveFileDialog saveFileDialog1;
      private System.Windows.Forms.Button btnGenLicense;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Button btnValLicense;
      private System.Windows.Forms.Button btnCreateFile;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public LicGenForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null)
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
         this.btnGenLicense = new System.Windows.Forms.Button();
         this.PublicKey = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.PrivateKey = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.GUID = new System.Windows.Forms.TextBox();
         this.btnClose = new System.Windows.Forms.Button();
         this.btnValLicense = new System.Windows.Forms.Button();
         this.label5 = new System.Windows.Forms.Label();
         this.Expires = new System.Windows.Forms.DateTimePicker();
         this.label6 = new System.Windows.Forms.Label();
         this.License = new System.Windows.Forms.TextBox();
         this.btnCreateFile = new System.Windows.Forms.Button();
         this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
         this.SuspendLayout();
         //
         // btnGenLicense
         //
         this.btnGenLicense.Location = new System.Drawing.Point(8, 296);
         this.btnGenLicense.Name = "btnGenLicense";
         this.btnGenLicense.Size = new System.Drawing.Size(112, 24);
         this.btnGenLicense.TabIndex = 0;
         this.btnGenLicense.Text = "Generate License";
         this.btnGenLicense.Click += new System.EventHandler(this.btnGenLicense_Click);
         //
         // PublicKey
         //
         this.PublicKey.Location = new System.Drawing.Point(8, 136);
         this.PublicKey.Multiline = true;
         this.PublicKey.Name = "PublicKey";
         this.PublicKey.Size = new System.Drawing.Size(496, 48);
         this.PublicKey.TabIndex = 1;
         this.PublicKey.Text = "";
         //
         // label1
         //
         this.label1.Location = new System.Drawing.Point(8, 112);
         this.label1.Name = "label1";
         this.label1.TabIndex = 2;
         this.label1.Text = "Public Key";
         //
         // label2
         //
         this.label2.Location = new System.Drawing.Point(8, 56);
         this.label2.Name = "label2";
         this.label2.TabIndex = 4;
         this.label2.Text = "Private Key";
         //
         // PrivateKey
         //
         this.PrivateKey.Location = new System.Drawing.Point(8, 72);
         this.PrivateKey.Multiline = true;
         this.PrivateKey.Name = "PrivateKey";
         this.PrivateKey.Size = new System.Drawing.Size(496, 40);
         this.PrivateKey.TabIndex = 3;
         this.PrivateKey.Text = "";
         //
         // label3
         //
         this.label3.Location = new System.Drawing.Point(8, 8);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(32, 16);
         this.label3.TabIndex = 6;
         this.label3.Text = "Guid";
         //
         // GUID
         //
         this.GUID.Location = new System.Drawing.Point(8, 24);
         this.GUID.Multiline = true;
         this.GUID.Name = "GUID";
         this.GUID.Size = new System.Drawing.Size(496, 24);
         this.GUID.TabIndex = 5;
         this.GUID.Text = "";
         //
         // btnClose
         //
         this.btnClose.Location = new System.Drawing.Point(432, 296);
         this.btnClose.Name = "btnClose";
         this.btnClose.TabIndex = 9;
         this.btnClose.Text = "Close";
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         //
         // btnValLicense
         //
         this.btnValLicense.Location = new System.Drawing.Point(128, 296);
         this.btnValLicense.Name = "btnValLicense";
         this.btnValLicense.Size = new System.Drawing.Size(112, 24);
         this.btnValLicense.TabIndex = 12;
         this.btnValLicense.Text = "Validate License";
         this.btnValLicense.Click += new System.EventHandler(this.btnValLicense_Click);
         //
         // label5
         //
         this.label5.Location = new System.Drawing.Point(8, 192);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(80, 16);
         this.label5.TabIndex = 11;
         this.label5.Text = "Expires";
         //
         // Expires
         //
         this.Expires.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.Expires.Location = new System.Drawing.Point(88, 192);
         this.Expires.Name = "Expires";
         this.Expires.TabIndex = 10;
         this.Expires.Value = new System.DateTime(2003, 5, 30, 15, 11, 30, 224);
         //
         // label6
         //
         this.label6.Location = new System.Drawing.Point(8, 216);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(144, 16);
         this.label6.TabIndex = 14;
         this.label6.Text = "License ";
         //
         // License
         //
         this.License.Location = new System.Drawing.Point(8, 232);
         this.License.Multiline = true;
         this.License.Name = "License";
         this.License.Size = new System.Drawing.Size(496, 56);
         this.License.TabIndex = 13;
         this.License.Text = "";
         //
         // btnCreateFile
         //
         this.btnCreateFile.Location = new System.Drawing.Point(256, 296);
         this.btnCreateFile.Name = "btnCreateFile";
         this.btnCreateFile.Size = new System.Drawing.Size(112, 24);
         this.btnCreateFile.TabIndex = 15;
         this.btnCreateFile.Text = "Create Lic File";
         this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
         //
         // LicGenForm
         //
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(512, 326);
         this.Controls.Add(this.btnCreateFile);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.License);
         this.Controls.Add(this.btnValLicense);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.Expires);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.GUID);
         this.Controls.Add(this.PrivateKey);
         this.Controls.Add(this.btnGenLicense);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.PublicKey);
         this.Name = "LicGenForm";
         this.Text = "License Generator Form";
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.Run(new LicGenForm());
      }

      private string GetLicenseText()
      {
         return GUID.Text + "#" + Expires.Value.ToShortDateString() + "#";
      }

      private void btnGenLicense_Click(object sender, System.EventArgs e)
      {
         GUID.Text = Guid.NewGuid().ToString();
         byte[] clear = ASCIIEncoding.ASCII.GetBytes(GetLicenseText());
         SHA1Managed provSHA1 = new SHA1Managed();
         byte[] hash = provSHA1.ComputeHash(clear);


         RSACryptoServiceProvider provRSA = new RSACryptoServiceProvider();
         PublicKey.Text = provRSA.ToXmlString(false);
         PrivateKey.Text = provRSA.ToXmlString(true);

         byte[] signature = provRSA.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

         License.Text = GetLicenseText() + Convert.ToBase64String(signature,0,signature.Length);
      }

      private void btnClose_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }

      private void btnValLicense_Click(object sender, System.EventArgs e)
      {
         // pull out the text portion of license before
         // the signature
         string[] values = License.Text.Split(new char[] {'#'});
         byte[] clear = ASCIIEncoding.ASCII.GetBytes(
            values[0] + "#" + values[1] + "#");

         // recompute the hash value
         SHA1Managed provSHA1 = new SHA1Managed();
         byte[] hash = provSHA1.ComputeHash(clear);

         // reload the RSA provider based on the public key only
         RSACryptoServiceProvider provRSA = new RSACryptoServiceProvider();
         provRSA.FromXmlString(PublicKey.Text);

         // split out the signature portion of the license
         byte[] sigBytes = Convert.FromBase64String(values[2]);

         // verify the signature of the hash
         bool result = provRSA.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"),
            sigBytes);
         MessageBox.Show("Signature verified:" + result);
      }

      private void btnCreateFile_Click(object sender, System.EventArgs e)
      {
         if (DialogResult.OK == saveFileDialog1.ShowDialog(this))
         {
            string filename = saveFileDialog1.FileName;

            // create a new file or truncate existing one
            // while pushing license string to it
            FileStream stm = new FileStream(filename, FileMode.Truncate);
            StreamWriter wtr = new StreamWriter(stm);
            wtr.Write(License.Text);

            // flush and close file buffers
            wtr.Flush();
            stm.Flush();
            wtr.Close();
            stm.Close();
         }
      }
   }
}
