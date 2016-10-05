// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: SimpletextEditor.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ControlsBookLib.Ch12.Design
{
   public class SimpleTextEditor : UITypeEditor
   {     
      public override UITypeEditorEditStyle GetEditStyle(
         ITypeDescriptorContext context)
      {
         if (null != context)
         {
            return UITypeEditorEditStyle.Modal;
         }
         return base.GetEditStyle(context);
      }

      public override object EditValue(ITypeDescriptorContext context,
         IServiceProvider serviceProvider, object value)
      {
         if ((null  != context) && (null  != serviceProvider))
         {
            IWindowsFormsEditorService editorService =
               (IWindowsFormsEditorService)serviceProvider.GetService(
               typeof(IWindowsFormsEditorService));

            if (null != editorService)
            {
               formSimpleTextEditorDialog formEditor = new formSimpleTextEditorDialog();
               formEditor.TextValue = (string)value;

               DialogResult DlgResult = editorService.ShowDialog(formEditor);
               if (DialogResult.OK == DlgResult)
               {
                  value = formEditor.TextValue;
               }
            }
         }
         return value;
      }
   }
}