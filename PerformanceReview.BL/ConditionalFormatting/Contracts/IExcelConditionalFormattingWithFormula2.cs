using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingWithFormula2
  /// </summary>
  public interface IExcelConditionalFormattingWithFormula2
    : IExcelConditionalFormattingWithFormula
  {
    #region Public Properties
    /// <summary>
    /// Formula2 Attribute
    /// </summary>
    string Formula2 { get; set; }
    #endregion Public Properties
  }
}