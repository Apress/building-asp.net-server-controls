// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: SearchUtil.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Configuration;
using System.Web;
using System.Web.Services.Protocols;

namespace Apress.GoogleControls.Service
{
   /// <summary>
   ///		Utility class for abstracting Google web service proxy work
   /// </summary>
   public class SearchUtil
   {
      const string ConfigSectionName = "system.web/googleControls";      

      /// <summary>
      ///   Static method for searching Google that wraps web service proxy code for easy invocation.
      /// </summary>
      /// <param name="query">Query to Google search web service</param>
      /// <param name="startIndex">Starting index of result set</param>
      /// <param name="maxResults">Maximum number of results to return</param>
      /// <param name="filtering">Turn on Google filtering for relevancy</param>
      /// <returns></returns>
      public static Service.GoogleSearchResult SearchGoogleService(       
      string query, int startIndex, int maxResults, bool filtering)
      {
         string googleLicenseKey = "";
         string googleWebServiceUrl = "";
         string proxyUrl = ""; 

         // get <googleControl> config section from web.config
         // for search settings
         GoogleConfigSection config = 
            ConfigurationSettings.GetConfig(
            ConfigSectionName) as GoogleConfigSection;
         if (config != null)
         {
            googleLicenseKey = config.GoogleLicenseKey;
            googleWebServiceUrl = config.GoogleWebServiceUrl;
            proxyUrl = config.ProxyUrl;
         }	
            // if control is instantiated at runtime config section should be present
         else if (HttpContext.Current != null)
         {
            throw new ConfigurationException(
               "Apress.GoogleControls.Service.SearchUtil cannot find <googleControl> configuration section.");
         }

         // Create a Google Search object
         Service.GoogleSearchService service = 
         new Service.GoogleSearchService(googleWebServiceUrl, proxyUrl);
         Service.GoogleSearchResult result = null;
         try 
         {
            // Invoke the search method
            result = service.doGoogleSearch(
               googleLicenseKey, query, startIndex, maxResults, filtering, "", 
               false, "", "", "");

         }
         catch (System.Web.Services.Protocols.SoapException ex) 
         {
            throw new 
               GoogleSearchException("Google web service query failed.", 
                  ex);
         }
         return result;
      }
   }

   /// <summary>
   ///   Exception for problems searching Google via web service
   /// </summary>
   [Serializable]
   public class GoogleSearchException : ApplicationException
   {
      /// <summary>
      ///   Constructor takes an error message and the inner SoapException
      ///   raised by the web service plumbing in .NET
      /// </summary>
      /// <param name="message">Error Message</param>
      /// <param name="e">Soap Exception raised by Google web service</param>
      public GoogleSearchException(string message, SoapException e) : base(message, e)
      {

      }
   }	
}
