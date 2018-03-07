using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingWithRank
  /// </summary>
  public interface IExcelConditionalFormattingWithRank
  {
    #region Public Properties
    /// <summary>
    /// Rank Attribute
    /// </summary>
    UInt16 Rank { get; set; }
    #endregion Public Properties
  }
}