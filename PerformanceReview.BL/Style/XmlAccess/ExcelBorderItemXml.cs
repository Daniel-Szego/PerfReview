using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using OfficeOpenXml.Style;
namespace OfficeOpenXml.Style.XmlAccess
{
    /// <summary>
    /// Xml access class for border items
    /// </summary>
    public sealed class ExcelBorderItemXml : StyleXmlHelper
    {
        internal ExcelBorderItemXml(XmlNamespaceManager nameSpaceManager) : base(nameSpaceManager)
        {
            _borderStyle=ExcelBorderStyle.None;
            _color = new ExcelColorXml(NameSpaceManager);
        }
        internal ExcelBorderItemXml(XmlNamespaceManager nsm, XmlNode topNode) :
            base(nsm, topNode)
        {
            if (topNode != null)
            {
                _borderStyle = GetBorderStyle(GetXmlNodeString("@style"));
                _color = new ExcelColorXml(nsm, topNode.SelectSingleNode(_colorPath, nsm));
                Exists = true;
            }
            else
            {
                Exists = false;
            }
        }

        private ExcelBorderStyle GetBorderStyle(string style)
        {
            if(style=="") return ExcelBorderStyle.None;
            string sInStyle = style.Substring(0, 1).ToUpper() + style.Substring(1, style.Length - 1);
            try
            {
                return (ExcelBorderStyle)Enum.Parse(typeof(ExcelBorderStyle), sInStyle);
            }
            catch
            {
                return ExcelBorderStyle.None;
            }

        }
        ExcelBorderStyle _borderStyle = ExcelBorderStyle.None;
        /// <summary>
        /// Cell Border style
        /// </summary>
        public ExcelBorderStyle Style
        {
            get
            {
                return _borderStyle;
            }
            set
            {
                _borderStyle = value;
                Exists = true;
            }
        }
        ExcelColorXml _color = null;
        const string _colorPath = "d:color";
        /// <summary>
        /// Border style
        /// </summary>
        public ExcelColorXml Color
        {
            get
            {
                return _color;
            }
            internal set
            {
                _color = value;
            }
        }
        internal override string Id
        {
            get 
            {
                if (Exists)
                {
                    return Style + Color.Id;
                }
                else
                {
                    return "None";
                }
            }
        }

        internal ExcelBorderItemXml Copy()
        {
            ExcelBorderItemXml borderItem = new ExcelBorderItemXml(NameSpaceManager);
            borderItem.Style = _borderStyle;
            borderItem.Color = _color.Copy();
            return borderItem;
        }

        internal override XmlNode CreateXmlNode(XmlNode topNode)
        {
            TopNode = topNode;

            if (Style != ExcelBorderStyle.None)
            {
                SetXmlNodeString("@style", SetBorderString(Style));
                if (Color.Exists)
                {
                    CreateNode(_colorPath);
                    topNode.AppendChild(Color.CreateXmlNode(TopNode.SelectSingleNode(_colorPath,NameSpaceManager)));
                }
            }
            return TopNode;
        }

        private string SetBorderString(ExcelBorderStyle Style)
        {
            string newName=Enum.GetName(typeof(ExcelBorderStyle), Style);
            return newName.Substring(0, 1).ToLower() + newName.Substring(1, newName.Length - 1);
        }
        public bool Exists { get; private set; }
    }
}
