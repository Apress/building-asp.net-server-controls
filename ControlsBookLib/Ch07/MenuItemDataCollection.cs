// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: MenuItemDataCollection.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch07
{
   [Editor(typeof(ControlsBookLib.Ch12.Design.MenuItemDataCollectionEditor), typeof(UITypeEditor))]
   public sealed class MenuItemDataCollection : IList
   {
      private ArrayList menuItems;
      internal MenuItemDataCollection()
      {
         menuItems = new ArrayList();
      }

      public MenuItemData this[int index]
      {
         get
         {
            return (MenuItemData)menuItems[index];
         }
      }

      object IList.this[int index]
      {
         get
         {
            return menuItems[index];
         }
         set
         {
            menuItems[index] = (MenuItemData)value;
         }
      }

      public int Add(MenuItemData item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }

         menuItems.Add(item);
         return menuItems.Count - 1;
      }

      public void Clear()
      {
         menuItems.Clear();
      }

      public bool Contains(MenuItemData item)
      {
         if (item == null)
         {
            return false;
         }
         return menuItems.Contains(item);
      }

      public int IndexOf(MenuItemData item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }
         return menuItems.IndexOf(item);
      }

      public void Insert(int index, MenuItemData item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }

         menuItems.Insert(index,item);
      }

      public void RemoveAt(int index)
      {
         menuItems.RemoveAt(index);
      }

      public void Remove(MenuItemData item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }

         int index = IndexOf(item);
         if (index >= 0)
         {
            RemoveAt(index);
         }
      }

      public IEnumerator GetEnumerator()
      {
         return menuItems.GetEnumerator();
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false) ]
      public int Count
      {
         get
         {
            return menuItems.Count;
         }
      }

      public void CopyTo(Array array, int index)
      {
         menuItems.CopyTo(array,index);
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
      public bool IsSynchronized
      {
         get
         {
            return false;
         }
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false) ]
      public object SyncRoot
      {
         get
         {
            return this;
         }
      }

      bool IList.IsReadOnly
      {
         get
         {
            return false;
         }
      }

      bool IList.IsFixedSize
      {
         get
         {
            return false;
         }
      }

      int IList.Add(object item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }
         if (!(item is MenuItemData))
         {
            throw new ArgumentException("item must be a MenuItemData");
         }

         return Add((MenuItemData)item);
      }

      bool IList.Contains(object item)
      {
         return Contains(item as MenuItemData);
      }

      void IList.Clear()
      {
         Clear();
      }

      int IList.IndexOf(object item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }
         if (!(item is MenuItemData))
         {
            throw new ArgumentException("item must be a MenuItemData");
         }

         return IndexOf((MenuItemData)item);
      }

      void IList.RemoveAt(int index)
      {
         RemoveAt(index);
      }

      void IList.Remove(object item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }
         if (!(item is MenuItemData))
         {
            throw new ArgumentException("item must be a MenuItemData");
         }

         Remove((MenuItemData)item);
      }

      void IList.Insert(int index, object item)
      {
         if (item == null)
         {
            throw new ArgumentNullException("item");
         }
         if (!(item is MenuItemData))
         {
            throw new ArgumentException("item must be a MenuItemData");
         }

         Insert(index, (MenuItemData)item);
      }
   }
}
