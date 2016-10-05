// Title: Building ASP.NET Server Controls
//
// Chapter: 4 - State Management
// File: StatelessLabel.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.ComponentModel;

namespace ControlsBookLib.Ch04
{
   [ToolboxData("<{0}:StatelessLabel runat=server></{0}:StatelessLabel>"),
   DefaultProperty("Text")]
   public class StatelessLabel : Control
   {
      private string text;
      public string Text
      {
         get
         {
            return text;
         }
         set
         {
            text = value;
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
