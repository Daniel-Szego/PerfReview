using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeOpenXml.Style
{
    internal interface IExcelCell
    {
        #region "public properties"
        object Value {get;set;}
        string StyleName { get; }
        int StyleID { get; set; }
        ExcelStyle Style { get; }
        Uri Hyperlink { get; set; }
        string Formula { get; set; }
        string FormulaR1C1 { get; set; }
        #endregion
    }
}
