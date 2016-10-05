// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: TextChanged.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;

namespace ControlsBookLib.Ch05
{
   public delegate void TextChangedEventHandler(object o, TextChangedEventArgs tce);

   public class TextChangedEventArgs : EventArgs
   {
      private string oldValue;
      private string newValue;

      public TextChangedEventArgs(string oldValue, string newValue)
      {
         this.oldValue = oldValue;
         this.newValue = newValue;
      }

      public string OldValue
      {
         get
         {
            return oldValue;
         }
      }

      public string NewValue
      {
         get
         {
            return newValue;
         }
      }
   }
}
