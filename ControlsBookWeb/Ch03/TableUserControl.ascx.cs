// Title: Building ASP.NET Server Controls
//
// Chapter: 3 - Building Server Controls
// File: TableUserControl.ascx.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
namespace ControlsBookWeb.Ch03
{
   using System;
   using System.Data;
   using System.Drawing;
   using System.Web;
   using System.Web.UI.WebControls;
   using System.Web.UI.HtmlControls;

   public abstract class TableUserControl : System.Web.UI.UserControl
   {
      protected System.Web.UI.HtmlControls.HtmlTable Table1;
      protected System.Web.UI.WebControls.Label XLabel;
      protected System.Web.UI.WebControls.Label YLabel;

      // variables to hold dimensions of HTML table
      private int yDim = 1;
      private int xDim = 1;

      // properties to access dimensions of HTML table
      public int X
      {
         get{ return xDim; }
         set{ xDim = value; }
      }
      public int Y
      {
         get{ return yDim; }
         set{ yDim = value; }
      }


      // HTML table building routine
      private void BuildTable(int xDim, int yDim)
      {
         HtmlTableRow row;
         HtmlTableCell cell;
         HtmlGenericControl content;

         for (int y=0; y < yDim; y++)
         {
            // create <TR>
            row = new HtmlTableRow();

            for (int x=0; x < xDim; x++)
            {
               // create <TD cellspacing=1>
               cell = new HtmlTableCell();
               cell.Attributes.Add("border","1");

               // create a <SPAN>
               content = new HtmlGenericControl("SPAN");
               content.InnerHtml = "X:" + x.ToString() +
                  "Y:" + y.ToString();
               cell.Controls.Add(content);

               row.Cells.Add(cell);
            }
            Table1.Rows.Add(row);
         }
      }

      private void Page_Load(object sender, System.EventArgs e)
      {
         XLabel.Text = X.ToString();
         YLabel.Text = Y.ToString();

         BuildTable(X, Y);
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
