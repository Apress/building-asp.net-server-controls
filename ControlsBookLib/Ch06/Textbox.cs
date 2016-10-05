// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: Textbox.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ControlsBookLib.Ch06
{
   [ToolboxData("<{0}:Textbox runat=server></{0}:Textbox>"),
   DefaultProperty("Text")]
   public class Textbox : WebControl, IPostBackDataHandler
   {
      public Textbox() : base(HtmlTextWriterTag.Input)
      {
      }

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
         if (!Text.Equals(postedValue))
         {
            Text = postedValue;
            return true;
         }
         else
            return false;
      }

      public void RaisePostDataChangedEvent()
      {
         OnTextChanged(EventArgs.Empty);
      }

      private static readonly object TextChangedKey = new object();
      public event EventHandler TextChanged
      {
         add
         {
            Events.AddHandler(TextChangedKey, value);
         }
         remove
         {
            Events.RemoveHandler(TextChangedKey, value);
         }
      }

      protected virtual void OnTextChanged(EventArgs e)
      {
         EventHandler textChangedEventDelegate =
            (EventHandler) Events[TextChangedKey];
         if (textChangedEventDelegate != null)
         {
            textChangedEventDelegate(this, e);
         }
      }

      override protected void AddAttributesToRender(HtmlTextWriter writer)
      {
         writer.AddAttribute("type","text");
         writer.AddAttribute("name",UniqueID);
         writer.AddAttribute("value",Text);

         base.AddAttributesToRender(writer);
      }
   }
}
