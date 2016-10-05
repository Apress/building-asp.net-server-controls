// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: HtmlMCTextBoxAdapter.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI.MobileControls;
using System.Web.UI.MobileControls.Adapters;
using ControlsBookLib.Ch11;

namespace ControlsBookLib.Ch11.Adapters
{
   public class HtmlMCTextBoxAdapter : HtmlControlAdapter
   {
      protected new MCTextBox Control
      {
         get
         {
            return (MCTextBox)base.Control;
         }
      }

      public override void Render(HtmlMobileTextWriter writer)
      {
         // write out the HTML tag

         writer.Write("<input name=\""+Control.UniqueID+"\" ");         
         writer.Write("value=\"" + Control.Text + "\" ");
         if (Control.Password)
         {
            writer.Write("type=\"password\" ");
         }
         if (Control.Size != 0)
         {
            writer.Write("size=\""+Control.Size+"\" ");
         }
         writer.Write("/>");

         if (Control.BreakAfter)
         {
            writer.Write("<br>");
         }
      }
   }
}