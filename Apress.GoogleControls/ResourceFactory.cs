// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ResourceFactory.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Resources;
using System.Reflection;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Allows for efficient access to a single ResourceManager instance
   /// using a singleton type of factory pattern
   /// </summary>
   internal class ResourceFactory
   {  
      internal const string ResourceName = "Apress.GoogleControls.LocalStrings";
      static ResourceManager rm;

      /// <summary>
      /// Retrieves static instance of ResourceManager class
      /// </summary>
      public static ResourceManager Manager
      {
         get 
         {    
            if (rm == null) 
            {
               // Load the LocalStrings resource bound to the
               // main assembly or one of the language specific
               // satellite assemblies
               rm = new ResourceManager(ResourceName, 
               Assembly.GetExecutingAssembly(), null);
            }
            return rm;
         }
      }
   }
}
