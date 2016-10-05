// Title: Building ASP.NET Server Controls
//
// Chapter: 7 - Templates and Databinding
// File: DataSourceHelper.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Collections;
using System.ComponentModel;

namespace ControlsBookLib.Ch07
{
   public class DataSourceHelper
   {
      public static object ResolveDataSource(object dataSource, string dataMember)
      {
         if (dataSource == null)
            return null;

         if (dataSource is IEnumerable)
         {
            return (IEnumerable) dataSource;
         }
         else if (dataSource is IListSource)
         {
            IList list = null;
            IListSource listSource = (IListSource) dataSource;
            list = listSource.GetList();
            if (listSource.ContainsListCollection)
            {
               ITypedList typedList = (ITypedList) list;
               PropertyDescriptorCollection propDescCol =
                  typedList.GetItemProperties(new PropertyDescriptor[0]);  //was (null)

               if (propDescCol.Count == 0)
                  throw new Exception("ListSource without DataMembers");

               PropertyDescriptor propDesc = null;
               //Check to see if dataMember has a value, if not, default to first
               //property (DataTable) in the property collection (DataTableCollection)
               if ((dataMember == null) || (dataMember.Length < 1))
               {
                  propDesc = propDescCol[0];
               }
               else  //If dataMember is set, try to find it in the property collection
                  propDesc = propDescCol.Find(dataMember,true);

               if (propDesc == null)
                  throw new Exception("ListSource missing DataMember");

               object listitem = list[0];

               //Get the value of the property (DataTable) of interest
               object member = propDesc.GetValue(listitem);

               if ((member == null) || !(member is IEnumerable))
                  throw new Exception("ListSource missing DataMember");

               return (IEnumerable) member;
            }
            else
               return (IEnumerable) list;  //robcamer added (IEnumerable)
         }
         return null;
      }
   }
}
