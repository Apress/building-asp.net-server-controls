// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ResultDesigner.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Designer class for the Result server control
   /// </summary>
   public class ResultDesigner : TemplatedControlDesigner
   {
      private TemplateEditingVerb[] templateVerbs;
      private bool templateVerbsDirty = true;

      /// <summary>
      /// Initialize the resources of the designer
      /// </summary>
      /// <param name="component">Component which the designer is linked to</param>
      public override void Initialize(IComponent component)
      {
         if (!(component is Result) && !(component is INamingContainer))
         {
            throw new ArgumentException(
               "This control is not a Result control.", "component");
         }
         base.Initialize(component);
      }

      /// <summary>
      /// Determines if designer allows control to be resized in editor
      /// </summary>
      public override bool AllowResize 
      {
         get 
         {
            // When templates are not defined, render a read-only fixed-
            // size block. Once templates are defined or are being edited, 
            // the control allows resizing
            return TemplatesExist || InTemplateMode;
         }
      }

      /// <summary>
      /// Provides HTML for the visual designer to display
      /// </summary>
      /// <returns>HTML string based on rendering the control with a dummy data source</returns>
      public override string GetDesignTimeHtml() 
      {
         Result control = (Result)Component;
         string designTimeHTML = null;

         // bind Result control to dummy data source
         // that has the appropriate page size
         control.DataSource = 
            ResultDummyDataSource.GetGoogleSearchResults(control.PageSize);
         control.DataBind();

         // let base class designer call Render() on
         // data-bound control to get HTML
         designTimeHTML = base.GetDesignTimeHtml();

         return designTimeHTML;
      }

      /// <summary>
      /// HTML rendered when control has an "empty" configuration
      /// </summary>
      /// <returns>HTML string</returns>
      protected override string GetEmptyDesignTimeHtml() 
      {
         string text;

         if (CanEnterTemplateMode) 
         {
            text = "Right-click and choose a set of templates to edit their content.";
         }
         else 
         {
            text = "Switch to HTML view to edit the control's templates.";
         }
         return CreatePlaceHolderDesignTimeHtml(text);
      }

      /// <summary>
      /// HTML rendered when control has an "error" in its configuration
      /// </summary>
      /// <returns>HTML string</returns>
      protected override string GetErrorDesignTimeHtml(Exception e) 
      {
         return CreatePlaceHolderDesignTimeHtml("There was an error rendering the control.<br>Check to make sure all properties are valid.");
      }


      /// <summary>
      /// Checks to see if any templates have their content set to a non-empty value
      /// </summary>
      protected bool TemplatesExist 
      {
         get 
         {
            return (
               ((Result)Component).HeaderTemplate != null ||
               ((Result)Component).StatusTemplate != null ||
               ((Result)Component).ItemTemplate != null ||
               ((Result)Component).AlternatingItemTemplate != null ||
               ((Result)Component).SeparatorTemplate != null ||
               ((Result)Component).FooterTemplate != null
            );
         }
      }

      /// <summary>
      /// Creates a template editing frame for a specified designer verb. 
      /// </summary>
      /// <param name="verb">The template editing verb to create a template editing frame for. </param>
      /// <returns>ITemplateEditingFrame-based frame instance</returns>
      protected override ITemplateEditingFrame CreateTemplateEditingFrame(TemplateEditingVerb verb) 
      {
         ITemplateEditingService teService = (ITemplateEditingService)GetService(typeof(ITemplateEditingService));

         string [] templateNames = new string[1];
         Style[] templateStyles = new Style[1];

         switch (verb.Index)
         {
            case 0:
               templateNames[0] = "HeaderTemplate";
               templateStyles[0] = ((Result)Component).HeaderStyle;
               break;
            case 1:
               templateNames[0] = "StatusTemplate";
               templateStyles[0] = ((Result)Component).StatusStyle;
               break;
            case 2:
               templateNames[0] = "ItemTemplate";
               templateStyles[0] = ((Result)Component).ItemStyle;
               break;
            case 3:
               templateNames[0] = "AlternatingItemTemplate";
               templateStyles[0] = ((Result)Component).AlternatingItemStyle;
               break;
            case 4:
               templateNames[0] = "SeparatorTemplate";
               templateStyles[0] = ((Result)Component).SeparatorStyle;
               break;
            case 5:
               templateNames[0] = "FooterTemplate";
               templateStyles[0] = ((Result)Component).FooterStyle;
               break;
         }

         ITemplateEditingFrame editingFrame =
            teService.CreateFrame(this, verb.Text, templateNames, 
               ((Result)Component).ControlStyle, templateStyles);
         return editingFrame;
      }

      /// <summary>
      /// Release designer resources via explicit invocation of IDispose pattern
      /// </summary>
      /// <param name="disposing">called explicitly (true) or implicitly as part of Finalization (false) </param>
      protected override void Dispose(bool disposing) 
      {
         if (disposing) 
         {
            DisposeTemplateVerbs();
         }
         base.Dispose(disposing);
      }

      private void DisposeTemplateVerbs() 
      {
         if (templateVerbs != null) 
         {
            templateVerbs[0].Dispose();
            templateVerbs[1].Dispose();
            templateVerbs[2].Dispose();
            templateVerbs[3].Dispose();
            templateVerbs[4].Dispose();
            templateVerbs[5].Dispose();

            templateVerbs = null;
            templateVerbsDirty = true;
         }
      }

      /// <summary>
      /// Gets array of Template editing verbs from cache
      /// </summary>
      /// <returns>TemplateEditingVerb array</returns>
      protected override TemplateEditingVerb[] GetCachedTemplateEditingVerbs() 
      {
         if (templateVerbsDirty == true) 
         {
            DisposeTemplateVerbs();

            templateVerbs = new TemplateEditingVerb[6];
            templateVerbs[0] = new TemplateEditingVerb("Header Template", 0, this);
            templateVerbs[1] = new TemplateEditingVerb("Status Template", 1, this);
            templateVerbs[2] = new TemplateEditingVerb("Item Template", 2, this);
            templateVerbs[3] = new TemplateEditingVerb("AlternatingItem Template", 3, this);
            templateVerbs[4] = new TemplateEditingVerb("Separator Template", 4, this);
            templateVerbs[5] = new TemplateEditingVerb("Footer Template", 5, this);

            templateVerbsDirty = false;
         }

         return templateVerbs;
      }

      /// <summary>
      /// Gets the current string value of a selected template in design mode
      /// </summary>
      /// <param name="editingFrame">The template editing frame to retrieve the content of.</param>
      /// <param name="templateName">Name of the template</param>
      /// <param name="allowEditing">Can the template be changed or is it read-only.</param>
      /// <returns></returns>
      public override string GetTemplateContent(ITemplateEditingFrame editingFrame, string templateName, out bool allowEditing) 
      {
         allowEditing = true;
         ITemplate template = null;
         string templateContent = String.Empty;

         if (templateName.Equals("HeaderTemplate") && editingFrame.Verb.Index == 0)
         {
            template = ((Result)Component).HeaderTemplate;
         }
         else if (templateName.Equals("StatusTemplate") && editingFrame.Verb.Index == 1)
         {
            template = ((Result)Component).StatusTemplate;
         }
         else if (templateName.Equals("ItemTemplate") && editingFrame.Verb.Index == 2)
         {
            template = ((Result)Component).ItemTemplate;
         }
         else if (templateName.Equals("AlternatingItemTemplate") && editingFrame.Verb.Index == 3)
         {
            template = ((Result)Component).AlternatingItemTemplate;
         }
         else if (templateName.Equals("SeparatorTemplate") && editingFrame.Verb.Index == 4)
         {
            template = ((Result)Component).SeparatorTemplate;
         }
         else if (templateName.Equals("FooterTemplate") && editingFrame.Verb.Index == 5)
         {
            template = ((Result)Component).FooterTemplate;
         }

         if (template != null) 
         {
            templateContent = GetTextFromTemplate(template);
         }

         return templateContent;
      }

     
      /// <summary>
      /// Called when the component has been changed
      /// </summary>
      /// <param name="sender">Sender of the event</param>
      /// <param name="e">Event data including member that was changed.</param>
      public override void OnComponentChanged(object sender, ComponentChangedEventArgs e) 
      {
         if (e.Member != null) 
         {
            string memberName = e.Member.Name;
            if (memberName.Equals("HeaderStyle") ||
               memberName.Equals("StatusStyle") ||
               memberName.Equals("ItemStyle") ||
               memberName.Equals("AlternatingItemStyle") ||
               memberName.Equals("SeparatorStyle") ||
               memberName.Equals("PagerStyle") ||
               memberName.Equals("FooterStyle")) 
            {
               OnStylesChanged();
            }
         }

         base.OnComponentChanged(sender, e);
      }

      /// <summary>
      /// Override of method that is invoked when control styles change
      /// </summary>
      protected void OnStylesChanged() 
      {
         OnTemplateEditingVerbsChanged();
      }

      /// <summary>
      /// Override of method that is invoked when template editing verbs change
      /// </summary>
      protected void OnTemplateEditingVerbsChanged() 
      {
         templateVerbsDirty = true;
      }

      /// <summary>
      /// Sets the current string value of a selected template in design mode
      /// </summary>
      /// <param name="editingFrame">The template editing frame to retrieve the content of.</param>
      /// <param name="templateName">Name of the template</param>
      /// <param name="templateContent">Content retrieved from frame in designer.</param>
      /// <returns></returns>
      public override void SetTemplateContent(ITemplateEditingFrame editingFrame, string templateName, string templateContent) 
      {

         ITemplate template = null;

         if ((templateContent != null) && (templateContent.Length != 0)) 
         {
            template = GetTemplateFromText(templateContent);
         }

         if (templateName.Equals("HeaderTemplate") && editingFrame.Verb.Index == 0)
         {
            ((Result)Component).HeaderTemplate = template;
         }
         else if (templateName.Equals("StatusTemplate") && editingFrame.Verb.Index == 1)
         {
            ((Result)Component).StatusTemplate = template;
         }
         else if (templateName.Equals("ItemTemplate") && editingFrame.Verb.Index == 2)
         {
            ((Result)Component).ItemTemplate = template;
         }
         else if (templateName.Equals("AlternatingItemTemplate") && editingFrame.Verb.Index == 3)
         {
            ((Result)Component).AlternatingItemTemplate = template;
         }
         else if (templateName.Equals("SeparatorTemplate") && editingFrame.Verb.Index == 4)
         {
            ((Result)Component).SeparatorTemplate = template;
         }
         else if (templateName.Equals("FooterTemplate") && editingFrame.Verb.Index == 5)
         {
            ((Result)Component).FooterTemplate = template;
         }


      }
   }
}
