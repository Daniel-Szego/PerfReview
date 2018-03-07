using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingWithFormula
  /// </summary>
  public interface IExcelConditionalFormattingWithFormula
  {
    #region Public Properties
    /// <summary>
    /// Formula Attribute
    /// </summary>
    string Formula { get; set; }
    #endregion Public Properties
  }
}