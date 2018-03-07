using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// A charts plot area
    /// </summary>
    public sealed class ExcelChartPlotArea :  XmlHelper
    {
        ExcelChart _firstChart;
        internal ExcelChartPlotArea(XmlNamespaceManager ns, XmlNode node, ExcelChart firstChart)
           : base(ns,node)
       {
           _firstChart = firstChart;
       }

        ExcelChartCollection _chartTypes;
        public ExcelChartCollection ChartTypes
        {
            get
            {
                if (_chartTypes == null)
                {
                    _chartTypes = new ExcelChartCollection(_firstChart); 
                }
                return _chartTypes;
            }
        }
        ExcelDrawingFill _fill = null;
        public ExcelDrawingFill Fill
        {
            get
            {
                if (_fill == null)
                {
                    _fill = new ExcelDrawingFill(NameSpaceManager, TopNode, "c:spPr");
                }
                return _fill;
            }
        }
        ExcelDrawingBorder _border = null;
        public ExcelDrawingBorder Border
        {
            get
            {
                if (_border == null)
                {
                    _border = new ExcelDrawingBorder(NameSpaceManager, TopNode, "c:spPr/a:ln");
                }
                return _border;
            }
        }
    }
}
