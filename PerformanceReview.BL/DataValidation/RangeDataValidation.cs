using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml.Utils;
using OfficeOpenXml.DataValidation.Contracts;

namespace OfficeOpenXml.DataValidation
{
    internal class RangeDataValidation : IRangeDataValidation
    {
        public RangeDataValidation(ExcelWorksheet worksheet, string address)
        {
            Require.Argument(worksheet).IsNotNull("worksheet");
            Require.Argument(address).IsNotNullOrEmpty("address");
            _worksheet = worksheet;
            _address = address;
        }

        ExcelWorksheet _worksheet;
        string _address;

        public IExcelDataValidationInt AddIntegerDataValidation()
        {
            return _worksheet.DataValidations.AddIntegerValidation(_address);
        }

        public IExcelDataValidationDecimal AddDecimalDataValidation()
        {
            return _worksheet.DataValidations.AddDecimalValidation(_address);
        }

        public IExcelDataValidationDateTime AddDateTimeDataValidation()
        {
            return _worksheet.DataValidations.AddDateTimeValidation(_address);
        }

        public IExcelDataValidationList AddListDataValidation()
        {
            return _worksheet.DataValidations.AddListValidation(_address);
        }

        public IExcelDataValidationInt AddTextLengthDataValidation()
        {
            return _worksheet.DataValidations.AddTextLengthValidation(_address);
        }

        public IExcelDataValidationTime AddTimeDataValidation()
        {
            return _worksheet.DataValidations.AddTimeValidation(_address);
        }

        public IExcelDataValidationCustom AddCustomDataValidation()
        {
            return _worksheet.DataValidations.AddCustomValidation(_address);
        }
    }
}
