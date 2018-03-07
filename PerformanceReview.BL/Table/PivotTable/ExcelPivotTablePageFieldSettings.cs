using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OfficeOpenXml.Table.PivotTable
{
    /// <summary>
    /// A page / report filter field
    /// </summary>
    public class ExcelPivotTablePageFieldSettings  : XmlHelper
    {
        ExcelPivotTableField _field;
        internal ExcelPivotTablePageFieldSettings(XmlNamespaceManager ns, XmlNode topNode, ExcelPivotTableField field, int index) :
            base(ns, topNode)
        {
            if (GetXmlNodeString("@hier")=="")
            {
                Hier = -1;
            }
            _field = field;
        }
        internal int Index 
        { 
            get
            {
                return GetXmlNodeInt("@fld");
            }
            set
            {
                SetXmlNodeString("@fld",value.ToString());
            }
        }
        /// <summary>
        /// The Name of the field
        /// </summary>
        public string Name
        {
            get
            {
                return GetXmlNodeString("@name");
            }
            set
            {
                SetXmlNodeString("@name", value);
            }
        }
        /***** Dont work. Need items to be populated. ****/
        ///// <summary>
        ///// The selected item 
        ///// </summary>
        //public int SelectedItem
        //{
        //    get
        //    {
        //        return GetXmlNodeInt("@item");
        //    }
        //    set
        //    {
        //        if (value < 0) throw new InvalidOperationException("Can't be negative");
        //        SetXmlNodeString("@item", value.ToString());
        //    }
        //}
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
        internal int Hier
        {
            get
            {
                return GetXmlNodeInt("@hier");
            }
            set
            {
                SetXmlNodeString("@hier", value.ToString());
            }
        }
    }
}
