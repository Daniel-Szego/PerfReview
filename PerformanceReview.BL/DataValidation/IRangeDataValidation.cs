using System.Linq;
using System.Text;
using OfficeOpenXml.DataValidation.Contracts;

namespace OfficeOpenXml.DataValidation
{
    /// <summary>
    /// Provides functionality for adding datavalidation to a range (<see cref="ExcelRangeBase"/>). Each method will
    /// return a configurable validation.
    /// </summary>
    public interface IRangeDataValidation
    {
        /// <summary>
        /// Adds a <see cref="IExcelDataValidationInt"/> to the range
        /// </summary>
        /// <returns>A <see cref="ExcelDataValidationInt"/> that can be configured for integer data validation</returns>
        IExcelDataValidationInt AddIntegerDataValidation();
        /// <summary>
        /// Adds a <see cref="ExcelDataValidationDecimal"/> to the range
        /// </summary>
        /// <returns>A <see cref="ExcelDataValidationDecimal"/> that can be configured for decimal data validation</returns>
        IExcelDataValidationDecimal AddDecimalDataValidation();
        /// <summary>
        /// Adds a <see cref="ExcelDataValidationDateTime"/> to the range
        /// </summary>
        /// <returns>A <see cref="ExcelDataValidationDecimal"/> that can be configured for datetime data validation</returns>
        IExcelDataValidationDateTime AddDateTimeDataValidation();
        /// <summary>
        /// Adds a <see cref="IExcelDataValidationList"/> to the range
        /// </summary>
        /// <returns>A <see cref="ExcelDataValidationList"/> that can be configured for datetime data validation</returns>
        IExcelDataValidationList AddListDataValidation();
        /// <summary>
        /// Adds a <see cref="IExcelDataValidationInt"/> regarding text length validation to the range.
        /// </summary>
        /// <returns></returns>
        IExcelDataValidationInt AddTextLengthDataValidation();
        /// <summary>
        /// Adds a <see cref="IExcelDataValidationTime"/> to the range.
        /// </summary>
        /// <returns>A <see cref="IExcelDataValidationTime"/> that can be configured for time data validation</returns>
        IExcelDataValidationTime AddTimeDataValidation();
        /// <summary>
        /// Adds a <see cref="IExcelDataValidationCustom"/> to the range.
        /// </summary>
        /// <returns>A <see cref="IExcelDataValidationCustom"/> that can be configured for custom validation</returns>
        IExcelDataValidationCustom AddCustomDataValidation();
    }
}
