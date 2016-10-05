// Title: Building ASP.NET Server Controls
//
// Chapter: 3 - Building Server Controls
// File: TableCustomControl.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;

namespace ControlsBookLib.Ch03
{
   [ToolboxData("<{0}:TableCustomControl runat=server></{0}:TableCustomControl>")]
   public class TableCustomControl : Control
   {
      // variables to hold dimensions of HTML table
      private int yDim = 1;
      private int xDim = 1;

      // properties to access dimensions of HTML table
      public int X
      {
         get
         {
            return xDim;
         }
         set
         {
            xDim = value;
         }
      }
      public int Y
      {
         get
         {
            return yDim;
         }
         set
         {
            yDim = value;
         }
      }

      protected override void Render(HtmlTextWriter writer)
      {
         base.Render(writer);

         RenderHeader(writer);
         RenderTable(writer,X,Y);
      }

      private void RenderHeader(HtmlTextWriter writer)
      {
         // write just <H3
         writer.WriteBeginTag("h3");
         // write >
         writer.Write(HtmlTextWriter.TagRightChar);
         writer.Write("TableCustomControl");
         // write <br>
         writer.WriteFullBeginTag("br");
         writer.Write("X:" + X.ToString() + "&nbsp;");
         writer.WriteLine("Y:" + Y.ToString() + "&nbsp;");
         // write </h3>
         writer.WriteEndTag("h3");
      }

      private void RenderTable(HtmlTextWriter writer, int xDim, int yDim)
      {
         // write <TABLE border="1">
         writer.AddAttribute(HtmlTextWriterAttribute.Border,"1");
         writer.RenderBeginTag(HtmlTextWriterTag.Table);

         for (int y=0; y < yDim; y++)
         {
            // write <TR>
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            for (int x=0; x < xDim; x++)
            {
               // write <TD cellspacing="1">
               writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing,"1");
               writer.RenderBeginTag(HtmlTextWriterTag.Td);

               // write <SPAN>
               writer.RenderBeginTag(HtmlTextWriterTag.Span);
               writer.Write("X:" + x.ToString());
               writer.Write("Y:" + y.ToString());
               // write </SPAN>
               writer.RenderEndTag();

               // write </TD>
               writer.RenderEndTag();
            }
            // write </TR>
            writer.RenderEndTag();
         }
         // write </TABLE>
         writer.RenderEndTag();
      }
   }
}
