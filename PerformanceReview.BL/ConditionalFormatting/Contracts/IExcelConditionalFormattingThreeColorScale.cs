using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
	/// <summary>
	/// IExcelConditionalFormattingThreeColorScale
	/// </summary>
	public interface IExcelConditionalFormattingThreeColorScale
    : IExcelConditionalFormattingTwoColorScale
	{
		#region Public Properties
		/// <summary>
		/// Three Color Scale Middle Value
		/// </summary>
		ExcelConditionalFormattingColorScaleValue MiddleValue { get; set; }
		#endregion Public Properties
	}
}