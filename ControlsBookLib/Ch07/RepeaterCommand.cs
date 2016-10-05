// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: RepeaterCommand.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI.WebControls;

namespace ControlsBookLib.Ch07
{
   public delegate void RepeaterCommandEventHandler(object o, RepeaterCommandEventArgs rce);

   public class RepeaterCommandEventArgs : CommandEventArgs
   {
      public RepeaterCommandEventArgs(RepeaterItem item, object commandSource,
         CommandEventArgs originalArgs) : base(originalArgs)
      {
         this.item = item;
         this.commandSource = commandSource;
      }

      private RepeaterItem item;
      public RepeaterItem Item
      {
         get
         {
            return item;
         }
      }

      private object commandSource;
      public object CommandSource
      {
         get
         {
            return commandSource;
         }
      }
   }
}
