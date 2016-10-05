// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: TemplateMenuDesigner.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using ControlsBookLib.Ch07;

namespace ControlsBookLib.Ch12.Design
{
   public class TemplateMenuDesigner : TemplatedControlDesigner 
   {
      public override void Initialize(IComponent component) 
      {
         if (!(component is TemplateMenu)) 
         {
            throw new ArgumentException("Component must be a TemplateMenu control for this custom designer."
               , "component");
         }
         base.Initialize(component);
      }  
      
      private TemplateEditingVerb[] tmplEditingVerbs;
      protected override TemplateEditingVerb[] GetCachedTemplateEditingVerbs() 
      {
         if (null == tmplEditingVerbs) 
         {
            tmplEditingVerbs = new TemplateEditingVerb[3];
            tmplEditingVerbs[0] = new TemplateEditingVerb("Header Template", 0, this); 
            tmplEditingVerbs[1] = new TemplateEditingVerb("Separator Template", 0, this); 
            tmplEditingVerbs[2] = new TemplateEditingVerb("Footer Template", 0, this); 
         }
         return tmplEditingVerbs;
      }

      public override string GetTemplateContent(ITemplateEditingFrame editFrame, string tmplName, out bool allowTemplateEditing) 
      { 
         allowTemplateEditing = true;
         
         string templateContent = String.Empty;
         if (null  != tmplEditingVerbs)
         {
            if (editFrame.Verb == tmplEditingVerbs[0])
            {
               ITemplate existingTemplate = ((TemplateMenu)Component).HeaderTemplate;

               if (null  != existingTemplate) 
               {
                  templateContent = GetTextFromTemplate(existingTemplate);          
               }
            }

            if (editFrame.Verb == tmplEditingVerbs[1])
            {
               ITemplate existingTemplate = ((TemplateMenu)Component).SeparatorTemplate;

               if (null  != existingTemplate) 
               {
                  templateContent = GetTextFromTemplate(existingTemplate);   
               }
            }

            if (editFrame.Verb == tmplEditingVerbs[2])
            {
               ITemplate existingTemplate = ((TemplateMenu)Component).FooterTemplate;

               if (null  != existingTemplate) 
               {
                  templateContent = GetTextFromTemplate(existingTemplate);    
               }
            }           
         }
         return templateContent;
      }

      public override string GetDesignTimeHtml() 
      {
         if ((null == ((TemplateMenu)Component).HeaderTemplate ) && 
            (null  == ((TemplateMenu)Component).SeparatorTemplate) && 
            (null  == ((TemplateMenu)Component).FooterTemplate))
         {
            return GetEmptyDesignTimeHtml();
         }

         string designTimeHtml = String.Empty;
         try 
         {
            ((TemplateMenu)Component).DataBind();
            designTimeHtml = base.GetDesignTimeHtml(); 
         }
         catch (Exception e) 
         {
            designTimeHtml = GetErrorDesignTimeHtml(e);
         }

         return designTimeHtml;
      }

      public override void OnComponentChanged(object sender, ComponentChangedEventArgs ceArgs) 
      {
         base.OnComponentChanged(sender, ceArgs);

         if (null  != ceArgs.Member) 
         {
            if (ceArgs.Member.Name.Equals("BackColor") ||
               ceArgs.Member.Name.Equals("ForeColor") || 
               ceArgs.Member.Name.Equals("Font")) 
            {
               if (null  != tmplEditingVerbs) 
               {
                  foreach (TemplateEditingVerb verb in tmplEditingVerbs)
                  {
                     verb.Dispose();
                  }
               }
            }
         }
      }
  
      protected override string GetErrorDesignTimeHtml(Exception e) 
      {

         return CreatePlaceHolderDesignTimeHtml("There was an error rendering the TemplateMenu control."+
            "<br>Exception: "+e.Source+ "  Message: "+e.Message);
      }

      public override void SetTemplateContent(ITemplateEditingFrame editingFrame, string tmplName, string tmplContent) 
      {
         if (null  != tmplEditingVerbs)
         {
            if (tmplEditingVerbs[0] == editingFrame.Verb)
            {
               TemplateMenu control = (TemplateMenu)Component;
               ITemplate newHeader  = null;

               if ((null  != tmplContent) && (0  != tmplContent.Length)) 
               {
                  newHeader = GetTemplateFromText(tmplContent);
               }
               control.HeaderTemplate = newHeader;
            }

            if (tmplEditingVerbs[1] == editingFrame.Verb) 
            {
               TemplateMenu control = (TemplateMenu)Component;
               ITemplate newSeparator = null;

               if ((null  != tmplContent) && (0 != tmplContent.Length)) 
               {
                  newSeparator = GetTemplateFromText(tmplContent);
               }
               control.SeparatorTemplate = newSeparator;
            }

            if (tmplEditingVerbs[2] == editingFrame.Verb) 
            {
               TemplateMenu control = (TemplateMenu)Component;
               ITemplate newHeader = null;

               if ((null  != tmplContent) && (0 != tmplContent.Length)) 
               {
                  newHeader = GetTemplateFromText(tmplContent);
               }            
               control.FooterTemplate = newHeader;
            }
         }
      }

      public override bool AllowResize 
      {
         get 
         {
            bool templateExists = null != ((TemplateMenu)Component).HeaderTemplate ||
                                              null != ((TemplateMenu)Component).SeparatorTemplate ||
                                              null != ((TemplateMenu)Component).FooterTemplate;
            return templateExists || InTemplateMode;
         }
      }

      protected override ITemplateEditingFrame CreateTemplateEditingFrame(TemplateEditingVerb verb) 
      {
         ITemplateEditingFrame frame = null;

         if (null  != tmplEditingVerbs)
         {
            ITemplateEditingService tmplEditingService = (ITemplateEditingService)GetService(typeof(ITemplateEditingService));
            if (null  != tmplEditingService) 
            {
               Style style = ((TemplateMenu)Component).ControlStyle;
               if (tmplEditingVerbs[0] == verb)
               {
                  frame = tmplEditingService.CreateFrame(this, verb.Text, new string[] { "Header Template" }, style, null);
               }
               if (tmplEditingVerbs[1] == verb)
               {
                  frame = tmplEditingService.CreateFrame(this, verb.Text, new string[] { "Separator Template" }, style, null);
               }
               if (tmplEditingVerbs[2] == verb) 
               {                  
                  frame = tmplEditingService.CreateFrame(this, verb.Text, new string[] { "Footer Template" }, style, null);
               }
            }
         }
         return frame;
      }

      protected override string GetEmptyDesignTimeHtml() 
      {
         return CreatePlaceHolderDesignTimeHtml("Right-click to edit the TemplateMenu Header, Footer, and Seperator template properties. " + 
            "<br>A default template is used at run-time if the separator Template is not specified at design-time."+
            "<br>The Header and Footer templates are optional.");
      }

      protected override void Dispose(bool disposing) 
      {
         if (disposing) 
         {
            if (null  != tmplEditingVerbs) 
            {
               foreach (TemplateEditingVerb verb in tmplEditingVerbs)
               {
                  verb.Dispose();
               }
            }
         }
         base.Dispose(disposing);
      }   
   }
}