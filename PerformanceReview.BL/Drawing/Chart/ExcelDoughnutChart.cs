using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;
using OfficeOpenXml.Table.PivotTable;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// Provides access to doughnut chart specific properties
    /// </summary>
    public class ExcelDoughnutChart : ExcelPieChart
    {
        //internal ExcelDoughnutChart(ExcelDrawings drawings, XmlNode node) :
        //    base(drawings, node)
        //{
        //    SetPaths();
        //}
        internal ExcelDoughnutChart(ExcelDrawings drawings, XmlNode node, eChartType type, bool isPivot) :
            base(drawings, node, type, isPivot)
        {
            //SetPaths();
        }
        internal ExcelDoughnutChart(ExcelDrawings drawings, XmlNode node, eChartType type, ExcelChart topChart, ExcelPivotTable PivotTableSource) :
            base(drawings, node, type, topChart, PivotTableSource)
        {
            //SetPaths();
        }        
        internal ExcelDoughnutChart(ExcelDrawings drawings, XmlNode node, Uri uriChart, System.IO.Packaging.PackagePart part, XmlDocument chartXml, XmlNode chartNode) :
           base(drawings, node, uriChart, part, chartXml, chartNode)
        {
            //SetPaths();
        }

        internal ExcelDoughnutChart(ExcelChart topChart, XmlNode chartNode) :
            base(topChart, chartNode)
        {
            //SetPaths();
        }

        //private void SetPaths()
        //{
        //    string chartNodeText = GetChartNodeText();
        //    _firstSliceAngPath = string.Format(_firstSliceAngPath, chartNodeText);
        //    _holeSizePath = string.Format(_holeSizePath, chartNodeText);
        //}
        //string _firstSliceAngPath = "c:chartSpace/c:chart/c:plotArea/{0}/c:firstSliceAng/@val";
        string _firstSliceAngPath = "c:firstSliceAng/@val";
        /// <summary>
        /// Angle of the first slize
        /// </summary>
        public decimal FirstSliceAngle
        {
            get
            {
                return _chartXmlHelper.GetXmlNodeDecimal(_firstSliceAngPath);
            }
            internal set
            {
                _chartXmlHelper.SetXmlNodeString(_firstSliceAngPath, value.ToString(CultureInfo.InvariantCulture));
            }
        }
        //string _holeSizePath = "c:chartSpace/c:chart/c:plotArea/{0}/c:holeSize/@val";
        string _holeSizePath = "c:holeSize/@val";
        /// <summary>
        /// Size of the doubnut hole
        /// </summary>
        public decimal HoleSize
        {
            get
            {
                return _chartXmlHelper.GetXmlNodeDecimal(_holeSizePath);
            }
            internal set
            {
                _chartXmlHelper.SetXmlNodeString(_holeSizePath, value.ToString(CultureInfo.InvariantCulture));
            }
        }
        internal override eChartType GetChartType(string name)
        {
            if (name == "doughnutChart")
            {
                if (((ExcelPieChartSerie)Series[0]).Explosion > 0)
                {
                    return eChartType.DoughnutExploded;
                }
                else
                {
                    return eChartType.Doughnut;
                }
            }
            return base.GetChartType(name);
        }
    }
}
