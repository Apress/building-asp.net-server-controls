// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: ConfirmedLinkButton.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.ComponentModel;

namespace ControlsBookLib.Ch08
{
   [ToolboxData("<{0}:ConfirmedLinkButton runat=server></{0}:ConfirmedLinkButton>"), 
   DefaultProperty("ClickText")]
   public class ConfirmedLinkButton : LinkButton
   {
      public virtual string Message
      {
         get
         {
            string message = (string)ViewState["message"];
            return (message != null) ? message : "";
         }
         set
         { 
            ViewState["message"] = value;
         }
      }

      protected override void AddAttributesToRender(HtmlTextWriter writer)
      {
         // enhance the LinkButton by replacing its
         // href attribute while leaving the rest of the
         // rendering process to the base class
         if (HttpContext.Current.Request.Browser.JavaScript &&
            this.Message != "")
         {
            StringBuilder script = new StringBuilder();
            script.Append("javascript: if (confirm('");
            script.Append(this.Message);
            script.Append("')) {");
            // get the ASP.NET JavaScript that does a form
            // postback and have this control submit it
            script.Append(Page.GetPostBackEventReference(this));
            script.Append("}");
            writer.AddAttribute(HtmlTextWriterAttribute.Href,
               script.ToString());
         }
      }
   }
}
