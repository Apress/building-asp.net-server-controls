// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: CustCodeTemplates.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using ControlsBookLib.Ch07 ;

namespace ControlsBookLib.Ch07
{
   public class CustCodeHeaderTemplate : ITemplate
   {
      public void InstantiateIn(Control container)
      {
         LiteralControl table =
            new LiteralControl(
            "<table cellspacing=\"0\" cellpadding=\"3\" " +
            "rules=\"cols\" bordercolor=\"#999999\" border=\"1\" " +
            "style=\"background-color:White;border-color:#999999;" +
            "border-width:1px;border-style:None;" +
            "border-collapse:collapse;\">" +
            "<th>Name</th><th>Title</th><th>Company</th>"
            );
         container.Controls.Add(table);
      }
   }

   public class CustCodeItemTemplate : ITemplate
   {
      bool isItem = false;

      public CustCodeItemTemplate(bool IsItem)
      {
            isItem = IsItem;

      }

      public string BackgroundColor
      {
         get
         {
            if (isItem)
               return "blue";
            else
               return "white";
         }
      }

      public string Color
      {
         get
         {
            if (isItem)
               return "white";
            else
               return "blue";
         }
      }

      public void InstantiateIn(Control container)
      {
         LiteralControl row =
            new LiteralControl("<tr style=\"color:" + Color +
            ";background-color:" + BackgroundColor +
            ";font-weight:bold;\">");
         container.Controls.Add(row);

         LiteralControl contactName = new LiteralControl();
         contactName.DataBinding += new EventHandler(BindContactName);
         container.Controls.Add(contactName);

         LiteralControl contactTitle = new LiteralControl();
         contactTitle.DataBinding += new EventHandler(BindContactTitle);
         container.Controls.Add(contactTitle);

         LiteralControl companyName = new LiteralControl();
         companyName.DataBinding += new EventHandler(BindCompanyName);
         container.Controls.Add(companyName);

         row = new LiteralControl("</tr>");
         container.Controls.Add(row);
      }

      private void BindContactName(object source, EventArgs e)
      {
         LiteralControl contactName = (LiteralControl) source;
         RepeaterItem item = (RepeaterItem) contactName.NamingContainer;
         contactName.Text = "<td>" +
            DataBinder.Eval(item.DataItem, "ContactName")
            + "</td>";
      }

      private void BindContactTitle(object source, EventArgs e)
      {
         LiteralControl contactTitle = (LiteralControl) source;
         RepeaterItem item = (RepeaterItem) contactTitle.NamingContainer;
         contactTitle.Text = "<td>" +
            DataBinder.Eval(item.DataItem, "ContactTitle")
            + "</td>";
      }

      private void BindCompanyName(object source, EventArgs e)
      {
         LiteralControl companyName = (LiteralControl) source;
         RepeaterItem item = (RepeaterItem) companyName.NamingContainer;
         companyName.Text = "<td>" +
            DataBinder.Eval(item.DataItem, "CompanyName")
            + "</td>";
      }
   }

   public class CustCodeFooterTemplate : ITemplate
   {
      public void InstantiateIn(Control container)
      {
         LiteralControl table = new LiteralControl("<tr><td colspan=3>&nbsp;</td></tr></table>");
         container.Controls.Add(table);
      }
   }
}
