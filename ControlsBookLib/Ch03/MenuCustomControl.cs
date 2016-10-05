// Title: Building ASP.NET Server Controls
//
// Chapter: 3 - Building Server Controls
// File: MenuCustomControl.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;

namespace ControlsBookLib.Ch03
{
   [ToolboxData("<{0}:MenuCustomControl runat=server></{0}:MenuCustomControl>")]
   public class MenuCustomControl : Control
   {
      protected override void Render(HtmlTextWriter writer)
      {
         base.Render(writer);

         writer.WriteLine("<div>");
         RenderMenuItem(writer,"Apress","http://www.apress.com");
         writer.Write(" | ");
         RenderMenuItem(writer,"Microsoft","http://www.microsoft.com");
         writer.Write(" | ");
         RenderMenuItem(writer,"GotDotNet","http://www.gotdotnet.com");
         writer.Write(" | ");
         RenderMenuItem(writer,"ASP.NET","http://asp.net");
         writer.WriteLine("</div>");
      }

      private void RenderMenuItem(HtmlTextWriter writer, string title, string url)
      {
         writer.Write("<span><a href=\"");
         writer.Write(url);
         writer.Write("\">");
         writer.Write(title);
         writer.WriteLine("</a><span>");
      }
   }
}
