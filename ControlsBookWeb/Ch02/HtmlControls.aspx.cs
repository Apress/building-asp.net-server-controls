// Title: Building ASP.NET Server Controls
//
// Chapter: 2 - Server Control Basics
// File: HtmlControls.aspx.cs
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
   public class HtmlControls : System.Web.UI.Page
   {
      protected System.Web.UI.HtmlControls.HtmlInputText XTextBox;
      protected System.Web.UI.HtmlControls.HtmlInputText YTextBox;
      protected System.Web.UI.HtmlControls.HtmlGenericControl Span1;
      protected System.Web.UI.HtmlControls.HtmlInputButton Button1;

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
         this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private void Button1_ServerClick(object sender, System.EventArgs e)
      {
         int xDim = Convert.ToInt32(XTextBox.Value);
         int yDim = Convert.ToInt32(YTextBox.Value);
         BuildTable(xDim,yDim);
      }

      private void BuildTable(int xDim, int yDim)
      {
         HtmlTable table;
         HtmlTableRow row;
         HtmlTableCell cell;
         HtmlGenericControl content;

         table = new HtmlTable();
         table.Border = 1;
         for (int y=0; y < yDim; y++)
         {
            row = new HtmlTableRow();
            for (int x=0; x < xDim; x++)
            {
               cell = new HtmlTableCell();
               cell.Style.Add("font","16pt verdana bold italic");
               cell.Style.Add("background-color","red");
               cell.Style.Add("color","yellow");

               content = new HtmlGenericControl("SPAN");
               content.InnerHtml = "X:" + x.ToString() +
                  "Y:" + y.ToString();
               cell.Controls.Add(content);
               row.Cells.Add(cell);
            }
            table.Rows.Add(row);
         }

         Span1.Controls.Add(table);
      }
   }
}
