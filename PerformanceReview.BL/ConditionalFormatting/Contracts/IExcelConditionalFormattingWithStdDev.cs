using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingWithStdDev
  /// </summary>
  public interface IExcelConditionalFormattingWithStdDev
  {
    #region Public Properties
    /// <summary>
    /// StdDev Attribute
    /// </summary>
    UInt16 StdDev { get; set; }
    #endregion Public Properties
  }
}