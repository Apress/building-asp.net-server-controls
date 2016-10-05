// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: RsaLicenseDataAttribute.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Custom attribute for annotating licensing data on GoogleLib controls
   /// </summary>
   [AttributeUsage(AttributeTargets.Class, Inherited = false,
       AllowMultiple = false)
   ]
   public sealed class RsaLicenseDataAttribute : Attribute
   {
      private string guid;
      private string publicKey;

      /// <summary>
      /// Constructor for RsaLicenseDataAttribute
      /// </summary>
      /// <param name="guid"></param>
      /// <param name="publicKey"></param>
      public RsaLicenseDataAttribute(string guid, string publicKey)
      {
         this.guid = guid;
         this.publicKey = publicKey;
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
      /// Public key representing specific build of server control type
      /// </summary>
      public string PublicKey
      {
         get
         {
            return publicKey;
         }
      }
   }
}