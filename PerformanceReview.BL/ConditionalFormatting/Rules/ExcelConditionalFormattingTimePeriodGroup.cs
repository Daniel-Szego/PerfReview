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
  /// ExcelConditionalFormattingTimePeriodGroup
  /// </summary>
  public class ExcelConditionalFormattingTimePeriodGroup
    : ExcelConditionalFormattingRule,
    IExcelConditionalFormattingTimePeriodGroup
  {
    /****************************************************************************************/

    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="priority"></param>
    /// <param name="address"></param>
    /// <param name="worksheet"></param>
    /// <param name="itemElementNode"></param>
    /// <param name="namespaceManager"></param>
    internal ExcelConditionalFormattingTimePeriodGroup(
      eExcelConditionalFormattingRuleType type,
      ExcelAddress address,
      int priority,
      ExcelWorksheet worksheet,
      XmlNode itemElementNode,
      XmlNamespaceManager namespaceManager)
      : base(
        type,
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
      /// <param name="type"></param>
      /// <param name="priority"></param>
    /// <param name="address"></param>
    /// <param name="worksheet"></param>
    /// <param name="itemElementNode"></param>
    internal ExcelConditionalFormattingTimePeriodGroup(
      eExcelConditionalFormattingRuleType type,
      ExcelAddress address,
      int priority,
      ExcelWorksheet worksheet,
      XmlNode itemElementNode)
      : this(
        type,
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
    /// <param name="type"></param>
    /// <param name="address"></param>
    /// <param name="priority"></param>
    /// <param name="worksheet"></param>
    internal ExcelConditionalFormattingTimePeriodGroup(
      eExcelConditionalFormattingRuleType type,
      ExcelAddress address,
      int priority,
      ExcelWorksheet worksheet)
      : this(
        type,
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