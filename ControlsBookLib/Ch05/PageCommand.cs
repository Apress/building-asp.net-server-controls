// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: PageCommand.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;

namespace ControlsBookLib.Ch05
{
   public enum PageDirection
   {
      Left = 0,
      Right = 1
   }

   public delegate void PageCommandEventHandler(object o, PageCommandEventArgs pce);

   public class PageCommandEventArgs
   {
      public PageCommandEventArgs(PageDirection direction)
      {
         this.direction = direction;
      }

      PageDirection direction;
      public PageDirection Direction
      {
         get{ return direction; }
      }
   }
}
