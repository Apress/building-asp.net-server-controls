// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: MenuItemDataCollectionEditor.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ControlsBookLib.Ch07;

namespace ControlsBookLib.Ch12.Design
{
   public class MenuItemDataCollectionEditor : CollectionEditor
   {
      public MenuItemDataCollectionEditor(Type type) : base(type)
      {
      }
      protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()
      {
         CollectionEditor.CollectionForm frm = base.CreateCollectionForm ();
         ((Form)frm).Width = 750;
         ((Form)frm).StartPosition = FormStartPosition.CenterParent;

         return frm;
      }
   }
}