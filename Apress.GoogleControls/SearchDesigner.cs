// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: SearchDesigner.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Designer for GoogleLib Search control
   /// </summary>
   public class SearchDesigner : ControlDesigner
   {
      /// <summary>
      /// Initialize the resources of the designer
      /// </summary>
      /// <param name="component">Component which the designer is linked to</param>
      public override void Initialize(IComponent component)
      {
         if (!(component is Control) && !(component is INamingContainer))
         {
            throw new ArgumentException(
               "This control is not a composite control.", "component");
         }
         base.Initialize(component);
      }

      /// <summary>
      /// Provides HTML for the visual designer to display
      /// </summary>
      /// <returns>HTML string based on rendering the control</returns>
      public override string GetDesignTimeHtml()
      {
         ControlCollection cntrls = ((Control)Component).Controls;
         return base.GetDesignTimeHtml();
      }

      /// <summary>
      /// HTML rendered when control has an "empty" configuration
      /// </summary>
      /// <returns>HTML string</returns>
      protected override string GetEmptyDesignTimeHtml()
      {
         return CreatePlaceHolderDesignTimeHtml(
            Component.GetType()+" control.");
      }

      /// <summary>
      /// HTML rendered when control has an "error" in its configuration
      /// </summary>
      /// <returns>HTML string</returns>
      protected override string GetErrorDesignTimeHtml(Exception e)
      {
         return CreatePlaceHolderDesignTimeHtml(
            "There was an error rendering the"+
            this.Component.GetType() +" control."+
            "<br>Exception: "+e.Source+ " Message: "+e.Message);
      }
   }
}