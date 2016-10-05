// Title: Building ASP.NET Server Controls
//
// Chapter: 3 - Building Server Controls
// File: TableCompCustomControl.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Text;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch03
{
   [ToolboxData("<{0}:TableCompCustomControl runat=server></{0}:TableCompCustomControl>"),
   Designer(typeof(CompCntrlDesigner))]
   public class TableCompCustomControl : Control, INamingContainer
   {
      private HtmlTable table;

      // properties to access dimensions of HTML table
      int xDim;
      public int X
      {
         get
         {        
            return xDim;
         }
         set
         {            
            xDim =  value;
         }
      }

      int yDim;
      public int Y
      {
         get
         {            
            return yDim;
         }
         set
         {            
            yDim  = value;
         }
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }

      protected override void CreateChildControls()
      {
         Controls.Clear();
         BuildHeader();
         BuildTable(X,Y);
      }

      private void BuildHeader()
      {
         StringBuilder sb = new StringBuilder();
         sb.Append("TableCompCustomControl<br>");
         sb.Append("X:");
         sb.Append(X.ToString());
         sb.Append("&nbsp;");
         sb.Append("Y:");
         sb.Append(Y.ToString());
         sb.Append("&nbsp;");

         HtmlGenericControl header = new HtmlGenericControl("h3");
         header.InnerHtml = sb.ToString();
         Controls.Add(header);
      }

      private void BuildTable(int xDim, int yDim)
      {
         HtmlTableRow row;
         HtmlTableCell cell;
         HtmlGenericControl content;

         // create <TABLE border=1>
         table = new HtmlTable();
         table.Border = 1;

         for (int y=0; y < Y; y++)
         {
            // create <TR>
            row = new HtmlTableRow();

            for (int x=0; x < X; x++)
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
            table.Rows.Add(row);
         }
         Controls.Add(table);
      }
   }
}
