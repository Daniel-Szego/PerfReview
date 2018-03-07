﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OfficeOpenXml.Style.XmlAccess;

namespace OfficeOpenXml.Table.PivotTable
{
    /// <summary>
    /// A pivo table data field
    /// </summary>
    public class ExcelPivotTableDataField : XmlHelper
    {
        internal ExcelPivotTableDataField(XmlNamespaceManager ns, XmlNode topNode,ExcelPivotTableField field) :
            base(ns, topNode)
        {
            if (topNode.Attributes.Count == 0)
            {
                Index = field.Index;
                BaseField = 0;
                BaseItem = 0;
            }
            
            Field = field;
        }
        /// <summary>
        /// The field
        /// </summary>
        public ExcelPivotTableField Field
        {
            get;
            private set;
        }
        /// <summary>
        /// The index of the datafield
        /// </summary>
        public int Index 
        { 
            get
            {
                return GetXmlNodeInt("@fld");
            }
            internal set
            {
                SetXmlNodeString("@fld",value.ToString());
            }
        }
        /// <summary>
        /// The name of the datafield
        /// </summary>
        public string Name
        {
            get
            {
                return GetXmlNodeString("@name");
            }
            set
            {
                if (Field._table.DataFields.ExistsDfName(value, this))
                {
                    throw (new InvalidOperationException("Duplicate datafield name"));
                }
                SetXmlNodeString("@name", value);
            }
        }
        /// <summary>
        /// Field index. Reference to the field collection
        /// </summary>
        public int BaseField
        {
            get
            {
                return GetXmlNodeInt("@baseField");
            }
            set
            {
                SetXmlNodeString("@baseField", value.ToString());
            }
        }
        /// <summary>
        /// Specifies the index to the base item when the ShowDataAs calculation is in use
        /// </summary>
        public int BaseItem
        {
            get
            {
                return GetXmlNodeInt("@baseItem");
            }
            set
            {
                SetXmlNodeString("@baseItem", value.ToString());
            }
        }
        /// <summary>
        /// Number format id. 
        /// </summary>
        internal int NumFmtId
        {
            get
            {
                return GetXmlNodeInt("@numFmtId");
            }
            set
            {
                SetXmlNodeString("@numFmtId", value.ToString());
            }
        }
        /// <summary>
        /// Number format for the data column
        /// </summary>
        public string Format
        {
            get
            {
                foreach (var nf in Field._table.WorkSheet.Workbook.Styles.NumberFormats)
                {
                    if (nf.NumFmtId == NumFmtId)
                    {
                        return nf.Format;
                    }
                }
                return Field._table.WorkSheet.Workbook.Styles.NumberFormats[0].Format;
            }
            set
            {
                var styles = Field._table.WorkSheet.Workbook.Styles;

                ExcelNumberFormatXml nf = null;
                if (!styles.NumberFormats.FindByID(value, ref nf))
                {
                    nf = new ExcelNumberFormatXml(NameSpaceManager) { Format = value, NumFmtId = styles.NumberFormats.NextId++ };
                    styles.NumberFormats.Add(value, nf);
                }
                NumFmtId = nf.NumFmtId;
            }
        }
        /// <summary>
        /// Type of aggregate function
        /// </summary>
        public DataFieldFunctions Function
        {
            get
            {
                string s=GetXmlNodeString("@subtotal");
                if(s=="")
                {
                    return DataFieldFunctions.None;
                }
                else
                {
                    return (DataFieldFunctions)Enum.Parse(typeof(DataFieldFunctions), s, true);
                }
            }
            set
            {
                string v;
                switch(value)
                {
                    case DataFieldFunctions.None:
                        DeleteNode("@subtotal");
                        return;
                    case DataFieldFunctions.CountNums:
                        v="CountNums";
                        break;
                    case DataFieldFunctions.StdDev:
                        v="stdDev";
                        break;
                    case DataFieldFunctions.StdDevP:
                        v="stdDevP";
                        break;
                    default:
                        v=value.ToString().ToLower();
                        break;
                }                
                SetXmlNodeString("@subtotal", v);
            }
        }
        ///Since we have no items, Excel will crash when we use showDataAs options that require baseItem's
        //public eShowDataAs ShowDataAs
        //{
        //    get
        //    {
        //        string s = GetXmlNodeString("@showDataAs");
        //        if (s == "")
        //        {
        //            return eShowDataAs.Normal;
        //        }
        //        else
        //        {
        //            return (eShowDataAs)Enum.Parse(typeof(eShowDataAs), s, true);
        //        }
        //    }
        //    set
        //    {
        //        string v = value.ToString();
        //        v = v.Substring(0, 1).ToLower() + v.Substring(1);
        //        SetXmlNodeString("@showDataAs", v);
        //    }
        //}
    }
}
