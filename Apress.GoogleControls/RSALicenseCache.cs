// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: RsaLicenseCache.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.ComponentModel;
using System.Collections;

namespace Apress.GoogleControls
{
   /// <summary>
   ///   Custom cache collection built on Hashtable for storing RsaLicense instances
   /// </summary>
   internal class RsaLicenseCache
   {
      private Hashtable hash = new Hashtable();

      public void AddLicense(Type type, RsaLicense license)
      {
         hash.Add(type, license);
      }

      public RsaLicense GetLicense(Type type)
      {
         RsaLicense license = null;
         if (hash.ContainsKey(type))
            license = (RsaLicense) hash[type];
         return license;
      }

      public void RemoveLicense(Type type)
      {
         hash.Remove(type);
      }
   }
}
