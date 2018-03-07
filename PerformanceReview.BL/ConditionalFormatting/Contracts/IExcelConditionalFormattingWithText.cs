using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingWithText
  /// </summary>
  public interface IExcelConditionalFormattingWithText
  {
    #region Public Properties
    /// <summary>
    /// Text Attribute
    /// </summary>
    string Text { get; set; }
    #endregion Public Properties
  }
}