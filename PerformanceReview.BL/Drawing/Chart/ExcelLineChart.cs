﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO.Packaging;
using OfficeOpenXml.Table.PivotTable;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// Provides access to line chart specific properties
    /// </summary>
    public class ExcelLineChart : ExcelChart
    {
        #region "Constructors"
        internal ExcelLineChart(ExcelDrawings drawings, XmlNode node, Uri uriChart, PackagePart part, XmlDocument chartXml, XmlNode chartNode) :
            base(drawings, node, uriChart, part, chartXml, chartNode)
        {
        }

        internal ExcelLineChart(ExcelChart topChart, XmlNode chartNode) :
            base(topChart, chartNode)
        {
        }
        internal ExcelLineChart(ExcelDrawings drawings, XmlNode node, eChartType type, ExcelChart topChart, ExcelPivotTable PivotTableSource) :
            base(drawings, node, type, topChart, PivotTableSource)
        {
            Smooth = false;
        }
        #endregion
        string MARKER_PATH="c:marker/@val";
        /// <summary>
        /// If the series has markers
        /// </summary>
        public bool Marker
        {
            get
            {
                return _chartXmlHelper.GetXmlNodeBool(MARKER_PATH, false);
            }
            set
            {
                _chartXmlHelper.SetXmlNodeBool(MARKER_PATH, value, false);
            }
        }

        string SMOOTH_PATH = "c:smooth/@val";
        /// <summary>
        /// If the series has smooth lines
        /// </summary>
        public bool Smooth
        {
            get
            {
                return _chartXmlHelper.GetXmlNodeBool(SMOOTH_PATH, false);
            }
            set
            {
                _chartXmlHelper.SetXmlNodeBool(SMOOTH_PATH, value);
            }
        }
        //string _chartTopPath = "c:chartSpace/c:chart/c:plotArea/{0}";
        ExcelChartDataLabel _DataLabel = null;
        /// <summary>
        /// Access to datalabel properties
        /// </summary>
        public ExcelChartDataLabel DataLabel
        {
            get
            {
                if (_DataLabel == null)
                {
                    _DataLabel = new ExcelChartDataLabel(NameSpaceManager, ChartNode);
                }
                return _DataLabel;
            }
        }
        internal override eChartType GetChartType(string name)
        {
               if(name=="lineChart")
               {
                   if(Marker)
                   {
                       if(Grouping==eGrouping.Stacked)
                       {
                           return eChartType.LineMarkersStacked;
                       }
                       else if (Grouping == eGrouping.PercentStacked)
                       {
                           return eChartType.LineMarkersStacked100;
                       }
                       else
                       {
                           return eChartType.LineMarkers;
                       }
                   }
                   else
                   {
                       if(Grouping==eGrouping.Stacked)
                       {
                           return eChartType.LineStacked;
                       }
                       else if (Grouping == eGrouping.PercentStacked)
                       {
                           return eChartType.LineStacked100;
                       }
                       else
                       {
                           return eChartType.Line;
                       }
                   }
               }
               else if (name=="line3DChart")
               {
                   return eChartType.Line3D;               
               }
               return base.GetChartType(name);
        }
    }
}
