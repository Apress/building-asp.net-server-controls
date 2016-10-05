// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: CompCntrlDesigner.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

namespace ControlsBookLib.Ch12.Design
{
   public class CompCntrlDesigner : ControlDesigner
   {
      public override void Initialize(IComponent component)
      {
         if (!(component is Control) && !(component is INamingContainer))
         {
            throw new ArgumentException(
               "This control is not a composite control.", "component");
         }
         base.Initialize(component);
      }

      protected override string GetEmptyDesignTimeHtml()
      {
         return CreatePlaceHolderDesignTimeHtml(Component.GetType()+" control.");
      }

      public override string GetDesignTimeHtml()
      {
         ControlCollection cntrls = ((Control)Component).Controls;
         return base.GetDesignTimeHtml();
      }

      protected override string GetErrorDesignTimeHtml(Exception e)
      {
         return CreatePlaceHolderDesignTimeHtml("There was an error rendering the"+
            this.Component.GetType() +" control."+
            "<br>Exception: "+e.Source+ " Message: "+e.Message);
      }
   }
}
