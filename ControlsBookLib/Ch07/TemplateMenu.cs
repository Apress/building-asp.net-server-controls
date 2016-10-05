// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: TempateMenu.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch07
{
   [ToolboxData("<{0}:TemplateMenu runat=server></{0}:TemplateMenu>"),Designer(typeof(TemplateMenuDesigner))]
   public class TemplateMenu : WebControl, INamingContainer
   {
      private ArrayList menuData;
      public TemplateMenu() : base(HtmlTextWriterTag.Div)
      {
         menuData = new ArrayList();
         menuData.Add(new MenuItemData("Apress","http://www.apress.com","",""));
         menuData.Add(new MenuItemData("Microsoft","http://www.microsoft.com","",""));
         menuData.Add(new MenuItemData("GotDotNet","http://www.gotdotnet.com","",""));
      }
      
      private ITemplate headerTemplate;
      [Browsable(false),Description("The header template"),PersistenceMode(PersistenceMode.InnerProperty),
      TemplateContainer(typeof(BasicTemplateContainer))]
      public ITemplate HeaderTemplate
      {
         get
         { 
            return headerTemplate; 
         }
         set
         { 
            headerTemplate = value; 
         }
      }

      private ITemplate footerTemplate;
      [Browsable(false),Description("The footer template"),PersistenceMode(PersistenceMode.InnerProperty),
      TemplateContainer(typeof(BasicTemplateContainer))]
      public ITemplate FooterTemplate
      {
         get
         { 
            return footerTemplate; 
         }
         set
         { 
            footerTemplate = value; 
         }
      }

      private ITemplate separatorTemplate;
      [Browsable(false),Description("The separator template"),PersistenceMode(PersistenceMode.InnerProperty),
      TemplateContainer(typeof(BasicTemplateContainer))]
      public ITemplate SeparatorTemplate
      {
         get
         { 
            return separatorTemplate; 
         }
         set
         { 
            separatorTemplate = value; 
         }
      }

      private void CreateMenuItem(string title, string url, string target, string imageUrl)
      {
         HyperLink link = new HyperLink();
         link.Text = title;
         link.NavigateUrl = url;
         link.ImageUrl = imageUrl;
         link.Target = target;
         Controls.Add(link);
      }

      private void CreateControlHierarchy()
      {
         if (HeaderTemplate != null)
         {
            BasicTemplateContainer header = new BasicTemplateContainer();
            HeaderTemplate.InstantiateIn(header);
            Controls.Add(header);
            Controls.Add(new LiteralControl("<br>"));
         }

         int count = menuData.Count;
         for (int index = 0; index < count; index++)
         {
            MenuItemData itemdata = (MenuItemData) menuData[index];
            CreateMenuItem(itemdata.Title, itemdata.Url,itemdata.ImageUrl, itemdata.Target);

            if (index != count-1)
            {
               if (SeparatorTemplate != null)
               {
                  BasicTemplateContainer separator = new BasicTemplateContainer();
                  SeparatorTemplate.InstantiateIn(separator);
                  Controls.Add(separator);
               }
               else
               {
                  Controls.Add(new LiteralControl(" | "));
               }
            }
         }

         if (FooterTemplate != null)
         {
            Controls.Add(new LiteralControl("<br>"));
            BasicTemplateContainer footer = new BasicTemplateContainer();
            FooterTemplate.InstantiateIn(footer);
            Controls.Add(footer);
         }
      }

      override protected void CreateChildControls()
      {
         Controls.Clear();
         CreateControlHierarchy();
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }

      public override void DataBind() 
      {
         CreateChildControls();
         ChildControlsCreated = true;

         base.DataBind();
      }
   }
}