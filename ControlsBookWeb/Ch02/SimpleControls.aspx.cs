// Title: Building ASP.NET Server Controls
//
// Chapter: 2 - Server Control Basics
// File: SimpleControls.aspx.cs
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
   public class SimpleControls : System.Web.UI.Page
   {
      protected System.Web.UI.WebControls.TextBox XTextBox;
      protected System.Web.UI.WebControls.TextBox YTextBox;
      protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
      protected System.Web.UI.WebControls.Button Button1;
      protected ControlsBookWeb.ControlsBookHeader Header ;

      private void Page_Load(object sender, System.EventArgs e)
      {
         Header.ChapterNumber = 2 ;
         Header.ChapterTitle = "Server Control Basics" ;
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
         this.Button1.Click += new System.EventHandler(this.Button1_Click);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Button1_Click(object sender, System.EventArgs e)
      {
         int xDim = Convert.ToInt32(XTextBox.Text);
         int yDim = Convert.ToInt32(YTextBox.Text);
         BuildTable(xDim,yDim);
      }

      private void BuildTable(int xDim, int yDim)
      {
         Table table;
         TableRow row;
         TableCell cell;
         Literal content;

         table = new Table();
         table.BorderWidth = 1;
         table.BorderStyle = BorderStyle.Ridge;
         for (int y=0; y < yDim; y++)
         {
            row = new TableRow();
            for (int x=0; x < xDim; x++)
            {
               cell = new TableCell();
               cell.BackColor = Color.Blue;
               cell.BorderWidth = 1;
               cell.ForeColor = Color.Yellow;
               cell.Font.Name = "Verdana";
               cell.Font.Size = 16;
               cell.Font.Bold = true;
               cell.Font.Italic = true;

               content = new Literal();
               content.Text = "<SPAN>X:" + x.ToString() +
                  "Y:" + y.ToString() + "</SPAN>";
               cell.Controls.Add(content);
               row.Cells.Add(cell);
            }
            table.Rows.Add(row);
         }
         PlaceHolder1.Controls.Add(table);
      }
   }
}
