using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.Style.XmlAccess;

namespace OfficeOpenXml.Style
{
    /// <summary>
    /// Cell border style
    /// </summary>
    public sealed class ExcelBorderItem : StyleBase
    {
        eStyleClass _cls;
        StyleBase _parent;
        internal ExcelBorderItem (ExcelStyles styles, OfficeOpenXml.XmlHelper.ChangedEventHandler ChangedEvent, int worksheetID, string address, eStyleClass cls, StyleBase parent) : 
            base(styles, ChangedEvent, worksheetID, address)
	    {
            _cls=cls;
            _parent = parent;
	    }
        /// <summary>
        /// The line style of the border
        /// </summary>
        public ExcelBorderStyle Style
        {
            get
            {
                return GetSource().Style;
            }
            set
            {
                _ChangedEvent(this, new StyleChangeEventArgs(_cls, eStyleProperty.Style, value, _positionID, _address));
            }
        }
        ExcelColor _color=null;
        /// <summary>
        /// The color of the border
        /// </summary>
        public ExcelColor Color
        {
            get
            {
                if (_color == null)
                {
                    _color = new ExcelColor(_styles, _ChangedEvent, _positionID, _address, _cls, _parent);
                }
                return _color;
            }
        }

        internal override string Id
        {
            get { return Style + Color.Id; }
        }
        internal override void SetIndex(int index)
        {
            _parent.Index = index;
        }
        private ExcelBorderItemXml GetSource()
        {
            int ix = _parent.Index < 0 ? 0 : _parent.Index;

            switch(_cls)
            {
                case eStyleClass.BorderTop:
                    return _styles.Borders[ix].Top;
                case eStyleClass.BorderBottom:
                    return _styles.Borders[ix].Bottom;
                case eStyleClass.BorderLeft:
                    return _styles.Borders[ix].Left;
                case eStyleClass.BorderRight:
                    return _styles.Borders[ix].Right;
                case eStyleClass.BorderDiagonal:
                    return _styles.Borders[ix].Diagonal;
                default:
                    throw new Exception("Invalid class for Borderitem");
            }

        }
    }
}
