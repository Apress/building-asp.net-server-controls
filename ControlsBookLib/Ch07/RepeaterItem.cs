// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: RepeaterItem.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsBookLib.Ch07
{
   public class RepeaterItem : Control, INamingContainer
   {
      [ToolboxItem(false)]
      public RepeaterItem(int itemIndex, ListItemType itemType, object dataItem)
      {
         this.itemIndex = itemIndex;
         this.itemType = itemType;
         this.dataItem = dataItem;
      }

      private object dataItem;
      public object DataItem
      {
         get
         {
            return dataItem;
         }
         set
         {
            dataItem = value;
         }
      }

      private int itemIndex;
      public int ItemIndex
      {
         get
         {
            return itemIndex;
         }
      }

      private ListItemType itemType;
      public ListItemType ItemType
      {
         get
         {
            return itemType;
         }
      }

      protected override bool OnBubbleEvent(object source, EventArgs e)
      {
         CommandEventArgs ce = e as CommandEventArgs;

         if (ce != null)
         {
            RepeaterCommandEventArgs rce = new RepeaterCommandEventArgs(this, source, ce);
            RaiseBubbleEvent(this, rce);

            return true;
         }
         else
            return false;
      }
   }

   public delegate void RepeaterItemEventHandler(object o, RepeaterItemEventArgs rie);

   public class RepeaterItemEventArgs : EventArgs
   {
      public RepeaterItemEventArgs(RepeaterItem item)
      {
         this.item = item;
      }

      private RepeaterItem item;
      public RepeaterItem Item
      {
         get
         {
            return item;
         }
      }
   }
}
