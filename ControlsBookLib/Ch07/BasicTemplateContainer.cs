// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: BasicTemplateContainer.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsBookLib.Ch07
{
   public class BasicTemplateContainer : WebControl, INamingContainer
   {
      public BasicTemplateContainer() : base(HtmlTextWriterTag.Span)
      {
      }
   }
}
