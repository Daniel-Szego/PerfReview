using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingFiveIconSet
  /// </summary>eExcelconditionalFormatting4IconsSetType
    public interface IExcelConditionalFormattingFiveIconSet : IExcelConditionalFormattingFourIconSet<eExcelconditionalFormatting5IconsSetType>
  {
    #region Public Properties
    /// <summary>
    /// Icon5 (part of the 5 Icon Set)
    /// </summary>
      ExcelConditionalFormattingIconDataBarValue Icon5 { get; }
    #endregion Public Properties
  }
}