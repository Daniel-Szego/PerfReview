using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml.DataValidation.Formulas.Contracts;
using System.Xml;

namespace OfficeOpenXml.DataValidation.Formulas
{
    /// <summary>
    /// 
    /// </summary>
    internal class ExcelDataValidationFormulaCustom : ExcelDataValidationFormula, IExcelDataValidationFormula
    {
        public ExcelDataValidationFormulaCustom(XmlNamespaceManager namespaceManager, XmlNode topNode, string formulaPath)
            : base(namespaceManager, topNode, formulaPath)
        {
            var value = GetXmlNodeString(formulaPath);
            if (!string.IsNullOrEmpty(value))
            {
                ExcelFormula = value;
            }
            State = FormulaState.Formula;
        }

        internal override string GetXmlValue()
        {
            return ExcelFormula;
        }

        protected override string GetValueAsString()
        {
            return ExcelFormula;
        }

        internal override void ResetValue()
        {
            ExcelFormula = null;
        }
    }
}
