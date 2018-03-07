﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using OfficeOpenXml.ConditionalFormatting.Contracts;

namespace OfficeOpenXml.ConditionalFormatting
{
  /// <summary>
  /// ExcelConditionalFormattingBeginsWith
  /// </summary>
  public class ExcelConditionalFormattingBeginsWith
    : ExcelConditionalFormattingRule,
    IExcelConditionalFormattingBeginsWith
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
    internal ExcelConditionalFormattingBeginsWith(
      ExcelAddress address,
      int priority,
      ExcelWorksheet worksheet,
      XmlNode itemElementNode,
      XmlNamespaceManager namespaceManager)
      : base(
        eExcelConditionalFormattingRuleType.BeginsWith,
        address,
        priority,
        worksheet,
        itemElementNode,
        (namespaceManager == null) ? worksheet.NameSpaceManager : namespaceManager)
    {
        if (itemElementNode==null) //Set default values and create attributes if needed
        {
            Operator = eExcelConditionalFormattingOperatorType.BeginsWith;
            Text = string.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="priority"></param>
    /// <param name="address"></param>
    /// <param name="worksheet"></param>
    /// <param name="itemElementNode"></param>
    internal ExcelConditionalFormattingBeginsWith(
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
    internal ExcelConditionalFormattingBeginsWith(
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

    #region Exposed Properties
    /// <summary>
    /// The text to search in the beginning of the cell
    /// </summary>
    public string Text
    {
      get
      {
        return GetXmlNodeString(
          ExcelConditionalFormattingConstants.Paths.TextAttribute);
      }
      set
      {
        SetXmlNodeString(
          ExcelConditionalFormattingConstants.Paths.TextAttribute,
          value);

        Formula = string.Format(
          "LEFT({0},LEN(\"{1}\"))=\"{1}\"",
          Address.Start.Address,
          value.Replace("\"", "\"\""));
      }
    }
    #endregion Exposed Properties

    /****************************************************************************************/
  }
}