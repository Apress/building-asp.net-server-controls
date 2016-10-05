// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: BuilderMenu.cs
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
   [ParseChildren(false),Designer(typeof(CompCntrlDesigner))]
   [ControlBuilder(typeof(MenuControlBuilder))]
   [ToolboxData("<{0}:BuilderMenu runat=server></{0}:BuilderMenu>")]
   public class BuilderMenu : WebControl, INamingContainer
   {
      public BuilderMenu() : base(HtmlTextWriterTag.Div)
      {
      }

      private ArrayList menuData = new ArrayList();
      public ArrayList MenuItems
      {
         get
         {
            return menuData;
         }
      }

      protected override void AddParsedSubObject(Object obj)
      {
         if (obj is MenuItemData)
         {
            menuData.Add(obj);
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
         int count = menuData.Count;
         for (int index = 0; index < count; index++)
         {
            MenuItemData itemdata = (MenuItemData) menuData[index];
            CreateMenuItem(itemdata.Title, itemdata.Url,
               itemdata.ImageUrl, itemdata.Target);

            if ((count > 1) && (index < count -1))
            {
               Controls.Add(new LiteralControl(" | "));
            }
         }
      }

      override protected void CreateChildControls()
      {
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
   }
}
