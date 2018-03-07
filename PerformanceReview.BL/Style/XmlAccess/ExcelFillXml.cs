using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace OfficeOpenXml.Style.XmlAccess
{
    /// <summary>
    /// Xml access class for fills
    /// </summary>
    public class ExcelFillXml : StyleXmlHelper 
    {
        internal ExcelFillXml(XmlNamespaceManager nameSpaceManager)
            : base(nameSpaceManager)
        {
            _fillPatternType = ExcelFillStyle.None;
            _backgroundColor = new ExcelColorXml(NameSpaceManager);
            _patternColor = new ExcelColorXml(NameSpaceManager);
        }
        internal ExcelFillXml(XmlNamespaceManager nsm, XmlNode topNode):
            base(nsm, topNode)
        {
            PatternType = GetPatternType(GetXmlNodeString(fillPatternTypePath));
            _backgroundColor = new ExcelColorXml(nsm, topNode.SelectSingleNode(_backgroundColorPath, nsm));
            _patternColor = new ExcelColorXml(nsm, topNode.SelectSingleNode(_patternColorPath, nsm));
        }

        private ExcelFillStyle GetPatternType(string patternType)
        {
            if (patternType == "") return ExcelFillStyle.None;
            patternType = patternType.Substring(0, 1).ToUpper() + patternType.Substring(1, patternType.Length - 1);
            try
            {
                return (ExcelFillStyle)Enum.Parse(typeof(ExcelFillStyle), patternType);
            }
            catch
            {
                return ExcelFillStyle.None;
            }
        }
        internal override string Id
        {
            get
            {
                return PatternType + PatternColor.Id + BackgroundColor.Id;
            }
        }
        #region Public Properties
        const string fillPatternTypePath = "d:patternFill/@patternType";
        protected ExcelFillStyle _fillPatternType;
        /// <summary>
        /// Cell fill pattern style
        /// </summary>
        public ExcelFillStyle PatternType
        {
            get
            {
                return _fillPatternType;
            }
            set
            {
                _fillPatternType=value;
            }
        }
        protected ExcelColorXml _patternColor = null;
        const string _patternColorPath = "d:patternFill/d:bgColor";
        /// <summary>
        /// Pattern color
        /// </summary>
        public ExcelColorXml PatternColor
        {
            get
            {
                return _patternColor;
            }
            internal set
            {
                _patternColor = value;
            }
        }
        protected ExcelColorXml _backgroundColor = null;
        const string _backgroundColorPath = "d:patternFill/d:fgColor";
        /// <summary>
        /// Cell background color 
        /// </summary>
        public ExcelColorXml BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            internal set
            {
                _backgroundColor=value;
            }
        }
        #endregion


        //internal Fill Copy()
        //{
        //    Fill newFill = new Fill(NameSpaceManager, TopNode.Clone());
        //    return newFill;
        //}

        internal virtual ExcelFillXml Copy()
        {
            ExcelFillXml newFill = new ExcelFillXml(NameSpaceManager);
            newFill.PatternType = _fillPatternType;
            newFill.BackgroundColor = _backgroundColor.Copy();
            newFill.PatternColor = _patternColor.Copy();
            return newFill;
        }

        internal override XmlNode CreateXmlNode(XmlNode topNode)
        {
            TopNode = topNode;
            SetXmlNodeString(fillPatternTypePath, SetPatternString(_fillPatternType));
            if (PatternType != ExcelFillStyle.None)
            {
                XmlNode pattern = topNode.SelectSingleNode(fillPatternTypePath, NameSpaceManager);
                if (BackgroundColor.Exists)
                {
                    CreateNode(_backgroundColorPath);
                    BackgroundColor.CreateXmlNode(topNode.SelectSingleNode(_backgroundColorPath, NameSpaceManager));
                    if (PatternColor.Exists)
                    {
                        CreateNode(_patternColorPath);
                        //topNode.AppendChild(PatternColor.CreateXmlNode(topNode.SelectSingleNode(_patternColorPath, NameSpaceManager)));
                        PatternColor.CreateXmlNode(topNode.SelectSingleNode(_patternColorPath, NameSpaceManager));
                    }
                }
            }
            return topNode;
        }

        private string SetPatternString(ExcelFillStyle pattern)
        {
            string newName = Enum.GetName(typeof(ExcelFillStyle), pattern);
            return newName.Substring(0, 1).ToLower() + newName.Substring(1, newName.Length - 1);
        }
    }
}
