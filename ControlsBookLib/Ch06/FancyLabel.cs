// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: FancyLabel.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace ControlsBookLib.Ch06
{
   [ToolboxData("<{0}:FancyLabel runat=server></{0}:FancyLabel>"),
   DefaultProperty("Text")]
   public class FancyLabel : WebControl
   {
      public FancyLabel() : base(HtmlTextWriterTag.Span)
      {
      }

      public CursorStyle Cursor
      {
         get
         {
            return ((FancyLabelStyle)ControlStyle).Cursor;
         }
         set
         {
            ((FancyLabelStyle)ControlStyle).Cursor = value;
         }
      }

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

      protected override Style CreateControlStyle()
      {
         FancyLabelStyle style = new FancyLabelStyle(ViewState);
         return style;
      }

      override protected void RenderContents(HtmlTextWriter writer)
      {
         writer.Write(Text);
      }
   }
}

