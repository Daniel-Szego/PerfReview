using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.Style.XmlAccess;
using System.Drawing;

namespace OfficeOpenXml.Style
{
    /// <summary>
    /// Color for cellstyling
    /// </summary>
    public sealed class ExcelColor :  StyleBase
    {
        eStyleClass _cls;
        StyleBase _parent;
        internal ExcelColor(ExcelStyles styles, OfficeOpenXml.XmlHelper.ChangedEventHandler ChangedEvent, int worksheetID, string address, eStyleClass cls, StyleBase parent) : 
            base(styles, ChangedEvent, worksheetID, address)
            
        {
            _parent = parent;
            _cls = cls;
        }
        /// <summary>
        /// The theme color
        /// </summary>
        public string Theme
        {
            get
            {
                return GetSource().Theme;
            }
        }
        /// <summary>
        /// The tint value
        /// </summary>
        public decimal Tint
        {
            get
            {
                return GetSource().Tint;
            }
            set
            {
                if (value > 1 || value < -1)
                {
                    throw (new ArgumentOutOfRangeException("Value must be between -1 and 1"));
                }
                _ChangedEvent(this, new StyleChangeEventArgs(_cls, eStyleProperty.Tint, value, _positionID, _address));
            }
        }
        /// <summary>
        /// The RGB value
        /// </summary>
        public string Rgb
        {
            get
            {
                return GetSource().Rgb;
            }
            internal set
            {
                _ChangedEvent(this, new StyleChangeEventArgs(_cls, eStyleProperty.Color, value, _positionID, _address));
            }
        }
        /// <summary>
        /// The indexed color number.
        /// </summary>
        public int Indexed
        {
            get
            {
                return GetSource().Indexed;
            }
            set
            {
                _ChangedEvent(this, new StyleChangeEventArgs(_cls, eStyleProperty.IndexedColor, value, _positionID, _address));
            }
        }
        /// <summary>
        /// Set the color of the object
        /// </summary>
        /// <param name="color">The color</param>
        public void SetColor(Color color)
        {
            Rgb = color.ToArgb().ToString("X");
        }


        internal override string Id
        {
            get 
            {
                return Theme + Tint + Rgb + Indexed;
            }
        }
        private ExcelColorXml GetSource()
        {
            Index = _parent.Index < 0 ? 0 : _parent.Index;
            switch(_cls)
            {
                case eStyleClass.FillBackgroundColor:
                    return _styles.Fills[Index].BackgroundColor;
                case eStyleClass.FillPatternColor:
                    return _styles.Fills[Index].PatternColor;
                case eStyleClass.Font:
                    return _styles.Fonts[Index].Color;
                case eStyleClass.BorderLeft:
                    return _styles.Borders[Index].Left.Color;
                case eStyleClass.BorderTop:
                    return _styles.Borders[Index].Top.Color;
                case eStyleClass.BorderRight:
                    return _styles.Borders[Index].Right.Color;
                case eStyleClass.BorderBottom:
                    return _styles.Borders[Index].Bottom.Color;
                case eStyleClass.BorderDiagonal:
                    return _styles.Borders[Index].Diagonal.Color;
                default:
                    throw(new Exception("Invalid style-class for Color"));
            }
        }
        internal override void SetIndex(int index)
        {
            _parent.Index = index;
        }
    }
}
