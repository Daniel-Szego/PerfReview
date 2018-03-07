using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingWithReverse
  /// </summary>
  public interface IExcelConditionalFormattingWithReverse
  {
    #region Public Properties
    /// <summary>
    /// Reverse Attribute
    /// </summary>
    bool Reverse { get; set; }
    #endregion Public Properties
  }
}