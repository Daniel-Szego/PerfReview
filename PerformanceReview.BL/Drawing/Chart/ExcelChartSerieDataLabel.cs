using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OfficeOpenXml.Style;

namespace OfficeOpenXml.Drawing.Chart
{
    /// <summary>
    /// Datalabel properties
    /// </summary>
    public sealed class ExcelChartSerieDataLabel : ExcelChartDataLabel
    {
       internal ExcelChartSerieDataLabel(XmlNamespaceManager ns, XmlNode node)
           : base(ns,node)
       {
           CreateNode(positionPath);
           Position = eLabelPosition.Center;
       }

       const string positionPath="c:dLblPos/@val";
       /// <summary>
       /// Position of the labels
       /// </summary>
       public eLabelPosition Position
       {
           get
           {
               return GetPosEnum(GetXmlNodeString(positionPath));
           }
           set
           {
               SetXmlNodeString(positionPath,GetPosText(value));
           }
       }
       ExcelDrawingFill _fill = null;
       /// <summary>
       /// Access fill properties
       /// </summary>
        public new ExcelDrawingFill Fill
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
       /// Access border properties
       /// </summary>
        public new ExcelDrawingBorder Border
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
       /// Access font properties
       /// </summary>
        public new ExcelTextFont Font
       {
           get
           {
               if (_font == null)
               {
                   if (TopNode.SelectSingleNode("c:txPr", NameSpaceManager) == null)
                   {
                       CreateNode("c:txPr/a:bodyPr");
                       CreateNode("c:txPr/a:lstStyle");
                   }
                   _font = new ExcelTextFont(NameSpaceManager, TopNode, "c:txPr/a:p/a:pPr/a:defRPr", new string[] { "spPr", "txPr", "dLblPos", "showVal", "showCatName ", "pPr", "defRPr", "solidFill", "uFill", "latin", "cs", "r", "rPr", "t" });
               }
               return _font;
           }
       }
    }
}
