﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml.DataValidation.Formulas.Contracts;
using OfficeOpenXml.DataValidation.Formulas;
using System.Xml;
using OfficeOpenXml.DataValidation.Contracts;

namespace OfficeOpenXml.DataValidation
{
    /// <summary>
    /// Custom validation, i.e. a formula.
    /// </summary>
    public class ExcelDataValidationCustom : ExcelDataValidationWithFormula<IExcelDataValidationFormula>, IExcelDataValidationCustom
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="address"></param>
        /// <param name="validationType"></param>
        internal ExcelDataValidationCustom(ExcelWorksheet worksheet, string address, ExcelDataValidationType validationType)
            : base(worksheet, address, validationType)
        {
            Formula = new ExcelDataValidationFormulaCustom(NameSpaceManager, TopNode, _formula1Path);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="address"></param>
        /// <param name="validationType"></param>
        /// <param name="itemElementNode"></param>
        internal ExcelDataValidationCustom(ExcelWorksheet worksheet, string address, ExcelDataValidationType validationType, XmlNode itemElementNode)
            : base(worksheet, address, validationType, itemElementNode)
        {
            Formula = new ExcelDataValidationFormulaCustom(NameSpaceManager, TopNode, _formula1Path);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="address"></param>
        /// <param name="validationType"></param>
        /// <param name="itemElementNode"></param>
        /// <param name="namespaceManager"></param>
        internal ExcelDataValidationCustom(ExcelWorksheet worksheet, string address, ExcelDataValidationType validationType, XmlNode itemElementNode, XmlNamespaceManager namespaceManager)
            : base(worksheet, address, validationType, itemElementNode, namespaceManager)
        {
            Formula = new ExcelDataValidationFormulaCustom(NameSpaceManager, TopNode, _formula1Path);
        }
    }
}
