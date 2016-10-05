// Title: Building ASP.NET Server Controls
//
// Chapter: 11 - Customizing and Implementing Mobile Controls
// File: MCTextbox.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.Collections.Specialized;
using System.Web.UI.MobileControls;
using System.ComponentModel;

namespace ControlsBookLib.Ch11
{
   [ToolboxData("<{0}:MCTextBox runat=server></{0}:MCTextBox>"),
   DefaultProperty("Text")]
   public class MCTextBox : MobileControl, IPostBackDataHandler
   {
      public string Text
      {
         get
         {
            object text = ViewState["text"];
            if (text == null)
               return string.Empty;
            else
               return (string) text;
         }
         set
         {
            ViewState["text"] = value;
         }
      }

      public string Title
      {
         get
         {
            object title = ViewState["title"];
            if (title == null)
               return string.Empty;
            else
               return (string) title;
         }
         set
         {
            ViewState["title"] = value;
         }
      }

      public int MaxLength
      {
         get
         {
            object maxLength = ViewState["maxLength"];
            if (maxLength == null)
               return 0 ;
            else
               return (int) maxLength;
         }
         set
         {
            ViewState["maxLength"] = value;
         }
      }

      public int Size
      {
         get
         {
            object size = ViewState["size"];
            if (size == null)
               return 0 ;
            else
               return (int) size;
         }
         set
         {
            ViewState["size"] = value;
         }
      }

      public bool Password
      {
         get
         {
            object password = ViewState["password"];
            if (password == null)
               return false ;
            else
               return (bool) password;
         }
         set
         {
            ViewState["password"] = value;
         }
      }

      public bool Numeric
      {
         get
         {
            object numeric = ViewState["numeric"];
            if (numeric == null)
               return false ;
            else
               return (bool) numeric;
         }
         set
         {
            ViewState["numeric"] = value;
         }
      }

      public event EventHandler TextChanged;

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

      protected virtual void OnTextChanged(EventArgs e)
      {
         if (TextChanged != null)
            TextChanged(this, e);
      }
   }
}