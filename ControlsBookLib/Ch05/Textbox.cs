// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: Textbox.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ControlsBookLib.Ch05
{
   [ToolboxData("<{0}:Textbox runat=server></{0}:Textbox>"),
   DefaultProperty("Text")]
   public class Textbox : Control, IPostBackDataHandler
   {
      public string Text
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

      protected virtual void OnTextChanged(EventArgs e)
      {
         if (TextChanged != null)
            TextChanged(this, e);
      }

      public event EventHandler TextChanged;

      override protected void Render(HtmlTextWriter writer)
      {
         base.Render(writer);
         Page.VerifyRenderingInServerForm(this);
         // write out the <INPUT type="text"> tag
         writer.Write("<INPUT type=\"text\" name=\"");
         writer.Write(this.UniqueID);
         writer.Write("\" value=\"" + this.Text + "\" />");
      }
   }
}
