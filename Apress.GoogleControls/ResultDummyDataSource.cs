// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ResultDummyDataSource.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
namespace Apress.GoogleControls
{
   /// <summary>
   /// Provides a fictional Data source to show control rendering of 
   /// templates while control is in design-time mode
   /// </summary>
   public class ResultDummyDataSource
   {
      private const int TotalResultsCount = 100;

      /// <summary>
      /// Returns a Service.GoogleSearchResult data set that is valid
      /// according to web service guidelines
      /// </summary>
      /// <param name="pageSize">page size of the Service.GoogleSearchResult set</param>
      /// <returns>Service.GoogleSearchResult instance with Service.resultElement 
      /// entries present according to page size</returns>
      public static Service.GoogleSearchResult GetGoogleSearchResults(int pageSize)
      {
         Service.GoogleSearchResult result = new Service.GoogleSearchResult();

         result.estimatedTotalResultsCount = TotalResultsCount;
         result.estimateIsExact = true;
         result.documentFiltering = false;
         result.startIndex = 1;
         result.endIndex = pageSize;
         result.searchTime = 0.09;
         result.searchQuery = "Result Control";
         result.searchComments = "";
         result.searchTips = "";
         result.directoryCategories = new Service.DirectoryCategory[1];
         result.directoryCategories[0] = ResultDummyDataSource.GetDirectoryCategory();

         // fill up 10 result elements
         result.resultElements = new Service.ResultElement[pageSize];
         for (int i = 0; i < pageSize; i++)
         {
            result.resultElements[i] = GetResultElement(i);
         }

         return result;
      }

      /// <summary>
      /// Returns a valid Service.ResultElement instance
      /// </summary>
      /// <param name="index">Index to help create title and url</param>
      /// <returns>Fully populated Service.ResultElement instance</returns>
      public static Service.ResultElement GetResultElement(int index)
      {
         Service.ResultElement elem = new Service.ResultElement();
         elem.title = "Result Control " + index;
         elem.URL = "http://apress.com/resultcontrol" + index;
         elem.summary = "Summary";
         elem.snippet = "Snippet";
         elem.hostName = "apress";
         elem.cachedSize = "2k";
         elem.relatedInformationPresent = false;
         elem.directoryTitle = "Test";
         elem.directoryCategory = ResultDummyDataSource.GetDirectoryCategory();
         return elem;
      }

      /// <summary>
      /// Returns a populated Service.DirectoryCategory instance
      /// </summary>
      /// <returns>Fully populated Service.DirectoryCategory instance</returns>
      public static Service.DirectoryCategory GetDirectoryCategory()
      {
         Service.DirectoryCategory dirCat = new Service.DirectoryCategory();
         dirCat.fullViewableName = "Test Category";
         dirCat.specialEncoding = "";
         return dirCat;
      }
   }
}
