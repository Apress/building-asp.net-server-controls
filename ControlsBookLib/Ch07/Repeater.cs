// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: Repeater.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using ControlsBookLib.Ch12.Design;

namespace ControlsBookLib.Ch07
{
   [ToolboxData("<{0}:Repeater runat=server></{0}:Repeater>"),ParseChildren(true),PersistChildren(false),
   Designer(typeof(RepeaterDesigner))]
   public class Repeater : Control, INamingContainer
   {      
      private ITemplate headerTemplate;
      [Browsable(false),TemplateContainer(typeof(RepeaterItem)),
      PersistenceMode(PersistenceMode.InnerProperty)]
      public ITemplate HeaderTemplate
      {
         get
         { 
            return headerTemplate; 
         }

         set
         { 
            headerTemplate = value; 
         }
      }
      
      private ITemplate footerTemplate;
      [Browsable(false),TemplateContainer(typeof(RepeaterItem)),
      PersistenceMode(PersistenceMode.InnerProperty)]
      public ITemplate FooterTemplate
      {
         get
         { 
            return footerTemplate; 
         }

         set
         { 
            footerTemplate = value; 
         }
      }
      
      private ITemplate itemTemplate;
      [Browsable(false),TemplateContainer(typeof(RepeaterItem)),
      PersistenceMode(PersistenceMode.InnerProperty)]
      public ITemplate ItemTemplate
      {
         get
         { 
            return itemTemplate; 
         }

         set
         { 
            itemTemplate = value; 
         }
      }
      
      private ITemplate alternatingItemTemplate;
      [Browsable(false),TemplateContainer(typeof(RepeaterItem)),
      PersistenceMode(PersistenceMode.InnerProperty)]
      public ITemplate AlternatingItemTemplate
      {
         get
         { 
            return alternatingItemTemplate; 
         }

         set
         { 
            alternatingItemTemplate = value; 
         }
      }
      
      private ITemplate separatorTemplate;
      [Browsable(false),TemplateContainer(typeof(RepeaterItem)),
      PersistenceMode(PersistenceMode.InnerProperty)]
      public ITemplate SeparatorTemplate
      {
         get
         { 
            return separatorTemplate; 
         }
         
         set
         { 
            separatorTemplate = value; 
         }
      }

      [Browsable(false)]
      public RepeaterItemCollection Items
      {
         get
         {
            EnsureChildControls();
            RepeaterItemCollection col = new RepeaterItemCollection(items);
            return col;
         }
      }
      
      private object dataSource;
      [Category("Data"),Description("The data source with which to populate the control's list."),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      DefaultValue(null),Bindable(true)]
      public object DataSource
      {
         get
         {
            return dataSource;
         }
         set
         {
            if ((value is IEnumerable) || (value is IListSource) || (value == null))
               dataSource = value;
            else
               throw new Exception("Invalid DataSource type");
         }
      }

      [Category("Data"),Description("The table used for binding when a DataSet is used as a data source.")]
      public virtual string DataMember
      {
         get
         {
            object member = ViewState["DataMember"];
            if (member == null)
               return string.Empty;
            else
               return (string) member;
         }
         set
         {
            ViewState["DataMember"] = value;
         }
      }

      private RepeaterItem CreateItem(int itemIndex, ListItemType itemType,bool dataBind, object dataItem)
      {
         ITemplate selectedTemplate;

         switch (itemType)
         {
            case ListItemType.Header :
               selectedTemplate = headerTemplate;
               break;
            case ListItemType.Item :
               selectedTemplate = itemTemplate;
               break;
            case ListItemType.AlternatingItem :
               selectedTemplate = alternatingItemTemplate;
               break;
            case ListItemType.Separator :
               selectedTemplate = separatorTemplate;
               break;
            case ListItemType.Footer :
               selectedTemplate = footerTemplate;
               break;
            default:
               selectedTemplate = null;
               break;
         }

         if ((itemType == ListItemType.AlternatingItem) &&
            (alternatingItemTemplate == null))
         {
            selectedTemplate = itemTemplate;
            itemType = ListItemType.Item;
         }

         RepeaterItem item = new RepeaterItem(itemIndex, itemType, dataItem);

         if (selectedTemplate != null)
         {
            selectedTemplate.InstantiateIn(item);
         }

         OnItemCreated(new RepeaterItemEventArgs(item));

         Controls.Add(item);

         if (dataBind)
         {
            item.DataBind();
            OnItemDataBound(new RepeaterItemEventArgs(item));
         }
         return item;
      }
      
      private ArrayList items = null;
      private void CreateControlHierarchy(bool useDataSource)
      {
         items = new ArrayList();
         IEnumerable ds = null;

         if (HeaderTemplate != null)
         {
            RepeaterItem header = CreateItem(-1, ListItemType.Header, false, null);
         }

         int count = -1 ;
         if (useDataSource)
         {
            ds = (IEnumerable) DataSourceHelper.ResolveDataSource(DataSource,
               DataMember);
         }
         else
         {
            count = (int)ViewState["ItemCount"];
            if (count != -1)
            {
               ds = new DummyDataSource(count);
            }
         }

         if (ds != null)
         {
            int index = 0;
            count = 0;
            RepeaterItem item;
            ListItemType itemType = ListItemType.Item;

            foreach (object dataItem in (IEnumerable) ds)
            {
               if (index != 0)
               {
                  RepeaterItem separator = CreateItem(-1, ListItemType.Separator, false, null);
               }

               item = CreateItem(index, itemType, useDataSource, dataItem);
               items.Add(item);
               index++;
               count++;

               if (itemType == ListItemType.Item)
                  itemType = ListItemType.AlternatingItem;
               else
                  itemType = ListItemType.Item;
            }
         }

         if (FooterTemplate != null)
         {
            RepeaterItem footer = CreateItem(-1, ListItemType.Footer, false, null);
         }

         if (useDataSource)
         {
            ViewState["ItemCount"] = ((ds != null) ? count : -1);
         }
      }

      override protected void CreateChildControls()
      {
         Controls.Clear();
         if (ViewState["ItemCount"] != null)
         {
            CreateControlHierarchy(false);
         }
         ClearChildViewState();
      }

      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }

      public override void DataBind()
      {
         //Must call either this.OnDataBinding or base.OnDataBinding for the control to be able to
         //access or "see" design-time data sources at run-time.
         OnDataBinding(System.EventArgs.Empty); 
         Controls.Clear();
         ClearChildViewState();
         TrackViewState();

         CreateControlHierarchy(true);
         ChildControlsCreated = true;
      }

      protected override void OnDataBinding(EventArgs e)
      {
         base.OnDataBinding(e);
      }
      
      private static readonly object ItemCommandKey = new object();
      public event RepeaterCommandEventHandler ItemCommand
      {
         add
         {
            Events.AddHandler(ItemCommandKey, value);
         }
         remove
         {
            Events.RemoveHandler(ItemCommandKey, value);
         }
      }

      private static readonly object ItemCreatedKey = new object();
      public event RepeaterItemEventHandler ItemCreated
      {
         add
         {
            Events.AddHandler(ItemCreatedKey, value);
         }
         remove
         {
            Events.RemoveHandler(ItemCreatedKey, value);
         }
      }
      
      private static readonly object ItemDataBoundKey = new object();
      public event RepeaterItemEventHandler ItemDataBound
      {
         add
         {
            Events.AddHandler(ItemDataBoundKey, value);
         }
         remove
         {
            Events.RemoveHandler(ItemDataBoundKey, value);
         }
      }

      protected override bool OnBubbleEvent(object source, EventArgs e)
      {
         RepeaterCommandEventArgs rce = e as RepeaterCommandEventArgs;

         if (rce != null)
         {
            OnItemCommand(rce);
            return true;
         }
         else
            return false;
      }

      protected virtual void OnItemCommand(RepeaterCommandEventArgs rce)
      {
         RepeaterCommandEventHandler repeaterCommandEventDelegate =
            (RepeaterCommandEventHandler) Events[ItemCommandKey];
         if (repeaterCommandEventDelegate != null)
         {
            repeaterCommandEventDelegate(this, rce);
         }
      }

      protected virtual void OnItemCreated(RepeaterItemEventArgs rie)
      {
         RepeaterItemEventHandler repeaterItemEventDelegate =
            (RepeaterItemEventHandler) Events[ItemCreatedKey];
         if (repeaterItemEventDelegate != null)
         {
            repeaterItemEventDelegate(this, rie);
         }
      }

      protected virtual void OnItemDataBound(RepeaterItemEventArgs rie)
      {
         RepeaterItemEventHandler repeaterItemEventDelegate =
            (RepeaterItemEventHandler) Events[ItemDataBoundKey];
         if (repeaterItemEventDelegate != null)
         {
            repeaterItemEventDelegate(this, rie);
         }
      }
   }
}

