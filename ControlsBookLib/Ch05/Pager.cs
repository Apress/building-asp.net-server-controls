// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: Pager.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch05
{
   [ToolboxData("<{0}:Pager runat=server></{0}:Pager>"),Designer(typeof(CompCntrlDesigner))]
   public class Pager : Control, INamingContainer
   {
      private static readonly object PageCommandKey = new object();
      public event PageCommandEventHandler PageCommand
      {
         add
         {
            Events.AddHandler(PageCommandKey, value);
         }
         remove
         {
            Events.RemoveHandler(PageCommandKey, value);
         }
      }

      protected virtual void OnPageCommand(PageCommandEventArgs pce)
      {
         PageCommandEventHandler pageCommandEventDelegate =
            (PageCommandEventHandler) Events[PageCommandKey];
         if (pageCommandEventDelegate != null)
         {
            pageCommandEventDelegate(this, pce);
         }
      }

      protected override bool OnBubbleEvent(object source, EventArgs e)
      {
         bool result = false;
         CommandEventArgs ce = e as CommandEventArgs;

         if (ce != null)
         {
            if (ce.CommandName.Equals("Page"))
            {
               PageDirection direction;
               if (ce.CommandArgument.Equals("Right"))
                  direction = PageDirection.Right;
               else
                  direction = PageDirection.Left;

               PageCommandEventArgs pce =
                  new PageCommandEventArgs(direction);

               OnPageCommand(pce);
               result = true;
            }
         }
         return result;
      }

      public ButtonDisplay Display
      {
         get
         {
            EnsureChildControls();
            return buttonLeft.Display ; 
         }
         set
         {
            EnsureChildControls();
            buttonLeft.Display  = value;
            buttonRight.Display = value;
         }
      }

      protected override void CreateChildControls()
      {
         Controls.Clear();
         CreateChildControlHierarchy();
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }
      
      private SuperButton buttonLeft ;
      private SuperButton buttonRight;
      private void CreateChildControlHierarchy()
      {
         LiteralControl tableStart = new
            LiteralControl("<table border=1><tr><td>");
         Controls.Add(tableStart);

          buttonLeft = new SuperButton();
         buttonLeft.ID = "buttonLeft"; 
         if (Context != null)
         {
            buttonLeft.Text = Context.Server.HtmlEncode("<") + " Left";
         }
         else
         {
            buttonLeft.Text = "< Left";
         }
         buttonLeft.CommandName = "Page";
         buttonLeft.CommandArgument = "Left";
         Controls.Add(buttonLeft);

         LiteralControl spacer = new LiteralControl("&nbsp;&nbsp;");
         Controls.Add(spacer);

         buttonRight = new SuperButton();
         buttonRight.ID = "buttonRight";
         buttonRight.Display = Display;
         if (Context != null)
         {
            buttonRight.Text = "Right " + Context.Server.HtmlEncode(">");
         }
         else
         {
            buttonRight.Text = "Right  >";
         }
         buttonRight.CommandName = "Page";
         buttonRight.CommandArgument = "Right";
         Controls.Add(buttonRight);

         LiteralControl tableEnd = new
            LiteralControl("</td></tr></table>");
         Controls.Add(tableEnd);
      }
   }
}