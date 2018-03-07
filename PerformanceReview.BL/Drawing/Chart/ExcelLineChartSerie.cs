using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// A serie for a line chart
    /// </summary>
    public sealed class ExcelLineChartSerie : ExcelChartSerie
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="chartSeries">Parent collection</param>
        /// <param name="ns">Namespacemanager</param>
        /// <param name="node">Topnode</param>
        /// <param name="isPivot">Is pivotchart</param>
        internal ExcelLineChartSerie(ExcelChartSeries chartSeries, XmlNamespaceManager ns, XmlNode node, bool isPivot) :
            base(chartSeries, ns, node, isPivot)
        {
        }
        ExcelChartSerieDataLabel _DataLabel = null;
        /// <summary>
        /// Datalabels
        /// </summary>
        public ExcelChartSerieDataLabel DataLabel
        {
            get
            {
                if (_DataLabel == null)
                {
                    _DataLabel = new ExcelChartSerieDataLabel(_ns, _node);
                }
                return _DataLabel;
            }
        }
        const string markerPath = "c:marker/c:symbol/@val";
        /// <summary>
        /// Marker symbol 
        /// </summary>
        public eMarkerStyle Marker
        {
            get
            {
                string marker = GetXmlNodeString(markerPath);
                if (marker == "")
                {
                    return eMarkerStyle.None;
                }
                else
                {
                    return (eMarkerStyle)Enum.Parse(typeof(eMarkerStyle), marker, true);
                }
            }
            set
            {
                SetXmlNodeString(markerPath, value.ToString().ToLower());
            }
        }
        const string smoothPath = "c:smooth/@val";
        /// <summary>
        /// Smoth lines
        /// </summary>
        public bool Smooth
        {
            get
            {
                return GetXmlNodeBool(smoothPath, false);
            }
            set
            {
                SetXmlNodeBool(smoothPath, value);
            }
        }
    }
}
