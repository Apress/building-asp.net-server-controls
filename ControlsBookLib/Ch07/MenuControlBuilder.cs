// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: MenuControlBuilder.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Collections;

namespace ControlsBookLib.Ch07
{
   public class MenuControlBuilder : ControlBuilder
   {
      public override Type GetChildControlType(String tagName,
         IDictionary attributes)
      {
         if (String.Compare(tagName, "data", true) == 0)
         {
            return typeof(MenuItemData);
         }

         return null;
      }

      public override void AppendLiteralString(string s)
      {
         s.Trim();
         // Ignores literals between tags.
      }
   }
}
