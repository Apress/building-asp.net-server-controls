// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: GoogleConfigSection.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System.Configuration;
using System.Web;
using System.Xml; 

namespace Apress.GoogleControls
{
   /// <summary>
   ///		Represents configuration section from web.config relating to the 
   ///		GoogleControls web service related settings
   /// </summary>
   public class GoogleConfigSection
   {
      private string googleLicenseKey;
      private string googleWebServiceUrl;
      private string proxyUrl;

      /// <summary>
      ///   Constructor for GoogleControls config section
      /// </summary>
      /// <param name="googleLicenseKey">License key for accessing Google web service.</param>
      /// <param name="googleWebServiceUrl">Url for Google web service.</param>
      /// <param name="proxyUrl">Url for proxy server if code is behind a firewall.</param>
      public GoogleConfigSection(string googleLicenseKey, string googleWebServiceUrl, string proxyUrl)
      {
         this.googleLicenseKey = googleLicenseKey;
         this.googleWebServiceUrl = googleWebServiceUrl;
         this.proxyUrl = proxyUrl;
      }

      /// <summary>
      ///   Google web service license key (issued by Google)
      /// </summary>
      public string GoogleLicenseKey
      {
         get {return googleLicenseKey;}
      }

      /// <summary>
      ///    Url of Google web service
      /// </summary>
      public string GoogleWebServiceUrl
      {
         get {return googleWebServiceUrl;}
      }

      /// <summary>
      ///   Url of a proxy server if the code is behind a firewall
      /// </summary>
      public string ProxyUrl
      {
         get {return proxyUrl;}
      }
   }
}