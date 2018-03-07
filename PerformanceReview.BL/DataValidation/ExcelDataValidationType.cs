﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.DataValidation
{
    /// <summary>
    /// Enum for available data validation types
    /// </summary>
    public enum eDataValidationType
    {
        /// <summary>
        /// Integer value
        /// </summary>
        Whole,
        /// <summary>
        /// Decimal values
        /// </summary>
        Decimal,
        /// <summary>
        /// List of values
        /// </summary>
        List,
        /// <summary>
        /// Text length validation
        /// </summary>
        TextLength,
        /// <summary>
        /// DateTime validation
        /// </summary>
        DateTime,
        /// <summary>
        /// Time validation
        /// </summary>
        Time,
        /// <summary>
        /// Custom validation
        /// </summary>
        Custom
    }

    internal static class DataValidationSchemaNames
    {
        public const string Whole = "whole";
        public const string Decimal = "decimal";
        public const string List = "list";
        public const string TextLength = "textLength";
        public const string Date = "date";
        public const string Time = "time";
        public const string Custom = "custom";
    }

    /// <summary>
    /// Types of datavalidation
    /// </summary>
    public class ExcelDataValidationType
    {
        private ExcelDataValidationType(eDataValidationType validationType, bool allowOperator, string schemaName)
        {
            Type = validationType;
            AllowOperator = allowOperator;
            SchemaName = schemaName;
        }

        /// <summary>
        /// Validation type
        /// </summary>
        public eDataValidationType Type
        {
            get;
            private set;
        }

        internal string SchemaName
        {
            get;
            private set;
        }

        /// <summary>
        /// This type allows operator to be set
        /// </summary>
        internal bool AllowOperator
        {

            get;
            private set;
        }

        /// <summary>
        /// Returns a validation type by <see cref="eDataValidationType"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static ExcelDataValidationType GetByValidationType(eDataValidationType type)
        {
            switch (type)
            {
                case eDataValidationType.Whole:
                    return ExcelDataValidationType.Whole;
                case eDataValidationType.List:
                    return ExcelDataValidationType.List;
                case eDataValidationType.Decimal:
                    return ExcelDataValidationType.Decimal;
                case eDataValidationType.TextLength:
                    return ExcelDataValidationType.TextLength;
                case eDataValidationType.DateTime:
                    return ExcelDataValidationType.DateTime;
                case eDataValidationType.Time:
                    return ExcelDataValidationType.Time;
                case eDataValidationType.Custom:
                    return ExcelDataValidationType.Custom;
                default:
                    throw new InvalidOperationException("Non supported Validationtype : " + type.ToString());
            }
        }

        internal static ExcelDataValidationType GetBySchemaName(string schemaName)
        {
            switch (schemaName)
            {
                case DataValidationSchemaNames.Whole:
                    return ExcelDataValidationType.Whole;
                case DataValidationSchemaNames.Decimal:
                    return ExcelDataValidationType.Decimal;
                case DataValidationSchemaNames.List:
                    return ExcelDataValidationType.List;
                case DataValidationSchemaNames.TextLength:
                    return ExcelDataValidationType.TextLength;
                case DataValidationSchemaNames.Date:
                    return ExcelDataValidationType.DateTime;
                case DataValidationSchemaNames.Time:
                    return ExcelDataValidationType.Time;
                case DataValidationSchemaNames.Custom:
                    return ExcelDataValidationType.Custom;
                default:
                    throw new ArgumentException("Invalid schemaname: " + schemaName);
            }
        }

        /// <summary>
        /// Overridden Equals, compares on internal validation type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is ExcelDataValidationType))
            {
                return false;
            }
            return ((ExcelDataValidationType)obj).Type == Type;
        }

        /// <summary>
        /// Overrides GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Integer values
        /// </summary>
        private static ExcelDataValidationType _whole;
        public static ExcelDataValidationType Whole
        {
            get 
            {
                if(_whole == null)
                {
                    _whole = new ExcelDataValidationType(eDataValidationType.Whole, true, DataValidationSchemaNames.Whole); 
                }
                return _whole;
            }
        }

        /// <summary>
        /// List of allowed values
        /// </summary>
        private static ExcelDataValidationType _list;
        public static ExcelDataValidationType List
        {
            get
            {
                if (_list == null)
                {
                    _list = new ExcelDataValidationType(eDataValidationType.List, false, DataValidationSchemaNames.List);
                }
                return _list;
            }
        }

        private static ExcelDataValidationType _decimal;
        public static ExcelDataValidationType Decimal
        {
            get
            {
                if (_decimal == null)
                {
                    _decimal = new ExcelDataValidationType(eDataValidationType.Decimal, true, DataValidationSchemaNames.Decimal);
                }
                return _decimal;
            }
        }

        private static ExcelDataValidationType _textLength;
        public static ExcelDataValidationType TextLength
        {
            get
            {
                if (_textLength == null)
                {
                    _textLength = new ExcelDataValidationType(eDataValidationType.TextLength, true, DataValidationSchemaNames.TextLength);
                }
                return _textLength;
            }
        }

        private static ExcelDataValidationType _dateTime;
        public static ExcelDataValidationType DateTime
        {
            get
            {
                if (_dateTime == null)
                {
                    _dateTime = new ExcelDataValidationType(eDataValidationType.DateTime, true, DataValidationSchemaNames.Date);
                }
                return _dateTime;
            }
        }

        private static ExcelDataValidationType _time;
        public static ExcelDataValidationType Time
        {
            get
            {
                if (_time == null)
                {
                    _time = new ExcelDataValidationType(eDataValidationType.Time, true, DataValidationSchemaNames.Time);
                }
                return _time;
            }
        }

        private static ExcelDataValidationType _custom;
        public static ExcelDataValidationType Custom
        {
            get
            {
                if (_custom == null)
                {
                    _custom = new ExcelDataValidationType(eDataValidationType.Custom, true, DataValidationSchemaNames.Custom);
                }
                return _custom;
            }
        }
    }
}
