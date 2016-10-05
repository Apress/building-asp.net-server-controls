// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: RsaLicense.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.ComponentModel;

namespace Apress.GoogleControls
{
   /// <summary>
   ///	License class for server controls using RSA crypto
   /// </summary>
   public class RsaLicense : License
   {
      private Type type;
      private string licenseKey;
      private string guid;
      private DateTime expireDate;

      /// <summary>
      ///   Constructor for RsaLicense control license class
      /// </summary>
      /// <param name="type">Type of server control to license</param>
      /// <param name="key">Full key value of license</param>
      /// <param name="guid">Guid for server control type build</param>
      /// <param name="expireDate">Date license expires</param>
      public RsaLicense(Type type, string key, string guid, DateTime expireDate)
      {
         licenseKey = key;
         this.type = type;
         this.guid = guid;
         this.expireDate = expireDate;
      }

      /// <summary>
      /// Full key value of license stored in license file
      /// </summary>
      public override string LicenseKey
      {
         get
         {
               return licenseKey;
         }
      }

      /// <summary>
      /// Server control type the license is bound to
      /// </summary>
      public Type Type
      {
         get
         {
            return type;
         }
      }

      /// <summary>
      /// Guid representing specific build of server control type
      /// </summary>
      public string Guid
      {
         get
         {
               return guid;
         }
      }

      /// <summary>
      /// Expiration date of license
      /// </summary>
      public DateTime ExpireDate
      {
         get 
         { 
            return expireDate; 
         }
      }
      
      /// <summary>
      /// Required override for License derived controls
      /// </summary>
      public override void Dispose()
      {

      }
   }
}
