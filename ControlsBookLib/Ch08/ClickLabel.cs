// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: ClickLabel.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace ControlsBookLib.Ch08
{
   [ToolboxData("<{0}:ClickLabel runat=server></{0}:ClickLabel>"),
   DefaultProperty("ClickText")]
   public class ClickLabel : Label
   {
      public virtual string ClickText
      {
         get
         {
            String clickText = (string)ViewState["clickText"] ;
            return (clickText != null) ? clickText : "" ; 
         }
         set
         { 
            ViewState["clickText"] = value; 
         }
      }

      protected override void OnPreRender(EventArgs e)
      {
         base.OnPreRender(e);

         // Add the onclick client-side event handler to
         // display a JavaScript alert box
         Attributes.Add("onclick","alert('" + ClickText + "');");
      }
   }
}
