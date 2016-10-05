// Title: Building ASP.NET Server Controls
//
// Chapter: 12 - Design-Time Support
// File: RepeaterDesigner.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Web.UI;
using System.Web.UI.Design;
using ControlsBookLib.Ch07;

namespace ControlsBookLib.Ch12.Design
{
   public class RepeaterDesigner : ControlDesigner, IDataSourceProvider
   {
      public override void Initialize(IComponent component)
      {
         if (!(component is Ch07.Repeater))
         {
            throw new ArgumentException("Component must be a Ch07.Repeater", "component");
         }
         base.Initialize(component);
      }

      public string DataSource
      {
         get
         {
            DataBinding dataBinding = DataBindings["DataSource"];

            if (null != dataBinding)
            {
               return dataBinding.Expression;
            }
            else
            {
               return String.Empty;
            }
         }
         set
         {
            if ((0 == value.Length) || (null == value))
            {
               DataBindings.Remove("DataSource");
            }
            else
            {
               DataBinding dataBinding = DataBindings["DataSource"];

               if (null != dataBinding)
               {
                  dataBinding.Expression = value;
               }
               else
               {
                  dataBinding = new DataBinding("DataSource", typeof(IEnumerable), value);
               }
               DataBindings.Add(dataBinding);
            }
            OnBindingsCollectionChanged("DataSource");
         }
      }

      public string DataMember
      {
         get
         {
            return ((Ch07.Repeater)Component).DataMember;
         }
         set
         {
            ((Ch07.Repeater)Component).DataMember = value;
         }
      }

      protected override string GetEmptyDesignTimeHtml()
      {
         return CreatePlaceHolderDesignTimeHtml("Switch to HTML view to edit the control's templates.");
      }

      public override bool DesignTimeHtmlRequiresLoadComplete
      {
         get
         {
            return !(0 == DataSource.Length);
         }
      }

      protected override void PreFilterProperties(IDictionary properties)
      {
         base.PreFilterProperties(properties);

         PropertyDescriptor propertyDescriptor = (PropertyDescriptor)properties["DataSource"];
         if (null != propertyDescriptor)
         {
            System.ComponentModel.AttributeCollection runtimeAttributes = propertyDescriptor.Attributes;
            Attribute[] attrs = new Attribute[runtimeAttributes.Count + 1];

            runtimeAttributes.CopyTo(attrs, 0);
            attrs[runtimeAttributes.Count] = new TypeConverterAttribute(typeof(DataSourceConverter));
            propertyDescriptor = TypeDescriptor.CreateProperty(this.GetType(), "DataSource", typeof(string),
               attrs);
            properties["DataSource"] = propertyDescriptor;
         }

         propertyDescriptor = (PropertyDescriptor)properties["DataMember"];
         if (null != propertyDescriptor)
         {
            System.ComponentModel.AttributeCollection runtimeAttributes = propertyDescriptor.Attributes;
            Attribute[] attrs = new Attribute[runtimeAttributes.Count + 1];

            runtimeAttributes.CopyTo(attrs, 0);
            attrs[runtimeAttributes.Count] = new TypeConverterAttribute(typeof(DataMemberConverter));
            propertyDescriptor = TypeDescriptor.CreateProperty(this.GetType(), "DataMember", typeof(string),
               attrs);
            properties["DataMember"] = propertyDescriptor;
         }
      }

      object IDataSourceProvider.GetSelectedDataSource()
      {
         object selectedDataSource = null;
         string dataSource = null;

         DataBinding binding = DataBindings["DataSource"];
         if (binding != null)
         {
            dataSource = binding.Expression;
         }

         if (dataSource != null)
         {
            ISite componentSite = Component.Site;
            if (componentSite != null)
            {
               IContainer container = (IContainer)componentSite.GetService(
                  typeof(IContainer));

               if (container != null)
               {
                  IComponent comp = container.Components[dataSource];
                  if ((comp is IEnumerable) || (comp is IListSource))
                  {
                     selectedDataSource = comp;
                  }
               }
            }
         }

         return selectedDataSource;
      }

      IEnumerable IDataSourceProvider.GetResolvedSelectedDataSource()
      {
         object selectedDataSource =
            ((IDataSourceProvider)this).GetSelectedDataSource();

         DataView dataView = null;

         if (selectedDataSource is DataSet)
         {
            DataSet dataSet = (DataSet)selectedDataSource;
            DataTable dataTable = null;

            if ((DataMember != null) && (DataMember.Length>0))
               dataTable = dataSet.Tables[DataMember];
            else
               dataTable=dataSet.Tables[0];

            if (dataTable!=null)
            {
               dataView = dataTable.DefaultView;
            }
         }
         else if (selectedDataSource is DataTable)
         {
            dataView = ((DataTable)selectedDataSource).DefaultView;
         }
         else if (selectedDataSource is IEnumerable)
         {
            return selectedDataSource as IEnumerable;
         }

         return dataView as IEnumerable;
      }

      public override string GetDesignTimeHtml()
      {
         Ch07.Repeater repeater = (Ch07.Repeater)Component;
         string designerHTML = null;
         IEnumerable designerDataSource = GetDesignTimeDataSource(5);
         try
         {
            repeater.DataSource = designerDataSource;
            repeater.DataBind();
            designerHTML = base.GetDesignTimeHtml();
         }
         catch (Exception e)
         {
            designerHTML = GetErrorDesignTimeHtml(e);
         }
         finally
         {
            repeater.DataSource = null;
         }
         return designerHTML;
      }

      protected override string GetErrorDesignTimeHtml(Exception e)
      {
         return CreatePlaceHolderDesignTimeHtml("An error occured rendering the Ch07.Repeater.");
      }

      private DataTable dummyTable;
      private IEnumerable GetDesignTimeDataSource(int minimumRows)
      {
         IEnumerable selectedDataSource = ((IDataSourceProvider)this).GetResolvedSelectedDataSource();

         DataTable dtTable = new DataTable() ;

         if (dtTable == null)
         {
            if (selectedDataSource != null)
            {
               dtTable = DesignTimeData.CreateSampleDataTable(selectedDataSource);
            }

            if (dtTable == null)
            {
               if (dummyTable == null)
               {
                  dummyTable = DesignTimeData.CreateDummyDataTable();
               }

               dtTable = dummyTable;
            }
         }

         IEnumerable realDataSource = DesignTimeData.GetDesignTimeDataSource(dtTable, minimumRows);
         return realDataSource;
      }
   }
}