﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO.Packaging;
using System.Collections;

namespace OfficeOpenXml.Drawing.Chart
{
   /// <summary>
   /// A chart serie
   /// </summary>
    public class ExcelChartSerie : XmlHelper
   {
       internal ExcelChartSeries _chartSeries;
       protected XmlNode _node;
       protected XmlNamespaceManager _ns;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="chartSeries">Parent collection</param>
        /// <param name="ns">Namespacemanager</param>
        /// <param name="node">Topnode</param>
       /// <param name="isPivot">Is pivotchart</param>
       internal ExcelChartSerie(ExcelChartSeries chartSeries, XmlNamespaceManager ns, XmlNode node, bool isPivot)
           : base(ns,node)
       {
           _chartSeries = chartSeries;
           _node=node;
           _ns=ns;
           SchemaNodeOrder = new string[] { "idx", "order", "tx", "marker","trendline", "explosion", "dLbls", "cat", "val", "yVal","xVal", "smooth" };

           if (chartSeries.Chart.ChartType == eChartType.XYScatter ||
               chartSeries.Chart.ChartType == eChartType.XYScatterLines ||
               chartSeries.Chart.ChartType == eChartType.XYScatterLinesNoMarkers ||
               chartSeries.Chart.ChartType == eChartType.XYScatterSmooth ||
               chartSeries.Chart.ChartType == eChartType.XYScatterSmoothNoMarkers)
           {
               _seriesTopPath = "c:yVal";
               _xSeriesTopPath = "c:xVal";
           }
           else
           {
               _seriesTopPath = "c:val";
               _xSeriesTopPath = "c:cat";
           }
           _seriesPath = string.Format(_seriesPath, _seriesTopPath);
           _xSeriesPath = string.Format(_xSeriesPath, _xSeriesTopPath, isPivot ? "c:multiLvlStrRef" : "c:numRef");
       }
       internal void SetID(string id)
       {
           SetXmlNodeString("c:idx/@val",id);
           SetXmlNodeString("c:order/@val", id);
       }
       const string headerPath="c:tx/c:v";
       /// <summary>
       /// Header for the serie.
       /// </summary>
       public string Header 
       {
           get
           {
                return GetXmlNodeString(headerPath);
            }
            set
            {
                Cleartx();
                SetXmlNodeString(headerPath, value);            
            }
        }

       private void Cleartx()
       {
           var n = TopNode.SelectSingleNode("c:tx", NameSpaceManager);
           if (n != null)
           {
               n.InnerXml = "";
           }
       }
       const string headerAddressPath = "c:tx/c:strRef/c:f";
        /// <summary>
       /// Header address for the serie.
       /// </summary>
       public ExcelAddressBase HeaderAddress
       {
           get
           {
               string address = GetXmlNodeString(headerAddressPath);
               if (address == "")
               {
                   return null;
               }
               else
               {
                   return new ExcelAddressBase(address);
               }
            }
            set
            {
                if (value._fromCol != value._toCol || value._fromRow != value._toRow || value.Addresses != null)
                {
                    throw (new Exception("Address must be a single cell"));
                }

                Cleartx();
                SetXmlNodeString(headerAddressPath, ExcelCell.GetFullAddress(value.WorkSheet, value.Address));
                SetXmlNodeString("c:tx/c:strRef/c:strCache/c:ptCount/@val", "0");
            }
        }        
        string _seriesTopPath;
        string _seriesPath = "{0}/c:numRef/c:f";       
       /// <summary>
       /// Set this to a valid address or the drawing will be invalid.
       /// </summary>
       public string Series
       {
           get
           {
               return GetXmlNodeString(_seriesPath);
           }
           set
           {
               if (_chartSeries.Chart.ChartType == eChartType.Bubble)
               {
                   throw(new Exception("Bubble charts is not supported yet"));
               }
               CreateNode(_seriesPath,true);
               SetXmlNodeString(_seriesPath, ExcelCellBase.GetFullAddress(_chartSeries.Chart.WorkSheet.Name, value));
               
               XmlNode cache = TopNode.SelectSingleNode(string.Format("{0}/c:numRef/c:numCache",_seriesTopPath), _ns);
               if (cache != null)
               {
                   cache.ParentNode.RemoveChild(cache);
               }

               if (_chartSeries.Chart.PivotTableSource != null)
               {
                   SetXmlNodeString(string.Format("{0}/c:numRef/c:numCache", _seriesTopPath), "General");
               }
               
               XmlNode lit = TopNode.SelectSingleNode(string.Format("{0}/c:numLit",_seriesTopPath), _ns);
               if (lit != null)
               {
                   lit.ParentNode.RemoveChild(lit);
               }
           }

       }
       string _xSeriesTopPath;
       string _xSeriesPath = "{0}/{1}/c:f";
       /// <summary>
       /// Set an address for the horisontal labels
       /// </summary>
       public string XSeries
       {
           get
           {
               return GetXmlNodeString(_xSeriesPath);
           }
           set
           {
               CreateNode(_xSeriesPath, true);
               SetXmlNodeString(_xSeriesPath, ExcelCellBase.GetFullAddress(_chartSeries.Chart.WorkSheet.Name, value));

               XmlNode cache = TopNode.SelectSingleNode(string.Format("{0}/c:numRef/c:numCache",_xSeriesTopPath), _ns);
               if (cache != null)
               {
                   cache.ParentNode.RemoveChild(cache);
               }

               XmlNode lit = TopNode.SelectSingleNode(string.Format("{0}/c:numLit",_xSeriesTopPath), _ns);
               if (lit != null)
               {
                   lit.ParentNode.RemoveChild(lit);
               }
           }
       }
       ExcelChartTrendlineCollection _trendLines = null;
       /// <summary>
       /// Access to the trendline collection
       /// </summary>
        public ExcelChartTrendlineCollection TrendLines
        {
            get
            {
                if (_trendLines == null)
                {
                    _trendLines = new ExcelChartTrendlineCollection(this);
                }
                return _trendLines;
            }
        }
   }
}
