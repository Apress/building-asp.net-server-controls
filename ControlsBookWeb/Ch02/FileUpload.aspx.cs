// Title: Building ASP.NET Server Controls
//
// Chapter: 2 - Server Control Basics
// File: FileUpload.aspx.cs
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

namespace ControlsBookWeb.Ch02
{
   public class FileUpload : System.Web.UI.Page
   {
      protected System.Web.UI.HtmlControls.HtmlInputFile File;
      protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
      protected System.Web.UI.HtmlControls.HtmlInputText Name;
      protected System.Web.UI.HtmlControls.HtmlGenericControl result;

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
         this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Submit1_ServerClick(object sender, System.EventArgs e)
      {
         if (File.PostedFile != null)
         {
            HttpPostedFile file = File.PostedFile;
            string filename = @"C:\temp\" + Name.Value;
            file.SaveAs(filename);
            result.InnerHtml = "Source File: " + file.FileName + "<BR>" +
               "Saved File: " + filename + "." + "<BR>" +
               "Length: " + file.ContentLength + "<BR>" +
               "Type: " + file.ContentType + "<BR>";
         }
         else
            result.InnerHtml = "No file posted!";
      }
   }
}
