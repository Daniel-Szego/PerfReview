using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
	/// <summary>
	/// IExcelConditionalFormattingThreeIconSet
	/// </summary>
	public interface IExcelConditionalFormattingThreeIconSet<T>
    : IExcelConditionalFormattingIconSetGroup<T>
	{
		#region Public Properties
    /// <summary>
    /// Icon1 (part of the 3, 4 ou 5 Icon Set)
    /// </summary>
        ExcelConditionalFormattingIconDataBarValue Icon1 { get; }

    /// <summary>
    /// Icon2 (part of the 3, 4 ou 5 Icon Set)
    /// </summary>
    ExcelConditionalFormattingIconDataBarValue Icon2 { get;  }

    /// <summary>
    /// Icon3 (part of the 3, 4 ou 5 Icon Set)
    /// </summary>
    ExcelConditionalFormattingIconDataBarValue Icon3 { get; }
    #endregion Public Properties
	}
}