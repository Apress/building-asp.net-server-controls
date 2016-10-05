// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ResultItem.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Enum which indicates what type of content/template/styles the ResultItem control represents
   /// </summary>
   public enum ResultItemType
   {
      /// <summary>
      /// Represents top of control output
      /// </summary>
      Header = 0,

      /// <summary>
      /// Represents status section below header
      /// </summary>
      Status,

      /// <summary>
      /// Represents search result item output
      /// </summary>
      Item,

      /// <summary>
      /// Represents search result alternating item output
      /// </summary>
      AlternatingItem,

      /// <summary>
      /// Represents separation between search result item or alternating item output
      /// </summary>
      Separator,

      /// <summary>
      /// Represents paging area below search result items
      /// </summary>
      Pager,

      /// <summary>
      /// Represents bottom of control output below paging area
      /// </summary>
      Footer
   }

   /// <summary>
   /// Primary child control of Result that contains all of the various templates
   /// when instantiated.
   /// </summary>
   public class ResultItem : WebControl, INamingContainer
   {
      private object dataItem;
      private ResultItemType itemType;
      private int itemIndex;

      /// <summary>
      /// Default constructor of ResultItem control
      /// </summary>
      /// <param name="index">Index of control in collection of ResultItem controls under Result</param>
      /// <param name="type">Type of template the ResultItem control represents</param>
      /// <param name="dataItem">Data from search query</param>
      public ResultItem(int index, ResultItemType type, object dataItem)
      {
         this.itemType = type;
         this.itemIndex = itemIndex;
         this.dataItem = dataItem;
      }

      /// <summary>
      /// Data from search query
      /// </summary>
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

      /// <summary>
      /// Index of control in collection of ResultItem controls under Result
      /// </summary>
      public int ItemIndex
      {
         get
         {
            return itemIndex;
         }
      }

      /// <summary>
      /// Type of template the ResultItem control represents
      /// </summary>
      public ResultItemType ItemType
      {
         get
         {
            return itemType;
         }
      }

   }

   /// <summary>
   /// Delegate signature for raising ResultItemEvent events
   /// </summary>
   public delegate void ResultItemEventHandler(object sender, ResultItemEventArgs e);

   /// <summary>
   /// Specialized EventArgs which contains a RsultItem instance
   /// </summary>
   public class ResultItemEventArgs : EventArgs
   {
      private ResultItem item;

      /// <summary>
      /// Default constructor for ResultItemEventArgs
      /// </summary>
      /// <param name="item">ResultItem control instance</param>
      public ResultItemEventArgs(ResultItem item)
      {
         this.item = item;
      }

      /// <summary>
      /// ResultItem control instance
      /// </summary>
      public ResultItem Item
      {
         get
         {
            return item;
         }
      }
   }
}