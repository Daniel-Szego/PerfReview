using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;
using System.Drawing;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
	/// <summary>
	/// IExcelConditionalFormattingDataBar
	/// </summary>
	public interface IExcelConditionalFormattingDataBarGroup
        : IExcelConditionalFormattingRule
	{
		#region Public Properties
        /// <summary>
        /// ShowValue
        /// </summary>
        bool ShowValue { get; set; }
        /// <summary>
        /// Databar Low Value
        /// </summary>
        ExcelConditionalFormattingIconDataBarValue LowValue { get;  }

        /// <summary>
        /// Databar High Value
        /// </summary>
        ExcelConditionalFormattingIconDataBarValue HighValue { get; }
        /// <summary>
        /// The color of the databar
        /// </summary>
        Color Color { get; set;}
        #endregion Public Properties
	}
}