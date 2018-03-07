using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using OfficeOpenXml.ConditionalFormatting.Contracts;

namespace OfficeOpenXml.ConditionalFormatting
{
  /// <summary>
  /// ExcelConditionalFormattingDuplicateValues
  /// </summary>
  public class ExcelConditionalFormattingDuplicateValues
    : ExcelConditionalFormattingRule,
    IExcelConditionalFormattingDuplicateValues
  {
    /****************************************************************************************/

    #region Constructors
    /// <summary>
    /// 
    /// </summary>
      /// <param name="address"></param>
      /// <param name="priority"></param>
      /// <param name="worksheet"></param>
    /// <param name="itemElementNode"></param>
    /// <param name="namespaceManager"></param>
    internal ExcelConditionalFormattingDuplicateValues(
      ExcelAddress address,
      int priority,
      ExcelWorksheet worksheet,
      XmlNode itemElementNode,
      XmlNamespaceManager namespaceManager)
      : base(
        eExcelConditionalFormattingRuleType.DuplicateValues,
        address,
        priority,
        worksheet,
        itemElementNode,
        (namespaceManager == null) ? worksheet.NameSpaceManager : namespaceManager)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="priority"></param>
    /// <param name="address"></param>
    /// <param name="worksheet"></param>
    /// <param name="itemElementNode"></param>
    internal ExcelConditionalFormattingDuplicateValues(
      ExcelAddress address,
      int priority,
      ExcelWorksheet worksheet,
      XmlNode itemElementNode)
      : this(
        address,
        priority,
        worksheet,
        itemElementNode,
        null)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="priority"></param>
    /// <param name="address"></param>
    /// <param name="worksheet"></param>
    internal ExcelConditionalFormattingDuplicateValues(
      ExcelAddress address,
      int priority,
      ExcelWorksheet worksheet)
      : this(
        address,
        priority,
        worksheet,
        null,
        null)
    {
    }
    #endregion Constructors

    /****************************************************************************************/
  }
}