// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: TagDataMenu.cs
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
   // PaseChildren attribute tells the ASP.NET page parser to treat 
   // child content as items to be added to a collection.
   [ParseChildren(true, "MenuItems"),Designer(typeof(CompCntrlDesigner))]
   [ToolboxData("<{0}:TagDataMenu runat=server></{0}:TagDataMenu>")]
   public class TagDataMenu : WebControl, INamingContainer
   {
      public TagDataMenu() : base(HtmlTextWriterTag.Div)
      {
      }

      private MenuItemDataCollection menuData;

      // This collection is automatically populated by ASP.NET because of the
      // ParseChildren attribute on the class
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
      Description("Collection of MenuItemData objects for display"),
      PersistenceMode(PersistenceMode.InnerDefaultProperty),NotifyParentProperty(true)]
      public MenuItemDataCollection MenuItems
      {
         get
         {
            if (menuData == null)
            {
               menuData = new MenuItemDataCollection();
            }
            return menuData;
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

      override protected void CreateChildControls()
      {
         Controls.Clear();
         CreateControlHierarchy();
      }

      private void CreateControlHierarchy()
      {
         int count = MenuItems.Count;
         for (int index = 0; index < count; index++)
         {
            MenuItemData itemdata = (MenuItemData) MenuItems[index];
            CreateMenuItem(itemdata.Title, itemdata.Url,itemdata.ImageUrl, itemdata.Target);

            if ((count > 1) && (index < count -1))
            {
               Controls.Add(new LiteralControl(" | "));
            }
         }
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }
   }
}
