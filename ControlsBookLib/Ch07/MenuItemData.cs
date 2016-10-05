// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: MenuItemData.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;

namespace ControlsBookLib.Ch07
{
   [TypeConverter(typeof(ExpandableObjectConverter))]
   public class MenuItemData
   {
      public MenuItemData()
      {
         this.Title = "";
         this.Url = "";
         this.ImageUrl = "";
         this.Target = "";
      }

      public MenuItemData(string title, string url, string imageUrl, string target)
      {
         this.Title = title;
         this.Url = url;
         this.ImageUrl = imageUrl;
         this.Target = target;
      }

      //Override this method to display just MenuItemData instead of fully qualified type 
      //in the custom collection editor
      public override string ToString()
      {
         return "MenuItemData";
      }

      private string title;
      [NotifyParentProperty(true)]
      public string Title
      {
         get
         {
            return title;
         }
         set
         {
            title = value;
         }
      }

      private string url;
      [NotifyParentProperty(true)]
      public string Url
      {
         get
         {
            return url;
         }
         set
         {
            url = value;
         }
      }

      public string imageUrl;
      [NotifyParentProperty(true)]
      public string ImageUrl
      {
         get
         {
            return imageUrl;
         }
         set
         {
            imageUrl = value;
         }
      }

      public string target;
      [NotifyParentProperty(true)]
      public string Target
      {
         get
         {
            return target;
         }
         set
         {
            target = value;
         }
      }
   }
}