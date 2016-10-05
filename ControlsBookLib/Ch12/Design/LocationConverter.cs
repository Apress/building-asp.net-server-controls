// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: LocationConverter.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using ControlsBookLib.Ch12;

namespace ControlsBookLib.Ch12.Design
{
   public class LocationConverter : TypeConverter
   {
      public override object ConvertFrom(ITypeDescriptorContext 
         context, CultureInfo culture, object value)
      {
         if (null  == value)
         {
            return new Location();
         }

         if (value is string)
         {
            string str = (string)value;
            if (str == "")
            {
               return new Location();
            }

            string[] propValues = 
               str.Split(culture.TextInfo.ListSeparator[0]);

            if (2 != propValues.Length)
            {
               throw new ArgumentException("Invalid Location", "value");
            }

            //Peel off N/S for latitude and E/W for longitude
            string Lat = propValues[0];
            if ("N" == Lat.Substring(Lat.Length -1))
            {
               string[] latParts = Lat.Split("N".ToCharArray());
               Lat = latParts[0];
            }
            if ("S" == Lat.Substring(Lat.Length -1))
            {
               string[] latParts = Lat.Split("S".ToCharArray());
               Lat = "-" + latParts[0];
            }

            string Long = propValues[1];
            if ("W" == Long.Substring(Long.Length -1))
            {
               string[] longParts = Long.Split("W".ToCharArray());
               Long = longParts[0];
            }
            if ("E" == Long.Substring(Long.Length -1))
            {
               string[] longParts = Long.Split("E".ToCharArray());
               Long = "-" + longParts[0];
            }

            TypeConverter DoubleConverter = 
               TypeDescriptor.GetConverter(typeof(double));

            return new Location((double)DoubleConverter.ConvertFromString(context, culture, Lat),
               (double)DoubleConverter.ConvertFromString(context, culture, Long));
         }

         return base.ConvertFrom(context, culture, value);
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if (value != null)
         {
            if (!(value is Location))
            {
               throw new ArgumentException("Not of type Location", "value");
            }
         }

         if (typeof(string) == destinationType)
         {
            if (value == null)
            {
               return String.Empty;
            }

            Location Loc = (Location)value;
            string Lat ;
            string Long ;

            TypeConverter DoubleConverter = 
               TypeDescriptor.GetConverter(typeof(double));

            //Add N/S for latitude, E/W for longitude
            if (Math.Round(Loc.Latitude) >= 0)
            {
               Lat = 
                  DoubleConverter.ConvertToString(context, 
                  culture, Loc.Latitude) + "N";
            }
            else
            {
               Lat = 
                  DoubleConverter.ConvertToString(context, 
                  culture, Math.Abs(Loc.Latitude)) + "S";
            }

            if (Math.Round(Loc.Longitude) >= 0)
            {
               Long = 
                  DoubleConverter.ConvertToString(context, 
                  culture, Loc.Longitude) + "W";
            }
            else
            {
               Long = DoubleConverter.ConvertToString(context, 
                  culture, Math.Abs(Loc.Longitude)) + "E";
            }

            // Display lat and long as concantenated string with
            // a comma as the separator based on the current culture
            return String.Join(culture.TextInfo.ListSeparator,
               new string[] {Lat,Long});
         }
         else if (typeof(InstanceDescriptor) == destinationType)
         {
            if (value == null)
            {
               return null;
            }

            MemberInfo memberInfo = null;
            object[] memberParameters = null;

            Location Loc = (Location)value;
            if (Loc.IsEmpty)
            {
               memberInfo = 
                  typeof(Location).GetConstructor(new Type[0]);
            }
            else
            {
               Type doubleType = typeof(double);
               memberInfo = typeof(Location).GetConstructor(new Type[]
                  { doubleType, doubleType });
               memberParameters = 
                  new object[] { Loc.Latitude, Loc.Longitude };
            }

            if (memberInfo != null)
            {
               return new InstanceDescriptor(memberInfo, 
                  memberParameters);
            }
            else
            {
               return null;
            }
         }
         return base.ConvertTo(context, culture, value,
            destinationType);
      }

      public override bool CanConvertTo(ITypeDescriptorContext 
         context, Type destinationType)
      {
         if ((typeof(string)  == destinationType) ||
            (typeof(InstanceDescriptor)  == destinationType))
         {
            return true;
         }

         return base.CanConvertTo(context, destinationType);
      }

      public override bool CanConvertFrom(ITypeDescriptorContext 
         context, Type sourceType)
      {
         if (sourceType == typeof(string))
         {
            return true;
         }

         return base.CanConvertFrom(context, sourceType);
      }
   }
}