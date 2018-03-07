using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.Style.XmlAccess;
using System.Globalization;

namespace OfficeOpenXml.Style
{
    /// <summary>
    /// The background fill of a cell
    /// </summary>
    public class ExcelFill : StyleBase
    {
        internal ExcelFill(ExcelStyles styles, OfficeOpenXml.XmlHelper.ChangedEventHandler ChangedEvent, int PositionID, string address, int index) :
            base(styles, ChangedEvent, PositionID, address)

        {
            Index = index;
        }
        /// <summary>
        /// The pattern for solid fills.
        /// </summary>
        public ExcelFillStyle PatternType
        {
            get
            {
                if (Index == int.MinValue)
                {
                    return ExcelFillStyle.None;
                }
                else
                {
                    return _styles.Fills[Index].PatternType;
                }
            }
            set
            {
                if (_gradient != null) _gradient = null;
                _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.Fill, eStyleProperty.PatternType, value, _positionID, _address));
            }
        }
        ExcelColor _patternColor = null;
        /// <summary>
        /// The color of the pattern
        /// </summary>
        public ExcelColor PatternColor
        {
            get
            {
                if (_patternColor == null)
                {
                    _patternColor = new ExcelColor(_styles, _ChangedEvent, _positionID, _address, eStyleClass.FillPatternColor, this);
                    if (_gradient != null) _gradient = null;
                }
                return _patternColor;
            }
        }
        ExcelColor _backgroundColor = null;
        /// <summary>
        /// The background color
        /// </summary>
        public ExcelColor BackgroundColor
        {
            get
            {
                if (_backgroundColor == null)
                {
                    _backgroundColor = new ExcelColor(_styles, _ChangedEvent, _positionID, _address, eStyleClass.FillBackgroundColor, this);
                    if (_gradient != null) _gradient = null;
                }
                return _backgroundColor;
                
            }
        }
        ExcelGradientFill _gradient=null;
        /// <summary>
        /// Access to properties for gradient fill.
        /// </summary>
        public ExcelGradientFill Gradient 
        {
            get
            {
                if (_gradient == null)
                {                    
                    _gradient = new ExcelGradientFill(_styles, _ChangedEvent, _positionID, _address, Index);
                    _backgroundColor = null;
                    _patternColor = null;
                }
                return _gradient;
            }
        }
        internal override string Id
        {
            get
            {
                if (_gradient == null)
                {
                    return PatternType + PatternColor.Id + BackgroundColor.Id;
                }
                else
                {
                    return _gradient.Id;
                }
            }
        }
    }
}
