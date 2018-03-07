using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingFourIconSet
  /// </summary>
    public interface IExcelConditionalFormattingFourIconSet<T> : IExcelConditionalFormattingThreeIconSet<T>
  {
    #region Public Properties
    /// <summary>
    /// Icon4 (part of the 4 ou 5 Icon Set)
    /// </summary>
      ExcelConditionalFormattingIconDataBarValue Icon4 { get; }      
    #endregion Public Properties
  }
}
