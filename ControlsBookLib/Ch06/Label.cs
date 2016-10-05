// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: Label.cs
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
   [ToolboxData("<{0}:Label runat=server></{0}:Label>"),
   DefaultProperty("Text")]
   public class Label : WebControl
   {
      public Label() : base(HtmlTextWriterTag.Span)
      {
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

      override protected void RenderContents(HtmlTextWriter writer)
      {
         writer.Write(Text);
      }
   }
}
