// Title: Building ASP.NET Server Controls
//
// Header User Control
// File: ControlsBookHeader.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ControlsBookWeb
{
   public class ControlsBookHeader : System.Web.UI.UserControl
   {
      private void Page_Load(object sender, System.EventArgs e)
      {
         Label3.Text = chapterNumber.ToString() ;
         Label4.Text = bookChapterTitle ;
      }

      protected System.Web.UI.WebControls.Label Label1;
      protected System.Web.UI.WebControls.Label Label2;
      protected System.Web.UI.WebControls.Label Label3;
      protected System.Web.UI.WebControls.Label Label4;

      //private members
      private string bookChapterTitle ;
      private int chapterNumber ;

      //properties
      public String ChapterTitle
      {
         get
         {
            return bookChapterTitle ;
         }
         set
         {
            bookChapterTitle = value;
         }
      }

      public int ChapterNumber
      {
         get
         {
            return chapterNumber ;
         }
         set
         {
            chapterNumber = value;
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