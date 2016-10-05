// Title: Building ASP.NET Server Controls
//
// Chapter: 4 - State Management
// File: Textbox.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ControlsBookLib.Ch04
{
   [ToolboxData("<{0}:Textbox runat=server></{0}:Textbox>"),
   DefaultProperty("Text")]
   public class Textbox : Control, IPostBackDataHandler
   {
       public virtual string Text
      {
         get
         {
            object text = ViewState["Text"];
            if (text == null)
               return string.Empty;
            else
               return (string) text;
         }
         set
         {
            ViewState["Text"] = value;
         }
      }

      public bool LoadPostData(string postDataKey,
         NameValueCollection postCollection)
      {
         string postedValue = postCollection[postDataKey];
         Text = postedValue;
         return false;
      }

      public virtual void RaisePostDataChangedEvent()
      {

      }

      override protected void Render(HtmlTextWriter writer)
      {
         Page.VerifyRenderingInServerForm(this);

         base.Render(writer);

         // write out the <INPUT type="text"> tag
         writer.Write("<INPUT type=\"text\" name=\"");
         writer.Write(this.UniqueID);
         writer.Write("\" value=\"" + this.Text + "\" />");
      }
   }
}
