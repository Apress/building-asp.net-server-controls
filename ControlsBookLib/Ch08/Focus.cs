// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: Focus.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Text;
using System.ComponentModel;


namespace ControlsBookLib.Ch08
{
   [ToolboxData("<{0}:Focus runat=server></{0}:Focus>"),
   DefaultProperty("TargetControl")]
   public class Focus : Control
   {
      public virtual string TargetControl
      {
         get
         {
            String targetControl = (String)ViewState["Target"];
            return !(targetControl == null) ? targetControl : "" ;
         }
         set
         {  
            ViewState["Target"] = value;
         }
      }

      private string GetDOMScript(string targetID)
      {
         // build custom script to set the focus
         // to the passed in element ID
         StringBuilder script = new StringBuilder();
         script.Append("<script language='javascript'>");
         script.Append("document.getElementById('");
         script.Append(targetID);
         script.Append("').focus();");
         script.Append("</script>");

         return script.ToString();
      }

      protected override void Render(HtmlTextWriter writer)
      {
         // only render inside of <form runat="server"> tags
         Page.VerifyRenderingInServerForm(this);
         
         base.Render(writer);
         HttpBrowserCapabilities caps = Context.Request.Browser;

         // require JavaScript and DOM Level 1 and up
         // (uses DOM level 1 getElementById)
         // this works for IE5+ and Netscape 6+
         if (this.TargetControl != "" &&
            caps.JavaScript &&
            caps.W3CDomVersion.Major >= 1)
         {
            // register script at the bottom
            // of the form
            Page.RegisterStartupScript("Focus",
               GetDOMScript(this.TargetControl));
         }
      }
   }
}
