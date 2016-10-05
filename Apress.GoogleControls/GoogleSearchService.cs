// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: GoogleSearchService.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

namespace Apress.GoogleControls.Service
{
   using System.Diagnostics;
   using System.Xml.Serialization;
   using System;
   using System.Web.Services.Protocols;
   using System.ComponentModel;
   using System.Web.Services;
   using System.Net;

   /// <summary>
   /// Generated Soap proxy client for calling Google web service
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.ComponentModel.DesignerCategoryAttribute("code")]
   [System.Web.Services.WebServiceBindingAttribute(Name="GoogleSearchBinding", Namespace="urn:GoogleSearch")]
   [System.Xml.Serialization.SoapIncludeAttribute(typeof(ResultElement))]
   internal class GoogleSearchService : System.Web.Services.Protocols.SoapHttpClientProtocol
   {
      /// <summary>
      /// Constructor for Google Soap proxy
      /// </summary>
      /// <param name="googleWebServiceUrl">Url to Google Web service</param>
      /// <param name="proxyUrl">Url to proxy server if code is behind firewall</param>
      public GoogleSearchService(string googleWebServiceUrl, string proxyUrl)
      {
         // default to the current Google Web Service Url if
         // none passed in
         if (googleWebServiceUrl.Length == 0)
            this.Url = "http://api.google.com/search/beta2";
         else
            this.Url = googleWebServiceUrl;

         // only configure proxy settings if passed in
         if (proxyUrl.Length != 0)
         {
            IWebProxy proxy = new WebProxy(proxyUrl, true);
            this.Proxy = proxy;
         }
      }

      /// <summary>
      /// Method for doing Google web service query
      /// </summary>
      /// <param name="key">Provided by Google, this is required for you to access the Google service. Google uses the key for authentication and logging. </param>
      /// <param name="q">Query terms.</param>
      /// <param name="start">Zero-based index of the first desired result. </param>
      /// <param name="maxResults">Number of results desired per query. The maximum value per query is 10.
      /// Note: If you do a query that doesn't have many matches, the actual number of results you get may be smaller than what you request.
      /// </param>
      /// <param name="filter">Activates or deactivates automatic results filtering, which hides very similar results and results that all come from the same Web host. Filtering tends to improve the end user experience on Google, but for your application you may prefer to turn it off. </param>
      /// <param name="restrict">Restricts the search to a subset of the Google Web index, such as a country like "Ukraine" or a topic like "Linux."</param>
      /// <param name="safeSearch">A Boolean value which enables filtering of adult content in the search results.</param>
      /// <param name="lr">Language Restrict - Restricts the search to documents within one or more languages.</param>
      /// <param name="ie">Input Encoding - this parameter has been deprecated and is ignored. All requests to the APIs should be made with UTF-8 encoding.</param>
      /// <param name="oe">Output Encoding - this parameter has been deprecated and is ignored. All requests to the APIs should be made with UTF-8 encoding. </param>
      /// <returns>GoogleSearchResult result output</returns>
      [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:GoogleSearchAction", RequestNamespace="urn:GoogleSearch", ResponseNamespace="urn:GoogleSearch")]
      [return: System.Xml.Serialization.SoapElementAttribute("return")]
      public GoogleSearchResult doGoogleSearch(string key, string q, int start, int maxResults, bool filter, string restrict, bool safeSearch, string lr, string ie, string oe)
      {
         object[] results = this.Invoke("doGoogleSearch", new object[] {
                                                                          key, q, start, maxResults, filter, restrict, safeSearch, lr, ie, oe});
         return ((GoogleSearchResult)(results[0]));
      }
   }

   /// <summary>
   /// Result from querying Google web service
   /// </summary>
   [System.Xml.Serialization.SoapTypeAttribute("GoogleSearchResult", "urn:GoogleSearch")]
   public class GoogleSearchResult
   {
      /// <summary>
      /// A Boolean value indicating whether filtering was performed on the search
      /// results. This will be "true" only if (a) you requested filtering and
      /// (b) filtering actually occurred.
      /// </summary>
      public bool documentFiltering;

      /// <summary>
      /// A text string intended for display to an end user. One of the most common
      /// messages found here is a note that "stop words" were removed from the search automatically.
      /// (This happens for very common words such as "and" and "as.")
      /// </summary>
      public string searchComments;

      /// <summary>
      /// The estimated total number of results that exist for the query.
      /// Note: The estimated number may be either higher or lower than the actual number
      /// of results that exist.
      /// </summary>
      public int estimatedTotalResultsCount;

      /// <summary>
      /// A Boolean value indicating that the estimate is actually the exact value.
      /// </summary>
      public bool estimateIsExact;

      /// <summary>
      /// An array of resultElement items. This corresponds to the actual list of search results
      /// </summary>
      public ResultElement[] resultElements;

      /// <summary>
      /// This is the value of the search request.
      /// </summary>
      public string searchQuery;

      /// <summary>
      /// Indicates the index (1-based) of the first search result in resultElements.
      /// </summary>
      public int startIndex;

      /// <summary>
      /// Indicates the index (1-based) of the last search result in resultElements.
      /// </summary>
      public int endIndex;

      /// <summary>
      /// A text string intended for display to the end user. It provides instructive suggestions on how to use Google.
      /// </summary>
      public string searchTips;

      /// <summary>
      /// An array of directoryCategory items. This corresponds to the ODP directory matches for this search.
      /// </summary>
      public DirectoryCategory[] directoryCategories;

      /// <summary>
      /// Text, floating-point number indicating the total server time to return the search results, measured in seconds.
      /// </summary>
      public System.Double searchTime;
   }

   /// <remarks/>
   [System.Xml.Serialization.SoapTypeAttribute("ResultElement", "urn:GoogleSearch")]
   public class ResultElement
   {
      /// <summary>
      /// If the search result has a listing in the ODP directory, the ODP summary appears here as a text string.
      /// </summary>
      public string summary;

      /// <summary>
      /// The URL of the search result, returned as text, with an absolute URL path.
      /// </summary>
      public string URL;

      /// <summary>
      /// A snippet which shows the query in context on the URL where it appears. This is formatted HTML and usually includes bold tags within it. Note that the query term does not always appear in the snippet. Note: Query terms will be in highlighted in bold in the results, and line breaks will be included for proper text wrapping.
      /// </summary>
      public string snippet;

      /// <summary>
      /// The title of the search result, returned as HTML.
      /// </summary>
      public string title;

      /// <summary>
      /// Text (Integer + "k"). Indicates that a cached version of the Url is available; size is indicated in kilobytes.
      /// </summary>
      public string cachedSize;

      /// <summary>
      /// Boolean indicating that the "related:" query term is supported for this URL.
      /// </summary>
      public bool relatedInformationPresent;

      /// <summary>
      /// When filtering occurs, a maximum of two results from any given host is returned.
      /// When this occurs, the second resultElement that comes from that host contains the host name in this parameter.
      /// </summary>
      public string hostName;

      /// <summary>
      /// See directoryTitle.
      /// </summary>
      public DirectoryCategory directoryCategory;

      /// <summary>
      /// If the URL for this resultElement is contained in the ODP directory, the title that appears in the directory appears here as a text string.
      /// Note that the directoryTitle may be different from the URL's title.
      /// </summary>
      public string directoryTitle;
   }

   /// <remarks/>
   [System.Xml.Serialization.SoapTypeAttribute("DirectoryCategory", "urn:GoogleSearch")]
   public class DirectoryCategory
   {
      /// <summary>
      /// Text, containing the ODP directory name for the current ODP category.
      /// </summary>
      public string fullViewableName;

      /// <summary>
      /// Specifies the encoding scheme of the directory information.
      /// </summary>
      public string specialEncoding;
   }
}