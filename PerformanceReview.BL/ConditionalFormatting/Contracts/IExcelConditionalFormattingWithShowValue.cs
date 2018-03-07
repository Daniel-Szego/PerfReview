using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml.ConditionalFormatting;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
  /// <summary>
  /// IExcelConditionalFormattingWithShowValue
  /// </summary>
  public interface IExcelConditionalFormattingWithShowValue
  {
    #region Public Properties
    /// <summary>
    /// ShowValue Attribute
    /// </summary>
    bool ShowValue { get; set; }
    #endregion Public Properties
  }
}