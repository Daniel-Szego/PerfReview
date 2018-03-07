﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;
namespace OfficeOpenXml.Style.XmlAccess
{
    /// <summary>
    /// Xml access class for color
    /// </summary>
    public sealed class ExcelColorXml : StyleXmlHelper
    {
        internal ExcelColorXml(XmlNamespaceManager nameSpaceManager)
            : base(nameSpaceManager)
        {
            _auto = false;
            _theme = "";
            _tint = 0;
            _rgb = "";
            _indexed = int.MinValue;
        }
        internal ExcelColorXml(XmlNamespaceManager nsm, XmlNode topNode) :
            base(nsm, topNode)
        {
            if(topNode==null)
            {
                _exists=false;
            }
            else
            {
                _exists = true;
                _auto = GetXmlNodeBool("@auto");
                _theme = GetXmlNodeString("@theme");
                _tint = GetXmlNodeDecimal("@tint");
                _rgb = GetXmlNodeString("@rgb");
                _indexed = GetXmlNodeInt("@indexed");
            }
        }
        
        internal override string Id
        {
            get
            {
                return _auto.ToString() + "|" + _theme + "|" + _tint + "|" + _rgb + "|" + _indexed;
            }
        }
        bool _auto;
        public bool Auto
        {
            get
            {
                return _auto;
            }
            set
            {
                if (value)
                {

                }
                _auto = value;
                _exists = true;
                Clear();
            }
        }
        string _theme;
        /// <summary>
        /// Theme color value
        /// </summary>
        public string Theme
        {
            get
            {
                return _theme;
            }
        }
        decimal _tint;
        /// <summary>
        /// Tint
        /// </summary>
        public decimal Tint
        {
            get
            {
                return _tint;
            }
            set
            {
                _tint = value;
                _exists = true;
            }
        }
        string _rgb;
        /// <summary>
        /// RGB value
        /// </summary>
        public string Rgb
        {
            get
            {
                return _rgb;
            }
            set
            {
                _rgb = value;
                _exists=true;
                _indexed = int.MinValue;
                _auto = false;
            }
        }
        int _indexed;
        /// <summary>
        /// Indexed color value
        /// </summary>
        public int Indexed
        {
            get
            {
              return _indexed;
            }
            set
            {
                if (value < 0 || value > 65)
                {
                    throw (new ArgumentOutOfRangeException("Index out of range"));
                }
                Clear();
                _indexed = value;
                _exists = true;
            }
        }
        internal void Clear()
        {
            _theme = "";
            _tint = decimal.MaxValue;
            _indexed = int.MinValue;
            _rgb = "";
            _auto = false;
        }
        public void SetColor(System.Drawing.Color color)
        {
            Clear();
            _rgb = color.ToArgb().ToString("X");
        }

        internal ExcelColorXml Copy()
        {
            return new ExcelColorXml(NameSpaceManager) {_indexed=Indexed, _tint=Tint, _rgb=Rgb, _theme=Theme, _auto=Auto, _exists=Exists };
        }

        internal override XmlNode CreateXmlNode(XmlNode topNode)
        {
            TopNode = topNode;
            if(_rgb!="")
            {
                SetXmlNodeString("@rgb", _rgb);
            }
            else if (_indexed >= 0)
            {
                SetXmlNodeString("@indexed", _indexed.ToString());
            }
            else if (_auto)
            {
                SetXmlNodeBool("@auto", _auto);
            }
            else
            {
                SetXmlNodeString("@theme", _theme.ToString());
            }
            if (_tint != decimal.MaxValue)
            {
                SetXmlNodeString("@tint", _tint.ToString(CultureInfo.InvariantCulture));
            }
            return TopNode;
        }

        bool _exists;
        internal bool Exists
        {
            get
            {
                return _exists;
            }
        }
    }
}
