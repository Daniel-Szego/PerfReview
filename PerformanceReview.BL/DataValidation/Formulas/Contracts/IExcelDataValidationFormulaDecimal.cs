using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.DataValidation.Formulas.Contracts
{
    /// <summary>
    /// Interface for a data validation formula of <see cref="System.Single">float</see> value
    /// </summary>
    public interface IExcelDataValidationFormulaDecimal : IExcelDataValidationFormulaWithValue<double?>
    {
    }
}
