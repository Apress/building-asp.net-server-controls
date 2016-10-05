// Title: Building ASP.NET Server Controls
//
// Chapter: 4 - State Management
// File: StatefulLabel.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.ComponentModel;

namespace ControlsBookLib.Ch04
{
   [ToolboxData("<{0}:StatefulLabel runat=server></{0}:StatefulLabel>"),
   DefaultProperty("Text")]
   public class StatefulLabel : Control
   {
      public virtual string Text
      {
         get
         {
            object text = ViewState["Text"];
            if (text == null)
               return string.Empty;
            else
               return (string) text;
         }
         set
         {
            ViewState["Text"] = value;
         }
      }

      override protected void Render(HtmlTextWriter writer)
      {
         base.Render(writer);

         writer.RenderBeginTag(HtmlTextWriterTag.Span);
         writer.Write(Text);
         writer.RenderEndTag();
      }
   }
}
