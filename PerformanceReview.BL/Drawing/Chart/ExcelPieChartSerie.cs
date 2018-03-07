using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// A serie for a pie chart
    /// </summary>
    public sealed class ExcelPieChartSerie : ExcelChartSerie
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="chartSeries">Parent collection</param>
        /// <param name="ns">Namespacemanager</param>
        /// <param name="node">Topnode</param>
        /// <param name="isPivot">Is pivotchart</param>
        internal ExcelPieChartSerie(ExcelChartSeries chartSeries, XmlNamespaceManager ns, XmlNode node, bool isPivot) :
            base(chartSeries, ns, node, isPivot)
        {

        }
        const string explosionPath = "c:explosion/@val";
        /// <summary>
        /// Explosion for Piecharts
        /// </summary>
        public int Explosion
        {
            get
            {
                return GetXmlNodeInt(explosionPath);
            }
            set
            {
                if (value < 0 || value > 400)
                {
                    throw(new ArgumentOutOfRangeException("Explosion range is 0-400"));
                }
                SetXmlNodeString(explosionPath, value.ToString());
            }
        }
        ExcelChartSerieDataLabel _DataLabel = null;
        /// <summary>
        /// DataLabels
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
       
    }
}
