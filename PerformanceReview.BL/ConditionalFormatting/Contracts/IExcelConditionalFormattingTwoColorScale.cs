using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
	/// <summary>
	/// IExcelConditionalFormattingTwoColorScale
	/// </summary>
	public interface IExcelConditionalFormattingTwoColorScale
		: IExcelConditionalFormattingColorScaleGroup
	{
		#region Public Properties
    /// <summary>
    /// Two Color Scale Low Value
    /// </summary>
    ExcelConditionalFormattingColorScaleValue LowValue { get; set; }

    /// <summary>
    /// Two Color Scale High Value
    /// </summary>
    ExcelConditionalFormattingColorScaleValue HighValue { get; set; }
    #endregion Public Properties
	}
}