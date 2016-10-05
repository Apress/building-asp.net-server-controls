// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: BrowserCaps.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsBookLib.Ch08
{
   [ToolboxData("<{0}:BrowserCaps runat=server></{0}:BrowserCaps>")]
   public class BrowserCaps : WebControl
   {
      public BrowserCaps() : base(HtmlTextWriterTag.Div)
      {
      }

      private void AddCapsRow(Table table, string lname, object lresult,
         string rname, object rresult)
      {
         TableRow row = new TableRow();
         row.Cells.Add(new TableCell());
         row.Cells.Add(new TableCell());
         row.Cells.Add(new TableCell());
         row.Cells.Add(new TableCell());

         row.Cells[0].Text = lname;
         row.Cells[0].Font.Bold = true;
         row.Cells[1].Text = lresult.ToString();

         row.Cells[2].Text = rname;
         row.Cells[2].Font.Bold = true;
         row.Cells[3].Text = rresult.ToString();

         table.Rows.Add(row);
      }

      protected override void CreateChildControls()
      {
         HttpBrowserCapabilities caps = Context.Request.Browser;

         Controls.Add(new LiteralControl("<b>HTTP_USER_AGENT:</b>&nbsp;" +
            Context.Request.UserAgent));

         Table table = new Table();

         AddCapsRow(table, "ActiveXControls", caps.ActiveXControls,
            "MajorVersion", caps.MajorVersion);

         AddCapsRow(table, "AOL", caps.AOL,
            "MinorVersion", caps.MinorVersion);

         AddCapsRow(table, "BackgroundSounds", caps.BackgroundSounds,
            "MSDomVersion", caps.MSDomVersion);

         AddCapsRow(table, "Beta", caps.Beta,
            "Platform", caps.Platform);

         AddCapsRow(table, "Browser", caps.Browser,
            "Tables", caps.Tables);

         AddCapsRow(table, "CDF", caps.CDF,
            "TagWriter",caps.TagWriter);

         AddCapsRow(table, "ClrVersion", caps.ClrVersion,
            "Type",caps.Type);

         AddCapsRow(table, "Cookies", caps.Cookies,
            "VBScript",caps.VBScript);

         AddCapsRow(table, "Crawler", caps.Crawler,
            "Version",caps.Version);

         AddCapsRow(table, "EcmaScriptVersion", caps.EcmaScriptVersion,
            "W3CDomVersion",caps.W3CDomVersion);

         AddCapsRow(table, "Frames", caps.Frames,
            "Win16",caps.Win16);

         AddCapsRow(table, "JavaApplets", caps.JavaApplets,
            "Win32",caps.Win32);

         AddCapsRow(table, "JavaScript", caps.JavaScript,
            "","");

         table.ApplyStyle(ControlStyle);

         Controls.Add(table);
      }
   }
}
