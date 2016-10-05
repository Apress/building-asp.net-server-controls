// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: FormConfirmation.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.ComponentModel;

namespace ControlsBookLib.Ch08
{
   [ToolboxData("<{0}:FormConfirmation runat=server></{0}:FormConfirmation>"),
   DefaultProperty("Message")]
   public class FormConfirmation : Control
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

      protected override void OnPreRender(EventArgs e)
      {
         if (HttpContext.Current.Request.Browser.JavaScript)
         {
            string script = "return (confirm('" + this.Message + "'));";

            // register JavaScript code for onsubmit event
            // of the HTML <form> element
            Page.RegisterOnSubmitStatement("FormConfirmation",script);
         }
      }

      protected override void Render(HtmlTextWriter writer)
      {
         // make sure the control is rendered inside
         // <form runat=server> tags
         Page.VerifyRenderingInServerForm(this);

         base.Render(writer);
      }
   }
}
