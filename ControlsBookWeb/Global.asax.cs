using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;

namespace ControlsBookWeb
{
   /// <summary>
   /// Summary description for Global.
   /// </summary>
   public class Global : System.Web.HttpApplication
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      public Global()
      {
         InitializeComponent();
      }

      protected void Application_Start(Object sender, EventArgs e)
      {

      }

      protected void Session_Start(Object sender, EventArgs e)
      {

      }

      protected void Application_BeginRequest(Object sender, EventArgs e)
      {
         // find the preferred culture from the browser
         string culture = HttpContext.Current.Request.UserLanguages[0];

         CultureInfo info = null;

         // check for a nuetral culture of length 2 (i.e. de or es)
         if (culture.Length == 2)
            // use CultureInfo to convert from neutral to specific culture
            // so we can assign to both CurrentCulture and CurrentUI Culture
            info = CultureInfo.CreateSpecificCulture(culture);
         else
            info = new CultureInfo(culture);

         // set if for both formatting/comparisons (CurrentCulture)
         // and resource lookup (CurrentUICulture)
         Thread.CurrentThread.CurrentCulture = info;
         Thread.CurrentThread.CurrentUICulture = info;
      }

      protected void Application_EndRequest(Object sender, EventArgs e)
      {

      }

      protected void Application_AuthenticateRequest(Object sender, EventArgs e)
      {

      }

      protected void Application_Error(Object sender, EventArgs e)
      {

      }

      protected void Session_End(Object sender, EventArgs e)
      {

      }

      protected void Application_End(Object sender, EventArgs e)
      {

      }

      #region Web Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
      }
      #endregion
   }
}

