// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: TitledThumbnail.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Reflection;
using System.ComponentModel;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch12
{
   public enum TitleAlignment {center,justify,left,right};

   [ToolboxData("<{0}:TitledThumbnail runat=server></{0}:TitledThumbnail>"),  
   EditorAttribute(typeof(TitledThumbnailComponentEditor),typeof(ComponentEditor)),
   Designer(typeof(TitledThumbnailDesigner)),
   DefaultProperty("ImageUrl")]
   public class TitledThumbnail : WebControl, INamingContainer
   {
      private Image imgThumbnail;
      private Label lblTitle;
      private ImageMetaData metaData;

      public TitledThumbnail() : base(System.Web.UI.HtmlTextWriterTag.Div)
      {
         
      }
      
      [DescriptionAttribute("Text to be shown as the image caption."),
      CategoryAttribute("Appearance")]
      public string Title
      {
         get
         {            
            EnsureChildControls();
            object title = ViewState["title"];
            return (title == null) ? "" : (string) title;
         }
         set
         {            
            EnsureChildControls();            
            lblTitle.Text = value;
            ViewState["title"] = value;
         }
      }

      [DescriptionAttribute("The Url of the image to be shown."),
      CategoryAttribute("Appearance")]
      public string ImageUrl
      {
         get
         {            
            EnsureChildControls();
            object imageUrl = ViewState["imageUrl"];
            return (imageUrl == null) ? "" : (string) imageUrl;
         }
         set
         {            
            EnsureChildControls();            
            imgThumbnail.ImageUrl = value;
            ViewState["imageUrl"] = value;
         }
      }
      
      [DescriptionAttribute("Set the alignment for the Image and Title."),
      CategoryAttribute("Layout"),DefaultValue("center")]
      public TitleAlignment Align
      {
         get
         {            
            EnsureChildControls();
            object align = ViewState["align"];
            return (align == null) ? TitleAlignment.left : (TitleAlignment)align;
         }
         set
         {            
            EnsureChildControls();            
            this.Attributes.Add("align",Enum.GetName(typeof(TitleAlignment),value));
            ViewState["align"] = value;
         }
      }
      
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
      NotifyParentProperty(true),CategoryAttribute("MetaData"),
      DescriptionAttribute("Meta data that stores information about the displayed photo image.")]
      public ImageMetaData ImageInfo
      {
         get
         {            
            EnsureChildControls();
            if (metaData == null)
            {
               metaData = new ImageMetaData();
            }
            return metaData;
         }
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }

      protected override void CreateChildControls()
      {
         Controls.Clear();

         imgThumbnail = new Image();
         this.Controls.Add(imgThumbnail);

         lblTitle = new Label();
         lblTitle.Width = 86;
         this.Controls.Add(lblTitle);
      }

   }
}