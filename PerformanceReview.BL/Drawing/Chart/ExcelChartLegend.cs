using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OfficeOpenXml.Style;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// Position of the legend
    /// </summary>
    public enum eLegendPosition
    {
        Top,
        Left,
        Right,
        Bottom,
        TopRight
    }
    /// <summary>
    /// Chart ledger
    /// </summary>
    public class ExcelChartLegend : XmlHelper
    {
        ExcelChart _chart;
        internal ExcelChartLegend(XmlNamespaceManager ns, XmlNode node, ExcelChart chart)
           : base(ns,node)
       {
           _chart=chart;
           SchemaNodeOrder = new string[] { "legendPos", "layout","overlay", "txPr", "bodyPr", "lstStyle", "spPr" };
       }
        const string POSITION_PATH = "c:legendPos/@val";
        /// <summary>
        /// Position of the Legend
        /// </summary>
        public eLegendPosition Position 
        {
            get
            {
                switch(GetXmlNodeString(POSITION_PATH).ToLower())
                {
                    case "t":
                        return eLegendPosition.Top;
                    case "b":
                        return eLegendPosition.Bottom;
                    case "l":
                        return eLegendPosition.Left;
                    case "tr":
                        return eLegendPosition.TopRight;
                    default:
                        return eLegendPosition.Right;
                }
            }
            set
            {
                if (TopNode == null) throw(new Exception("Can't set position. Chart has no legend"));
                switch (value)
                {
                    case eLegendPosition.Top:
                        SetXmlNodeString(POSITION_PATH, "t");
                        break;
                    case eLegendPosition.Bottom:
                        SetXmlNodeString(POSITION_PATH, "b");
                        break;
                    case eLegendPosition.Left:
                        SetXmlNodeString(POSITION_PATH, "l");
                        break;
                    case eLegendPosition.TopRight:
                        SetXmlNodeString(POSITION_PATH, "tr");
                        break;
                    default:
                        SetXmlNodeString(POSITION_PATH, "r");
                        break;
                }
            }
        }
        const string OVERLAY_PATH = "c:overlay/@val";
        /// <summary>
        /// If the legend overlays other objects
        /// </summary>
        public bool Overlay
        {
            get
            {
                return GetXmlNodeBool(OVERLAY_PATH);
            }
            set
            {
                if (TopNode == null) throw (new Exception("Can't set overlay. Chart has no legend"));
                SetXmlNodeBool(OVERLAY_PATH, value);
            }
        }
        ExcelDrawingFill _fill = null;
        /// <summary>
        /// Fill style
        /// </summary>
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
        /// <summary>
        /// Border style
        /// </summary>
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
        ExcelTextFont _font = null;
        /// <summary>
        /// Font properties
        /// </summary>
        public ExcelTextFont Font
        {
            get
            {
                if (_font == null)
                {
                    if (TopNode.SelectSingleNode("c:txPr",NameSpaceManager) == null)
                    {
                        CreateNode("c:txPr/a:bodyPr");
                        CreateNode("c:txPr/a:lstStyle");
                    }
                    _font = new ExcelTextFont(NameSpaceManager, TopNode, "c:txPr/a:p/a:pPr/a:defRPr", new string[] { "legendPos", "layout", "pPr", "defRPr", "solidFill", "uFill", "latin", "cs", "r", "rPr", "t" });
                }
                return _font;
            }
        }
        /// <summary>
        /// Remove the legend
        /// </summary>
        public void Remove()
        {
            if (TopNode == null) return;
            TopNode.ParentNode.RemoveChild(TopNode);
            TopNode = null;
        }
        /// <summary>
        /// Add a legend to the chart
        /// </summary>
        public void Add()
        {
            if(TopNode!=null) return;

            //XmlHelper xml = new XmlHelper(NameSpaceManager, _chart.ChartXml);
            XmlHelper xml = XmlHelperFactory.Create(NameSpaceManager, _chart.ChartXml);
            xml.SchemaNodeOrder=_chart.SchemaNodeOrder;

            xml.CreateNode("c:chartSpace/c:chart/c:legend");
            TopNode = _chart.ChartXml.SelectSingleNode("c:chartSpace/c:chart/c:legend", NameSpaceManager);
            TopNode.InnerXml="<c:legendPos val=\"r\" /><c:layout />";                        
        }
    }
}
