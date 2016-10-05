// Title: Building ASP.NET Server Controls
//
// Chapter: 3 - Building Server Controls
// File: TextBox3d.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;

namespace ControlsBookLib.Ch03
{
   [ToolboxData("<{0}:TextBox3d runat=server></{0}:TextBox3d>"),
   ToolboxBitmap(typeof(ControlsBookLib.Ch03.TextBox3d),"ControlsBookLib.Ch03.TextBox3d.bmp")]   
   public class TextBox3d : TextBox// Inherit from rich control
   {
      // Private member to store value
      private bool _threeD;

      public TextBox3d()
      {
         _threeD = true ;
      }

      // Custom property to set 3D appearance
      [DescriptionAttribute("Set to true for 3d appearance"),DefaultValue("True")]
      public bool Enable3D
      {
         get
         {
            return _threeD;
         }
         set
         {
            _threeD = value;
         }
      }

      protected override void Render(HtmlTextWriter output)
      {
         // Add DHTML style attribute
         if (_threeD)
            output.AddStyleAttribute("FILTER","progid:DXImageTransform.Microsoft.dropshadow(OffX=2, OffY=2, Color='gray', Positive='true'");

         base.Render(output);
      }
   }
}
