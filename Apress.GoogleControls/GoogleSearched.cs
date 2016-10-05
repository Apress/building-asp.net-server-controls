// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: GoogleSearched.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Custom event class for passing GoogleSearchResult query info
   /// between GoogleLib Search and Result controls
   /// </summary>
   public class GoogleSearchedEventArgs : EventArgs
   {
      private Service.GoogleSearchResult result;

      /// <summary>
      /// Constructor for GoogleSearchEventArgs
      /// </summary>
      /// <param name="result">Results from search of Google web service</param>
      public GoogleSearchedEventArgs(Service.GoogleSearchResult result)
      {
         this.result = result;
      }

      /// <summary>
      /// Results from search of Google web service
      /// </summary>
      public Service.GoogleSearchResult Result
      {
         get
         {
            return result;
         }
      }
   }

   /// <summary>
   /// Delegate for notifying interested parties of Google search results
   /// </summary>
   public delegate void GoogleSearchedEventHandler(object sender, GoogleSearchedEventArgs e);
}