// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: TitledThumbnailDesigner.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using ControlsBookLib.Ch12;

namespace ControlsBookLib.Ch12.Design
{
   public class TitledThumbnailDesigner : CompCntrlDesigner  
   {
      private DesignerVerbCollection designTimeVerbs;
      public override DesignerVerbCollection Verbs 
      {
         get 
         {
            if ( null == designTimeVerbs) 
            {
               designTimeVerbs = new DesignerVerbCollection();
               designTimeVerbs.Add(new DesignerVerb("Property Builder...", new EventHandler(this.OnPropertyBuilder)));
            }
            return designTimeVerbs;
         }
      }

      private void OnPropertyBuilder(object sender, EventArgs e) 
      {
         TitledThumbnailComponentEditor TitledThumbnailPropsEditor = new TitledThumbnailComponentEditor();
         TitledThumbnailPropsEditor.EditComponent(Component);
      }

      public override void Initialize(IComponent comp) 
      {
         if (!(comp is TitledThumbnail)) 
         {
            throw new ArgumentException("Must be a TitledThumbnail component.", "component");
         }
         base.Initialize(comp);
      }

      public override string GetDesignTimeHtml()
      {
         ControlCollection cntrls = ((Control)Component).Controls;
         if (((TitledThumbnail)Component).ImageUrl == "")
         {
            return CreatePlaceHolderDesignTimeHtml("Set ImageUrl to URL of desired thumbnail image.");
         }
         else
         {
            return base.GetDesignTimeHtml();
         }
      }
   }
}