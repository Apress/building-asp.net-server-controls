// Title: Building ASP.NET Server Controls
//
// Chapter: 6 - Control Styles
// File: InputBox.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace ControlsBookLib.Ch06
{
   [ToolboxData("<{0}:InputBox runat=server></{0}:InputBox>")]
   public class InputBox : WebControl
   {
      public InputBox() : base(HtmlTextWriterTag.Div)
      {
      }

      public string LabelText
      {
         get
         {
            EnsureChildControls();
            ControlsBookLib.Ch06.Label label =
               (ControlsBookLib.Ch06.Label) Controls[0];
            return label.Text;
         }
         set
         {
            EnsureChildControls();
            ControlsBookLib.Ch06.Label label =
               (ControlsBookLib.Ch06.Label) Controls[0];
            label.Text = value;
         }
      }

      public string TextboxText
      {
         get
         {
            EnsureChildControls();
            ControlsBookLib.Ch06.Textbox textbox =
               (ControlsBookLib.Ch06.Textbox) Controls[1];
            return textbox.Text;
         }
         set
         {
            EnsureChildControls();
            ControlsBookLib.Ch06.Textbox textbox =
               (ControlsBookLib.Ch06.Textbox) Controls[1];
            textbox.Text = value;
         }
      }

      Style labelStyle;
      public virtual Style LabelStyle
      {
         get
         {
            if (labelStyle == null)
            {
               labelStyle = new Style();
               if (IsTrackingViewState)
                  ((IStateManager)labelStyle).TrackViewState();
            }
            return labelStyle;
         }
      }

      Style textboxStyle;
      public virtual Style TextboxStyle
      {
         get
         {
            if (textboxStyle == null)
            {
               textboxStyle = new Style();
               if (IsTrackingViewState)
                  ((IStateManager)textboxStyle).TrackViewState();
            }
            return textboxStyle;
         }
      }

      override protected void LoadViewState(object savedState)
      {
         if (savedState != null)
         {
            object[] state = (object[])savedState;

            if (state[0] != null)
               base.LoadViewState(state[0]);
            if (state[1] != null)
               ((IStateManager)LabelStyle).LoadViewState(state[1]);
            if (state[2] != null)
               ((IStateManager)TextboxStyle).LoadViewState(state[2]);
         }
      }

      override protected object SaveViewState()
      {
         object baseState = base.SaveViewState();
         object labelStyleState = (labelStyle != null) ? ((IStateManager)labelStyle).SaveViewState() : null;
         object textboxStyleState = (textboxStyle != null) ? ((IStateManager)textboxStyle).SaveViewState() : null;

         object[] state = new object[3];
         state[0] = baseState;
         state[1] = labelStyleState;
         state[2] = textboxStyleState;

         return state;
      }

      override protected void CreateChildControls()
      {

         ControlsBookLib.Ch06.Label label = new ControlsBookLib.Ch06.Label();
         Controls.Add(label);

         ControlsBookLib.Ch06.Textbox textbox = new ControlsBookLib.Ch06.Textbox();
         Controls.Add(textbox);
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }

      private void PrepareControlHierarchy()
      {
         ControlsBookLib.Ch06.Label label = (ControlsBookLib.Ch06.Label) Controls[0];
         label.ApplyStyle(LabelStyle);
         label.MergeStyle(ControlStyle);

         ControlsBookLib.Ch06.Textbox textbox = (ControlsBookLib.Ch06.Textbox) Controls[1];
         textbox.ApplyStyle(TextboxStyle);
         textbox.MergeStyle(ControlStyle);
      }

      override protected void Render(HtmlTextWriter writer)
      {
         PrepareControlHierarchy();
         RenderBeginTag(writer);
         RenderChildren(writer);
         RenderEndTag(writer);
      }
   }
}
