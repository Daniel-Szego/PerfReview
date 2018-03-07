
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using OfficeOpenXml.Style.Dxf;

namespace OfficeOpenXml.ConditionalFormatting.Contracts
{
	/// <summary>
	/// Interface for conditional formatting rule
	/// </summary>
	public interface IExcelConditionalFormattingRule
	{
    /// <summary>
    /// The 'cfRule' XML node
    /// </summary>
    XmlNode Node { get; }

    /// <summary>
    /// Type of conditional formatting rule. ST_CfType §18.18.12.
    /// </summary>
    eExcelConditionalFormattingRuleType Type { get; }

    /// <summary>
    /// <para>Range over which these conditional formatting rules apply.</para>
    /// <para>The possible values for this attribute are defined by the
    /// ST_Sqref simple type (§18.18.76).</para>
    /// </summary>
    ExcelAddress Address { get; set; }

		/// <summary>
		/// The priority of this conditional formatting rule. This value is used to determine
		/// which format should be evaluated and rendered. Lower numeric values are higher
		/// priority than higher numeric values, where 1 is the highest priority.
		/// </summary>
    int Priority { get; set; }

    /// <summary>
    /// If this flag is 1, no rules with lower priority shall be applied over this rule,
    /// when this rule evaluates to true.
    /// </summary>
    bool StopIfTrue { get; set; }

    ///// <summary>
    ///// <para>This is an index to a dxf element in the Styles Part indicating which cell
    ///// formatting to apply when the conditional formatting rule criteria is met.</para>
    ///// <para>The possible values for this attribute are defined by the ST_DxfId simple type
    ///// (§18.18.25).</para>
    ///// </summary>
//    int DxfId { get; set; }
    /// <summary>
    /// Gives access to the differencial styling (DXF) for the rule.
    /// </summary>
    ExcelDxfStyleConditionalFormatting Style{ get; }
  }
}