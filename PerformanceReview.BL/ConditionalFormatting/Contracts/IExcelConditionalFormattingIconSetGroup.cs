using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
	/// <summary>
	/// IExcelConditionalFormattingIconSetGroup
	/// </summary>
	public interface IExcelConditionalFormattingIconSetGroup<T>
		: IExcelConditionalFormattingRule
	{
		#region Public Properties
    /// <summary>
    /// Reverse
    /// </summary>
    bool Reverse { get; set; }

    /// <summary>
    /// ShowValue
    /// </summary>
    bool ShowValue { get; set; }

    /// <summary>
    /// IconSet (3, 4 ou 5 IconSet)
    /// </summary>
    T IconSet { get; set; }
    #endregion Public Properties
	}
}