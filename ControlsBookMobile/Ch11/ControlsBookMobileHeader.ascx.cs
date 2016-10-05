// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: ControlsBookMobileHeader.aspx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ControlsBookMobile.Ch11
{
   public abstract class ControlsBookMobileHeader : System.Web.UI.MobileControls.MobileUserControl
   {
      protected System.Web.UI.MobileControls.Label Label1;
      protected System.Web.UI.MobileControls.Label Label4;
      protected System.Web.UI.MobileControls.Image Image1;
      protected System.Web.UI.MobileControls.Label Label2;

      //private members
      private string bookChapterTitle ;
      private int chapterNumber ;

      private void Page_Load(object sender, System.EventArgs e)
      {
         Label1.Text = "Chapter " + chapterNumber.ToString() ;
         Label4.Text = bookChapterTitle ;
      }

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

      ///      Required method for Designer support - do not modify
      ///      the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion
   }
}
