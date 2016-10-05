// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: FancyLabelStyle.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsBookLib.Ch06
{
   public enum CursorStyle
   {
      auto,
      hand,
      crosshair,
      help,
      move,
      text,
      wait
   }

   public class FancyLabelStyle : Style
   {
      public FancyLabelStyle() : base()
      {
      }

      public FancyLabelStyle(StateBag ViewState) : base(ViewState)
      {
      }

      public CursorStyle Cursor
      {
         get
         {
            if (ViewState["cursor"]!= null)
            {
               return (CursorStyle)ViewState["cursor"] ;
            }
            else
            {
               return CursorStyle.auto ;
            }
         }
         set
         {
            ViewState["cursor"] = value;
         }
      }

      override public void CopyFrom(Style style)
      {
         base.CopyFrom(style);

         FancyLabelStyle flstyle = style as FancyLabelStyle;
         if (flstyle != null)
            Cursor = flstyle.Cursor;
      }

      override public void MergeWith(Style style)
      {
         base.MergeWith(style);

         FancyLabelStyle flstyle = style as FancyLabelStyle;

         //Only merge if inbound style is set and current style is not set
         if ((flstyle != null) && (!flstyle.IsEmpty) && (IsEmpty))
            Cursor = flstyle.Cursor;
      }

      override public void Reset()
      {
         base.Reset();

         if (ViewState["cursor"] != null)
         {
            ViewState.Remove("cursor");
         }
      }

      // Hide base class version of IsEmpty using the keyword "new" and provide our own
      // The keyword "internal" limits access to within the assembly only, following the pattern
      // established by the base Style class
      protected internal new bool IsEmpty
      {
         get
         { // Call base class version to get default behavior
            return base.IsEmpty && (ViewState["cursor"] == null);
         }
      }

      override public void AddAttributesToRender(HtmlTextWriter writer, WebControl owner)
      {
         base.AddAttributesToRender(writer, owner); // Ensure base Style class adds its
         // attributes to the output stream
         if (ViewState["cursor"] != null)
         {
            string cursor =
               Enum.Format(typeof(CursorStyle), (CursorStyle)ViewState["cursor"], "G");
            writer.AddStyleAttribute("cursor", cursor);
         }
      }
   }
}
