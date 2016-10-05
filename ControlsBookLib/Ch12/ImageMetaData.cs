// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: ImageMetaData.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch12
{
   [TypeConverter(typeof(ImageMetaDataConverter))]
   public class ImageMetaData
   {
      private DateTime imageDate;
      private Location imageLocation;
      private string imageLongDescription;
      private string photographerFullName;

      public ImageMetaData()
      {

      }

      public ImageMetaData(DateTime PhotoDate,Location Loc,
         string ImageDescription,string FullName)
      {
         photographerFullName = FullName;
         imageDate = PhotoDate;
         imageLongDescription = ImageDescription;
         imageLocation = Loc;
      }

      [NotifyParentProperty(true),
      DescriptionAttribute("Name of the photographer who captured the image.")]
      public string PhotographerFullName
      {
         get
         {
            return photographerFullName;
         }
         set
         {
            photographerFullName = value;
         }
      }

      [NotifyParentProperty(true),
      DescriptionAttribute("Date the image was captured.")]
      public DateTime ImageDate
      {
         get
         {
            return imageDate;
         }
         set
         {
            imageDate = value;
         }
      }

      [NotifyParentProperty(true),
      DescriptionAttribute("Extended description of the image."),
      EditorAttribute(typeof(ControlsBookLib.Ch12.Design.SimpleTextEditor),
      typeof(UITypeEditor))]
      public string ImageLongDescription
      {
         get
         {
            return imageLongDescription;
         }
         set
         {
            imageLongDescription = value;
         }
      }

      [NotifyParentProperty(true),
      DescriptionAttribute("Location where the image was captured.")]
      public Location ImageLocation
      {
         get
         {
            if (imageLocation == null)
            {
               imageLocation = new Location();
            }
            return imageLocation;
         }
         set
         {
            imageLocation = value;
         }
      }

      [Browsable(false)]
      public bool IsEmpty
      {
         get
         {
            return (photographerFullName.Length == 0 
               && imageDate == DateTime.MinValue &&
               imageLongDescription.Length == 0 && 
               imageLocation.IsEmpty);
         }
      }

      public override string ToString()
      {
         return ToString(CultureInfo.CurrentCulture);
      }

      public string ToString(CultureInfo Culture)
      {
         return TypeDescriptor.GetConverter(typeof(ImageMetaData)).ConvertToString(null,
            Culture, this);
      }
   }
}