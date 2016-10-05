// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: Location.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.Text;
using System.Globalization;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch12
{
   [TypeConverter(typeof(LocationConverter))]
   public class Location
   {
      private double latitude;
      private double longitude;

      public Location()
      {
         latitude = 0;
         longitude = 0;
      }

      public Location(double Lat, double Long)
      {
         latitude = Lat;
         longitude = Long;
      }

      public double Latitude
      {
         get
         {
            return latitude;
         }
         set
         {
            latitude = value;
         }
      }

      public double Longitude
      {
         get
         {
            return longitude;
         }
         set
         {
            longitude = value;
         }

      }

      public bool IsEmpty
      {
         get
         {
            return (latitude == 0 && longitude == 0);
         }
      }

      //override ToString so that it displays the values of
      //its members as opposed to its fully qualified type.
      public override string ToString()
      {
         return ToString(CultureInfo.CurrentCulture);
      }

      public string ToString(CultureInfo Culture)
      {
         return TypeDescriptor.GetConverter(typeof(Location)).ConvertToString(null,
            Culture, this);
      }

      public override bool Equals(object obj)
      {
         Location Loc = (Location) obj;

         if (Loc != null)
         {
            return (latitude == Loc.Latitude &&
               longitude == Loc.Longitude);
         }
         return false;
      }

      public override int GetHashCode()
      {
         //XOR the latitude and logitude coordinates
         return latitude.GetHashCode() ^ longitude.GetHashCode();
      }
   }
}