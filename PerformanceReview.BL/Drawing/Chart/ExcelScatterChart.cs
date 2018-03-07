using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO.Packaging;
using OfficeOpenXml.Table.PivotTable;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// Provides access to scatter chart specific properties
    /// </summary>
    public sealed class ExcelScatterChart : ExcelChart
    {
        internal ExcelScatterChart(ExcelDrawings drawings, XmlNode node, eChartType type, ExcelChart topChart, ExcelPivotTable PivotTableSource) :
            base(drawings, node, type, topChart, PivotTableSource)
        {
            SetTypeProperties();
        }

        internal ExcelScatterChart(ExcelDrawings drawings, XmlNode node, Uri uriChart, PackagePart part, XmlDocument chartXml, XmlNode chartNode) :
            base(drawings, node, uriChart, part, chartXml, chartNode)
        {
            SetTypeProperties();
        }

        internal ExcelScatterChart(ExcelChart topChart, XmlNode chartNode) :
            base(topChart, chartNode)
        {
            SetTypeProperties();
        }
        private void SetTypeProperties()
        {
           /***** ScatterStyle *****/
           if(ChartType == eChartType.XYScatter ||
              ChartType == eChartType.XYScatterLines ||
              ChartType == eChartType.XYScatterLinesNoMarkers)
           {
               ScatterStyle = eScatterStyle.LineMarker;
          }
           else if (
              ChartType == eChartType.XYScatterSmooth ||
              ChartType == eChartType.XYScatterSmoothNoMarkers) 
           {
               ScatterStyle = eScatterStyle.SmoothMarker;
           }
        }
        #region "Grouping Enum Translation"
        string _scatterTypePath = "c:scatterStyle/@val";
        private eScatterStyle GetScatterEnum(string text)
        {
            switch (text)
            {
                case "smoothMarker":
                    return eScatterStyle.SmoothMarker;
                default:
                    return eScatterStyle.LineMarker;
            }
        }

        private string GetScatterText(eScatterStyle shatterStyle)
        {
            switch (shatterStyle)
            {
                case eScatterStyle.SmoothMarker:
                    return "smoothMarker";
                default:
                    return "lineMarker";
            }
        }
        #endregion
        /// <summary>
        /// If the scatter has LineMarkers or SmoothMarkers
        /// </summary>
        public eScatterStyle ScatterStyle
        {
            get
            {
                return GetScatterEnum(_chartXmlHelper.GetXmlNodeString(_scatterTypePath));
            }
            internal set
            {
                _chartXmlHelper.CreateNode(_scatterTypePath, true);
                _chartXmlHelper.SetXmlNodeString(_scatterTypePath, GetScatterText(value));
            }
        }
        string MARKER_PATH = "c:marker/@val";
        /// <summary>
        /// If the series has markers
        /// </summary>
        public bool Marker
        {
            get
            {
                return GetXmlNodeBool(MARKER_PATH, false);
            }
            set
            {
                SetXmlNodeBool(MARKER_PATH, value, false);
            }
        }

        internal override eChartType GetChartType(string name)
        {
            if (name == "scatterChart")
            {
                if (ScatterStyle==eScatterStyle.LineMarker)
                {
                    if (((ExcelScatterChartSerie)Series[0]).Marker == eMarkerStyle.None)
                    {
                        return eChartType.XYScatterLinesNoMarkers;
                    }
                    else
                    {
                        if(ExistNode("c:ser/c:spPr/a:ln/noFill"))
                        {
                            return eChartType.XYScatter;
                        }
                        else
                        {
                            return eChartType.XYScatterLines;
                        }
                    }
                }
                else if (ScatterStyle == eScatterStyle.SmoothMarker)
                {
                    if (((ExcelScatterChartSerie)Series[0]).Marker == eMarkerStyle.None)
                    {
                        return eChartType.XYScatterSmoothNoMarkers;
                    }
                    else
                    {
                        return eChartType.XYScatterSmooth;
                    }
                }
            }
            return base.GetChartType(name);
        }

    }
}
