using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;

namespace OfficeOpenXml.Table.PivotTable
{
    /// <summary>
    /// Base class for pivot table field groups
    /// </summary>
    public class ExcelPivotTableFieldGroup : XmlHelper
    {
        internal ExcelPivotTableFieldGroup(XmlNamespaceManager ns, XmlNode topNode) :
            base(ns, topNode)
        {
            
        }
    }
    /// <summary>
    /// A date group
    /// </summary>
    public class ExcelPivotTableFieldDateGroup : ExcelPivotTableFieldGroup
    {
        internal ExcelPivotTableFieldDateGroup(XmlNamespaceManager ns, XmlNode topNode) :
            base(ns, topNode)
        {
        }
        const string groupByPath = "d:fieldGroup/d:rangePr/@groupBy";
        /// <summary>
        /// How to group the date field
        /// </summary>
        public eDateGroupBy GroupBy
        {
            get
            {
                string v = GetXmlNodeString(groupByPath);
                if (v != "")
                {
                    return (eDateGroupBy)Enum.Parse(typeof(eDateGroupBy), v, true);
                }
                else
                {
                    throw (new Exception("Invalid date Groupby"));
                }
            }
            private set
            {
                SetXmlNodeString(groupByPath, value.ToString().ToLower());
            }
        }
        /// <summary>
        /// Auto detect start date
        /// </summary>
        public bool AutoStart
        {
            get
            {
                return GetXmlNodeBool("@autoStart", false);
            }
        }
        /// <summary>
        /// Auto detect end date
        /// </summary>
        public bool AutoEnd
        {
            get
            {
                return GetXmlNodeBool("@autoStart", false);
            }
        }
    }
    /// <summary>
    /// A pivot table field numeric grouping
    /// </summary>
    public class ExcelPivotTableFieldNumericGroup : ExcelPivotTableFieldGroup
    {
        internal ExcelPivotTableFieldNumericGroup(XmlNamespaceManager ns, XmlNode topNode) :
            base(ns, topNode)
        {
        }
        const string startPath = "d:fieldGroup/d:rangePr/@startNum";
        /// <summary>
        /// Start value
        /// </summary>
        public double Start
        {
            get
            {
                return (double)GetXmlNodeDoubleNull(startPath);
            }
            private set
            {
                SetXmlNodeString(startPath,value.ToString(CultureInfo.InvariantCulture));
            }
        }
        const string endPath = "d:fieldGroup/d:rangePr/@endNum";
        /// <summary>
        /// End value
        /// </summary>
        public double End
        {
            get
            {
                return (double)GetXmlNodeDoubleNull(endPath);
            }
            private set
            {
                SetXmlNodeString(endPath, value.ToString(CultureInfo.InvariantCulture));
            }
        }
        const string groupIntervalPath = "d:fieldGroup/d:rangePr/@groupInterval";
        /// <summary>
        /// Interval
        /// </summary>
        public double Interval
        {
            get
            {
                return (double)GetXmlNodeDoubleNull(groupIntervalPath);
            }
            private set
            {
                SetXmlNodeString(groupIntervalPath, value.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
