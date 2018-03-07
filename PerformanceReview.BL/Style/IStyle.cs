using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.Style;
namespace OfficeOpenXml.Style
{
    internal interface IStyle
    {
        void SetNewStyleID(string value);
        ulong Id {get;}
        ExcelStyle ExcelStyle{get;}
    }
}
