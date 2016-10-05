// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: RepeaterItemCollection.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;

namespace ControlsBookLib.Ch07
{
   public class RepeaterItemCollection : CollectionBase
   {
      public RepeaterItemCollection(ArrayList list)
      {
         foreach (object item in list)
         {
            if (item is RepeaterItem)
               List.Add(item);
         }
      }

      public RepeaterItem this[int index]
      {
         get
         {
            return (RepeaterItem) List[index];
         }
      }
   }
}
