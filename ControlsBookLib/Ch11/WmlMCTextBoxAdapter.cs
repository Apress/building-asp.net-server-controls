// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: WmlMCTextBoxAdapter.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI.MobileControls;
using System.Web.UI.MobileControls.Adapters;
using ControlsBookLib.Ch11;

namespace ControlsBookLib.Ch11.Adapters
{
   public class WmlMCTextBoxAdapter : WmlControlAdapter
   {
      protected new MCTextBox Control
      {
         get
         {
            return (MCTextBox)base.Control;
         }
      }

      public override void Render(WmlMobileTextWriter writer)
      {
         string Format;

         if (Control.Numeric)
         {
            Format = "*N"; //Set format to any number of numeric characters
         }
         else
         {
            Format = "*M"; //Set format to any number of characters
         }
         writer.RenderTextBox(Control.UniqueID,Control.Text,Format,Control.Title,
            Control.Password,Control.Size,Control.MaxLength,false,Control.BreakAfter);
      }
   }
}