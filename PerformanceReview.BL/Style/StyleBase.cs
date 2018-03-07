using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeOpenXml.Style
{
    /// <summary>
    /// Border line style
    /// </summary>
    public enum ExcelBorderStyle
    {
        None,
        Hair,
        Dotted,
        DashDot,
        Thin,
        DashDotDot,
        Dashed,
        MediumDashDotDot,
        MediumDashed,
        MediumDashDot,
        Thick,
        Medium,
        Double
    };
    /// <summary>
    /// Horizontal text alignment
    /// </summary>
    public enum ExcelHorizontalAlignment
    {
        General,
        Left,
        Center,
        CenterContinuous,
        Right,
        Fill,
        Distributed,
        Justify
    }
    /// <summary>
    /// Vertical text alignment
    /// </summary>
    public enum ExcelVerticalAlignment
    {
        Top,
        Center,
        Bottom,
        Distributed,
        Justify
    }
    /// <summary>
    /// Font-Vertical Align
    /// </summary>
    public enum ExcelVerticalAlignmentFont
    {
        None,
        Subscript,
        Superscript
    }
    /// <summary>
    /// Font-Underlinestyle for 
    /// </summary>
    public enum ExcelUnderLineType
    {
        None,
        Single,
        Double,
        SingleAccounting,
        DoubleAccounting
    }
    /// <summary>
    /// Fill pattern
    /// </summary>
    public enum ExcelFillStyle
    {
        None,
        Solid,
        DarkGray,
        MediumGray,
        LightGray,
        Gray125,
        Gray0625,
        DarkVertical,
        DarkHorizontal,
        DarkDown,
        DarkUp,
        DarkGrid,
        DarkTrellis,
        LightVertical,
        LightHorizontal,
        LightDown,
        LightUp,
        LightGrid,
        LightTrellis
    }
    /// <summary>
    /// Type of gradient fill
    /// </summary>
    public enum ExcelFillGradientType
    {
        /// <summary>
        /// No gradient fill. 
        /// </summary>
        None,
        /// <summary>
        /// This gradient fill is of linear gradient type. Linear gradient type means that the transition from one color to the next is along a line (e.g., horizontal, vertical,diagonal, etc.)
        /// </summary>
        Linear,
        /// <summary>
        /// This gradient fill is of path gradient type. Path gradient type means the that the boundary of transition from one color to the next is a rectangle, defined by top,bottom, left, and right attributes on the gradientFill element.
        /// </summary>
        Path
    }
    /// <summary>
    /// The reading order
    /// </summary>
    public enum ExcelReadingOrder
    {
        /// <summary>
        /// Reading order is determined by scanning the text for the first non-whitespace character: if it is a strong right-to-left character, the reading order is right-to-left; otherwise, the reading order left-to-right.
        /// </summary>
        ContextDependent=0,
        /// <summary>
        /// Left to Right
        /// </summary>
        LeftToRight=1,
        /// <summary>
        /// Right to Left
        /// </summary>
        RightToLeft=2
    }
    public abstract class StyleBase
    {
        protected ExcelStyles _styles;
        internal OfficeOpenXml.XmlHelper.ChangedEventHandler _ChangedEvent;
        protected int _positionID;
        protected string _address;
        internal StyleBase(ExcelStyles styles, OfficeOpenXml.XmlHelper.ChangedEventHandler ChangedEvent, int PositionID, string Address)
        {
            _styles = styles;
            _ChangedEvent = ChangedEvent;
            _address = Address;
            _positionID = PositionID;
        }
        internal int Index { get; set;}
        internal abstract string Id {get;}

        internal virtual void SetIndex(int index)
        {
            Index = index;
        }
    }
}
