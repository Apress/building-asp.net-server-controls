// Title: Building ASP.NET Server Controls
//
// Chapter: 8 - Integrating Client-Side Script
// File: UpDown.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch08
{
   
  
   [ToolboxData("<{0}:UpDown runat=server></{0}:UpDown>"),   DefaultProperty("Value"),
   Designer(typeof(CompCntrlDesigner))]
   public class UpDown : WebControl, IPostBackDataHandler, INamingContainer
   {
      protected const string CLIENT_SCRIPT_LOCATION = "/aspnet_client/{0}/{1}/";
      protected const string UPDOWN_SCRIPT_FILE = "UpDown.js";
      protected const string UP_SCRIPT_FUNCTION = "__UpDown_Up";
      protected const string DOWN_SCRIPT_FUNCTION = "__UpDown_Down";
      protected string CHECK_SCRIPT_FUNCTION = "__UpDown_Check";

      private TextBox valueTextBox ;
      private Button upButton ;
      private Button downButton ;
      private bool renderClientScript;
      private static readonly object ValueChangedKey = new object();

      public UpDown() : base(HtmlTextWriterTag.Div)
      {         
         renderClientScript = false;
      }

      public virtual bool EnableClientScript
      {
         get
         {
            EnsureChildControls();
            object script = ViewState["EnableClientScript"];
            if (script == null)
               return true;
            else
               return (bool) script;
         }
         set
         {
            EnsureChildControls();
            ViewState["EnableClientScript"] = value;
         }
      }

      public virtual int MinValue
      {
         get
         {            
            EnsureChildControls();
            object min = ViewState["MinValue"];
            return (min == null) ? 0 : (int) min;
         }
         set
         {            
            EnsureChildControls();
            if (value < MaxValue)
               ViewState["MinValue"] = value;
            else
               throw new ArgumentException("MinValue must be less than MaxValue.","MinValue");
         }
      }

      public virtual int MaxValue
      {
         get
         {            
            EnsureChildControls();
            object max = ViewState["MaxValue"];
            return (max == null) ? System.Int32.MaxValue : (int) max;
         }
         set
         {
            EnsureChildControls();
            if (value > MinValue)
               ViewState["MaxValue"] = value;
            else
               throw new ArgumentException("MaxValue must be greater than MinValue.","MaxValue");
         }
      }

      public int Value
      {
         get
         {
            EnsureChildControls();
            object value = (int)ViewState["value"];
            return (value != null) ? (int)value : 0;
         }
         set
         {
            EnsureChildControls();
            if ((value <= MaxValue) &&
               (value >= MinValue))
            {
               valueTextBox.Text = value.ToString();
               ViewState["value"] = value ;
            }
            else
            {
               throw new ArgumentOutOfRangeException("Value","Value must be between MinValue and MaxValue.");
            }
         }
      }

      public int Increment
      {
         get
         {
            EnsureChildControls();
            object inc = ViewState["Increment"];
            return (inc == null) ? 1 : (int) inc;
         }
         set
         {
            EnsureChildControls();
            if (value > 0)
               ViewState["Increment"] = value;
         }
      }

      // LoadPostData is overriden to get the data
      // back from the textbox and set up the
      // ValueChanged event if necessary
      bool IPostBackDataHandler.LoadPostData(string postDataKey,
         NameValueCollection postCollection)
      {
         bool changed = false;

         // grab the value posted by the textbox
         string postedValue = postCollection[valueTextBox.UniqueID];
         int postedNumber = 0;

         try
         {
            postedNumber = System.Int32.Parse(postedValue);

            if (!Value.Equals(postedNumber))
              changed = true;

            Value = postedNumber;
         }
         catch (FormatException fe)
         {
            changed = false;
         }
         return changed;
      }

      void IPostBackDataHandler.RaisePostDataChangedEvent()
      {
         OnValueChanged(EventArgs.Empty);
      }

      public event EventHandler ValueChanged
      {
         add
         {
            Events.AddHandler(ValueChangedKey, value);
         }
         remove
         {
            Events.RemoveHandler(ValueChangedKey, value);
         }
      }

      protected virtual void OnValueChanged(EventArgs e)
      {
         EventHandler valueChangedEventDelegate =
            (EventHandler) Events[ValueChangedKey];
         if (valueChangedEventDelegate != null)
         {
            valueChangedEventDelegate(this, e);
         }
      }

      // up/down button click handling when client-side
      // script functionality is not enabled
      protected void UpButtonClick(object source, EventArgs e)
      {
         int newValue = Value + Increment;
         if ((newValue <= MaxValue) && (newValue >= MinValue))
         {
            Value = newValue;
            OnValueChanged(EventArgs.Empty);
         }
      }

      protected void DownButtonClick(object source, EventArgs e)
      {
         int newValue = Value - Increment;
         if ((newValue <= MaxValue) && (newValue >= MinValue))
         {
               Value = newValue;
            OnValueChanged(EventArgs.Empty);
         }
      }

      protected void DetermineRenderClientScript()
      {
         if (EnableClientScript)
         {
            if ((Page != null) && (Page.Request != null))
            {
               HttpBrowserCapabilities caps = Page.Request.Browser;

               // require JavaScript and DOM Level 1
               // support to render client-side code
               // (IE 5+ and Netscape 6+)
               if (caps.JavaScript &&
                  caps.W3CDomVersion.Major >= 1)
               {
                  renderClientScript = true;
               }
            }
         }
      }

      private string GetClientScriptInclude(string scriptFile)
      {
         // get the location of the client script folder
         // on the web server
         string scriptLocation = CLIENT_SCRIPT_LOCATION;

         // the format of the location is
         // /aspnet_client/{0}/{1}
         // 0 becomes the assembly version number
         // 1 becomes the name of the script

         if (scriptLocation.IndexOf("{0}") >= 0)
         {
            AssemblyName assemblyInfo = GetType().Assembly.GetName();

            // replace dots in assembly name and version
            // to make it URL safe
            string assemblyName = assemblyInfo.Name.Replace('.', '_');
            string assemblyVersion = assemblyInfo.Version.ToString().Replace('.', '_');

            scriptLocation = String.Format(scriptLocation, assemblyName, assemblyVersion);
         }

         // emit the <script> tag to reference an external javascript file
         return String.Format("<script language=\"javascript\" src=\"{0}{1}\"></script>",
            scriptLocation, scriptFile);
      }

      protected override void OnPreRender(EventArgs e)
      {
         base.OnPreRender(e);

         DetermineRenderClientScript();
         
         // textbox script that validates the textbox when it
         // loses focus after input
         string scriptInvoke = "";
         if (renderClientScript)
         {
            scriptInvoke = this.CHECK_SCRIPT_FUNCTION + "('" + valueTextBox.UniqueID +
               "'," + this.MinValue + "," + this.MaxValue + ")";
            valueTextBox.Attributes.Add("onblur",scriptInvoke);
         }

         // add the '+' button client script function that
         // manipulates textbox on client-side
         if (renderClientScript)
         {
            scriptInvoke = UP_SCRIPT_FUNCTION + "('" + valueTextBox.UniqueID +
               "'," + this.MinValue + "," + this.MaxValue + "," + this.Increment + "); return false;";
            upButton.Attributes.Add("onclick",scriptInvoke);
         }

         // add the '-' button client script function that
         // manipulates textbox on client-side
         if (renderClientScript)
         {
            scriptInvoke = DOWN_SCRIPT_FUNCTION + "('" + valueTextBox.UniqueID +
               "'," + this.MinValue + "," + this.MaxValue + "," + this.Increment + "); return false;";
            downButton.Attributes.Add("onclick",scriptInvoke);
         }

         // register to ensure we receive postback handling
         // to properly handle child input controls
         Page.RegisterRequiresPostBack(this);

         if (renderClientScript)
         {
            // register the <script> block that does the
            // client-side handling
            Page.RegisterClientScriptBlock(
               typeof(UpDown).ToString(),
               GetClientScriptInclude(UPDOWN_SCRIPT_FILE) );
         }
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }

      protected override void CreateChildControls()
      {
         Controls.Clear();

         // add the texbox that holds the value
         valueTextBox = new TextBox();
         valueTextBox.ID = "InputText";
         valueTextBox.Width = 40;
         valueTextBox.Text = "0";
        Controls.Add(valueTextBox);

         // add the '+' button
         upButton = new Button();
         upButton.ID = "UpButton";
         upButton.Text = " + ";
         upButton.Click += new System.EventHandler(this.UpButtonClick);
         Controls.Add(upButton);

         // add the '-' button
         downButton = new Button();
         downButton.ID = "DownButton";
         downButton.Text = " - ";
         downButton.Click += new System.EventHandler(this.DownButtonClick);
        Controls.Add(downButton);
      }
   }
}