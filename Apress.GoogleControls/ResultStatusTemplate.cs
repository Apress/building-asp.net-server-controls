// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: ResultStatusTemplate.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Resources;

namespace Apress.GoogleControls
{
   /// <summary>
   ///		Default StatusTemplate implementation used by a 
   ///		stock GoogleLib Result control without a StatusTemplate
   /// </summary>
   public class ResultStatusTemplate : ITemplate
   {
      /// <summary>
      /// Method puts template controls into container control
      /// </summary>
      /// <param name="container">Outside control container to template items</param>
      public void InstantiateIn(Control container)
      {
         Label header = new Label();
         header.DataBinding +=new EventHandler(BindResultHeader);
         container.Controls.Add(header);
         LiteralControl lit = new LiteralControl();
         lit.Text = "<br>";
         container.Controls.Add(lit);
      }

      private Service.GoogleSearchResult GetResult(Control container)
      {
         ResultItem item = (ResultItem) container;
         return (Service.GoogleSearchResult) item.DataItem;
      }

      private Result GetResultControl(Control container)
      {
         ResultItem itemControl = (ResultItem) container.Parent;
         Result resultControl = (Result) itemControl.Parent;
         return resultControl;
      }

      private void BindResultHeader(object source, EventArgs e)
      {
         Label header = (Label) source;
         Result resultControl = GetResultControl(header);
         Service.GoogleSearchResult result = GetResult(header.NamingContainer);

         StringBuilder section = new StringBuilder();

         // get ResouceManager for localized format strings
         ResourceManager rm = ResourceFactory.Manager;

         // Searched for: <searchQuery>
         section.Append(
         String.Format(
            rm.GetString("ResultStatusTemplate.SearchFor"), 
            result.searchQuery));
         section.Append("<br>");

         // Result <StartIndex+1> - <EndIndex+1> of about 
         // <TotalResultsCount> records
         // (accounting for zero based index)
         section.Append(
         String.Format(
            rm.GetString("ResultStatusTemplate.ResultAbout"), 
         resultControl.StartIndex+1, 
         resultControl.EndIndex+1,
         resultControl.TotalResultsCount));
         section.Append("&nbsp&nbsp");

         // Query took about <searchTime> seconds.
         section.Append(
            String.Format(
               rm.GetString("ResultStatusTemplate.QueryTook"), 
               System.Math.Round(result.searchTime, 2)));
         section.Append("<br>");

         header.Text = section.ToString();	
      }
   }
}