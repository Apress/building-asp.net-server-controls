// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: ImageMetaDataConverter.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using ControlsBookLib.Ch12;

namespace ControlsBookLib.Ch12.Design
{
   public class ImageMetaDataConverter : ExpandableObjectConverter
   {
      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
         if (null == value)
         {
            return new ImageMetaData();
         }

         if (value is string)
         {
            string str = (string)value;
            if ("" == str)
            {
               return new ImageMetaData();
            }

            string[] propValues = str.Split(culture.TextInfo.ListSeparator[0]);

            if (4 != propValues.Length )
            {
               throw new ArgumentException("Invalid ImageMetaData", "value");
            }

            TypeConverter datetimeConverter = TypeDescriptor.GetConverter(typeof(DateTime));
            TypeConverter locationConverter = TypeDescriptor.GetConverter(typeof(Location));

            return new ImageMetaData((DateTime)datetimeConverter.ConvertFromString(context,culture,propValues[0]),
               (Location)locationConverter.ConvertFromString(context, culture, propValues[1]),
               (string)propValues[2],
               (string)propValues[3]);
         }
         return base.ConvertFrom(context, culture, value);
      }

      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
         if ( typeof(string) == sourceType)
         {
            return true;
         }
         return base.CanConvertFrom(context, sourceType);
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type targetType)
      {
         if (null != value)
         {
            if (!(value is ImageMetaData))
            {
               throw new ArgumentException("Not of type ImageMetaData", "value");
            }
         }

         if (targetType == typeof(string))
         {
            if (null == value)
            {
               return String.Empty;
            }

            ImageMetaData imageMetaData = (ImageMetaData)value;
            if (imageMetaData.IsEmpty)
            {
               return String.Empty;
            }

            TypeConverter datetimeConverter = TypeDescriptor.GetConverter(typeof(DateTime));
            TypeConverter locationConverter = TypeDescriptor.GetConverter(typeof(Location));

            return String.Join(culture.TextInfo.ListSeparator,
               new string[] {
                               datetimeConverter.ConvertToString(context, culture, imageMetaData.ImageDate),
                               locationConverter.ConvertToString(context, culture, imageMetaData.ImageLocation),
                               imageMetaData.ImageLongDescription,
                               imageMetaData.PhotographerFullName});
         }

         return base.ConvertTo(context, culture, value, targetType);
      }

      public override bool CanConvertTo(ITypeDescriptorContext context, Type targetType)
      {
         if (typeof(string) == targetType)
         {
            return true;
         }
         return base.CanConvertTo(context, targetType);
      }
   }
}