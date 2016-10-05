// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: GoogleConfigSectionHandler.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System.Configuration;
using System.Web;
using System.Xml; 

namespace Apress.GoogleControls
{
   /// <summary>
   ///		Retrieves instance of GoogleConfigSection fully populated from web.config
   /// </summary>
   public class GoogleConfigSectionHandler : IConfigurationSectionHandler
   {
      /// <summary>
      ///   Create is called by the configuration section framework of ASP.NET to 
      ///   tell the section handler to pull GoogleConfigSection from the config file
      /// </summary>
      /// <param name="parent"></param>
      /// <param name="configContext"></param>
      /// <param name="section"></param>
      /// <returns></returns>
      public virtual object Create(object parent,object configContext, XmlNode section)
      {
         string googleLicenseKey = "";
         string googleWebServiceUrl = "";
         string proxyUrl = "";

         XmlNode license = ConfigHelper.FindChildNode(section, "license");
         XmlNode url = ConfigHelper.FindChildNode(section, "url");

         googleLicenseKey =  
            ConfigHelper.GetStringValue(license, "googleLicenseKey", true, "");

         googleWebServiceUrl =  
            ConfigHelper.GetStringValue(url, "googleWebServiceUrl", true, "");
         
         proxyUrl = 
            ConfigHelper.GetStringValue(url, "proxyUrl", true, "");
         
         return new GoogleConfigSection(
            googleLicenseKey, googleWebServiceUrl, proxyUrl);
      }
   }   
}