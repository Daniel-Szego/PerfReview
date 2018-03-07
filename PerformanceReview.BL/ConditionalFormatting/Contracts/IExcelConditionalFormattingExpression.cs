using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingExpression
  /// </summary>
  public interface IExcelConditionalFormattingExpression
    : IExcelConditionalFormattingRule,
    IExcelConditionalFormattingWithFormula
  {
    #region Public Properties
    #endregion Public Properties
  }
}