// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: RsaLicenseProvider.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Collections;
using System.Globalization;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Custom license provider for GoogleLib which use RSA crypto
   /// </summary>
   public class RsaLicenseProvider : LicenseProvider
   {
      static RsaLicenseCache licenseCache = new RsaLicenseCache();

      /// <summary>
      /// Called by LicenseManager to retrieve a license
      /// </summary>
      /// <param name="context">Context of request (design/runtime)</param>
      /// <param name="type">Control type needing license</param>
      /// <param name="instance">Control instance needing license</param>
      /// <param name="allowExceptions">true if a LicenseException should be thrown when the component cannot be granted a license; otherwise, false.</param>
      /// <returns></returns>
      public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
      {
         string attrGuid = "";
         string publicKey = "";

         // pull licensing data (guid/publickey) from custom attributes
         // on the control
         RsaLicenseDataAttribute licDataAttr = GetRsaLicenseDataAttribute(type);
         if (licDataAttr == null)
            return null;
         publicKey = licDataAttr.PublicKey;
         attrGuid = licDataAttr.Guid;

         // if in Design mode create and return non-expiring license
         // so design time ASP.NET is always working
         if (context.UsageMode == LicenseUsageMode.Designtime)
         {
            return new RsaLicense(type, "", attrGuid, DateTime.MaxValue);
         }

         // check cache for cached license information
         RsaLicense license = licenseCache.GetLicense(type);
         string keyValue = "";
         if (license == null)
         {
            // check the license folder under the web root for a
            // license file and parse key data from it
            keyValue = LoadLicenseData(type);

            // validate the new license data key value
            DateTime expireDate = new DateTime();
            if (IsKeyValid(keyValue, publicKey, attrGuid, type, ref expireDate))
            {
               license = new RsaLicense(type, keyValue, attrGuid, expireDate);
               licenseCache.AddLicense(type, license);
            }

         }
         return license;
      }

      /// <summary>
      /// Method to look up custom licensing attribute on server control
      /// </summary>
      /// <param name="type">Control type for custom attribute lookup</param>
      /// <returns></returns>
      private RsaLicenseDataAttribute GetRsaLicenseDataAttribute(System.Type type)
      {
         RsaLicenseDataAttribute licDataAttr;
         object[] attrs = type.GetCustomAttributes(false);
         foreach (object attr in attrs)
         {
            licDataAttr = attr as RsaLicenseDataAttribute;
            if (licDataAttr != null)
               return licDataAttr;
         }
         return null;
      }

      /// <summary>
      /// Methods retireves license key from license file
      /// </summary>
      /// <param name="type">Control type to retrieve license data for </param>
      /// <returns></returns>
      protected string LoadLicenseData(Type type)
      {
         // format of license files in web app folder structure
         // web root\
         // license\
         // Apress.GoogleControls.lic

         string keyValue = "";
         string assemblyName = type.Assembly.GetName().Name;
         string relativePath = "~\\license\\" + assemblyName + ".lic";
         string licFilePath = HttpContext.Current.Server.MapPath(relativePath);

         if (File.Exists(licFilePath))
         {
            // grab the first line which contains license data
            FileStream file = new FileStream(licFilePath,
               FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader rdr = new StreamReader(file);
            keyValue = rdr.ReadLine();
            rdr.Close();
            file.Close();
         }

         return keyValue;
      }

      /// <summary>
      /// Method verifies the validaty of license key information
      /// </summary>
      /// <param name="keyValue">License key value</param>
      /// <param name="publicKey">Public key of version-specific control build</param>
      /// <param name="attrGuid">Guid of version-specific control build</param>
      /// <param name="type">Type of control being licensed</param>
      /// <param name="expireDate">Date license expires</param>
      /// <returns></returns>
      protected bool IsKeyValid(string keyValue, string publicKey, string attrGuid, System.Type type, ref DateTime expireDate)
      {
         if (keyValue.Length == 0)
            return false;

         char[] separators = { '#' };
         string[] values = keyValue.Split(separators);
         string signature = values[2];
         string licGuid = values[0];
         string expires = values[1];

         // Conver the expiration date using the neutral
         // culture of the assembly(en-US)
         expireDate = Convert.ToDateTime(expires,
            DateTimeFormatInfo.InvariantInfo);

         // do a date comparison for expiration and make
         // sure we are matching control with right license data
         return (licGuid == attrGuid &&
            expireDate > DateTime.Now &&
            VerifyHash(publicKey, licGuid, expires, signature));
      }

      /// <summary>
      /// Helper method to verify hash value in license key using RSA
      /// public key crypto
      /// </summary>
      /// <param name="publicKey">Public key of version-specific control build</param>
      /// <param name="guid">Guid of version-specific control build</param>
      /// <param name="expires">Date of expiration for license</param>
      /// <param name="signature">Signature value in license key used for verification</param>
      /// <returns></returns>
      private bool VerifyHash(string publicKey, string guid, string expires, string signature)
      {
         // recompute the hash value
         byte[] clear = ASCIIEncoding.ASCII.GetBytes(guid + "#" + expires + "#");
         SHA1Managed provSHA1 = new SHA1Managed();
         byte[] hash = provSHA1.ComputeHash(clear);

         // reload the RSA provider based on the public key only
         CspParameters paramsCsp = new CspParameters();
         paramsCsp.Flags = CspProviderFlags.UseMachineKeyStore;
         RSACryptoServiceProvider provRSA = new RSACryptoServiceProvider(paramsCsp);
         provRSA.FromXmlString(publicKey);

         // verify the signature on the hash
         byte[] sigBytes= Convert.FromBase64String(signature);
         bool result = provRSA.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"),
            sigBytes);

         return result;
      }
   }
}
