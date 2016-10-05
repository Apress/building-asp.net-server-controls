// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ConfigHelper.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System.Configuration;
using System.Web;
using System.Xml; 

namespace Apress.GoogleControls
{
   /// <summary>
   ///		Helper class to find nodes and get values from configuration section XML data
   /// </summary>
   public class ConfigHelper
   {
      /// <summary>
      /// Pulls out child node from current XML node
      /// </summary>
      public static XmlNode FindChildNode(XmlNode node, string element)
      {
         XmlNode e = node.SelectSingleNode("//" + element);
         if (e == null)
            throw new ConfigurationException(
               "GoogleControl configuration element required: " + element);

         return e;
      }

      /// <summary>
      /// Gets string attribute value from Xml node
      /// </summary>
      public static string GetStringValue(XmlNode node, string attribute, bool required, string defaultval)
      {
         string val = "";
         XmlNode a = node.Attributes.GetNamedItem(attribute);
         if (a == null)
         {
            if (required == true)
            {           
               throw new ConfigurationException(
                  "GoogleControl configuration attribute required: " + attribute);
            }
            else
            {  
               val = defaultval;
            }
         }
         else
         {
            val = a.Value;
         }
         return val;	
      }
   }
}