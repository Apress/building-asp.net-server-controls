// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ResultItemCollection.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Collections;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Strongly typed collection of ResultItem controls
   /// </summary>
   public class ResultItemCollection : CollectionBase
   {
      /// <summary>
      /// Constructor to populate collection from an ArrayList
      /// </summary>
      /// <param name="list">ArrayList of ResultItem controls</param>
      public ResultItemCollection(ArrayList list)
      {
         foreach (object item in list)
         {
            if (item is ResultItem)
               List.Add(item);
         }
      }

      /// <summary>
      /// Add ResultItem control to collection
      /// </summary>
      /// <param name="item">ResultItem control</param>
      /// <returns>Zero based index of added ResultItem in colleciton</returns>
      public int Add(ResultItem item)
      {
         return List.Add(item);
      }

      /// <summary>
      /// Add ResultItem control to collection at specified index
      /// </summary>
      /// <param name="index">Zero based index</param>
      /// <param name="item">ResultItem control</param>
      public void Insert(int index, ResultItem item)
      {
         List.Insert(index, item);
      }

      /// <summary>
      /// Remove ResultItem from collection
      /// </summary>
      /// <param name="item">ResultItem control</param>
      public void Remove(ResultItem item)
      {
         List.Remove(item);
      }

      /// <summary>
      /// Check for presense of ResultItem control in collection
      /// </summary>
      /// <param name="item">ResultItem control</param>
      /// <returns>bool value result of check</returns>
      public bool Contains(ResultItem item)
      {
         return List.Contains(item);
      }

      /// <summary>
      /// Returns zero based index of ResultItem control in collection
      /// </summary>
      /// <param name="item">ResultItem control</param>
      /// <returns>Zero based index of ResultItem control in collection</returns>
      public int IndexOf(ResultItem item)
      {
         return List.IndexOf(item);
      }

      /// <summary>
      /// Get ResultItem control at index
      /// </summary>
      public ResultItem this[int index]
      {
         get
         {
            return (ResultItem) List[index];
         }
         set
         {
            List[index] = value;
         }
      }

      /// <summary>
      /// Copy this ResultItemCollection to another starting at index position
      /// </summary>
      /// <param name="col">ResultItemCollection to copy to</param>
      /// <param name="index">Starting index to begin copy operations</param>
      public void CopyTo(ResultItemCollection col, int index)
      {
         for (int i=index; i < List.Count; i++)
         {
            col.Add(this[i]);
         }
      }
   }
}