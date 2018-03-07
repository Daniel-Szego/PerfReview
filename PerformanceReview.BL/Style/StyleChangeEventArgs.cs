using System;
using System.Collections.Generic;
using System.Text;
namespace OfficeOpenXml.Style
{
    internal enum eStyleClass
    {
        Numberformat,
        Font,    
        Border,
        BorderTop,
        BorderLeft,
        BorderBottom,
        BorderRight,
        BorderDiagonal,
        Fill,
        GradientFill,
        FillBackgroundColor,
        FillPatternColor,
        FillGradientColor1,
        FillGradientColor2,
        NamedStyle,
        Style
    };
    internal enum eStyleProperty
    {
        Format,
        Name,
        Size,
        Bold,
        Italic,
        Strike,
        Color,
        Tint,
        IndexedColor,
        AutoColor,
        GradientColor,
        Family,
        Scheme,
        UnderlineType,
        HorizontalAlign,
        VerticalAlign,
        Border,
        NamedStyle,
        Style,
        PatternType,
        ReadingOrder,
        WrapText,
        TextRotation,
        Locked,
        Hidden,
        ShrinkToFit,
        BorderDiagonalUp,
        BorderDiagonalDown,
        GradientDegree,
        GradientType,
        GradientTop,
        GradientBottom,
        GradientLeft,
        GradientRight,
        XfId,
        Indent
    }
    internal class StyleChangeEventArgs : EventArgs
    {
        internal StyleChangeEventArgs(eStyleClass styleclass, eStyleProperty styleProperty, object value, int positionID, string address)
        {
            StyleClass = styleclass;
            StyleProperty=styleProperty;
            Value = value;
            Address = address;
            PositionID = positionID;
        }
        internal eStyleClass StyleClass;
        internal eStyleProperty StyleProperty;
        //internal string PropertyName;
        internal object Value;
        internal int PositionID { get; set; }
        //internal string Address;
        internal string Address;
    }
}
