// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: LifecycleControl.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.Collections.Specialized;
using System.Diagnostics;

namespace ControlsBookLib.Ch05
{
   [ToolboxData("<{0}:Lifecycle runat=server></{0}:Lifecycle>")]
   public class Lifecycle : Control, IPostBackEventHandler, IPostBackDataHandler
   {
      // Init Event
      override protected void OnInit(System.EventArgs e)
      {         
         Trace("Lifecycle: Init Event.");
         base.OnInit(e);
      }

      override protected void TrackViewState()
      {         
         Trace("Lifecycle: Track ViewState.");
         base.TrackViewState();
      }

      // Load ViewState Event
      override protected void LoadViewState(object savedState)
      {         
         Trace("Lifecycle: Load ViewState Event.");
         base.LoadViewState(savedState);
      }

      // Load Postback Data Event
      public bool LoadPostData(string postDataKey,
         NameValueCollection postCollection)
      {
         Trace("Lifecycle: Load PostBack Data Event.");

         Page.RegisterRequiresRaiseEvent(this);
         return true;
      }

      // Load Event
      override protected void OnLoad(System.EventArgs e)
      {         
         Trace("Lifecycle: Load Event.");
         base.OnLoad(e);
      }

      // Post Data Changed Event
      public void RaisePostDataChangedEvent()
      {
         Trace("Lifecycle: Post Data Changed Event.");
      }

      // Postback Event
      public void RaisePostBackEvent(string argument)
      {
         Trace("Lifecycle: PostBack Event.");
      }

      // PreRender Event
      override protected void OnPreRender(System.EventArgs e)
      {         
         Trace("Lifecycle: PreRender Event.");
         Page.RegisterRequiresPostBack(this);
         base.OnPreRender(e);
      }

      // Save ViewState
      override protected object SaveViewState()
      {
         Trace("Lifecycle: Save ViewState.");
         return base.SaveViewState();
      }

      // Render Event
      override protected void Render(HtmlTextWriter writer)
      {   
         base.Render(writer);
         Trace("Lifecycle: Render Event.");
         writer.Write("<h3>LifeCycle Control</h3>");
         
      }

      // Unload Event
      override protected void OnUnload(System.EventArgs e)
      {         
         Trace("Lifecycle: Unload Event.");
         base.OnUnload(e);
      }

      // Dispose Event
      public override void Dispose()
      {         
         Trace("Lifecycle: Dispose Event.");
         base.Dispose();
      }

      private void Trace(string info)
      {
         Context.Trace.Warn(info);
         Debug.WriteLine(info);
      }
   }
}
