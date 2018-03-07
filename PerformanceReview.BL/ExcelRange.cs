using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.Style;
using System.Data;
namespace OfficeOpenXml
{
    /// <summary>
    /// A range of cells. 
    /// </summary>
    public class ExcelRange : ExcelRangeBase
    {
        #region "Constructors"
        internal ExcelRange(ExcelWorksheet sheet) : 
            base(sheet)
        {

        }
        internal ExcelRange(ExcelWorksheet sheet, string address)
            : base(sheet, address)
        {

        }
        internal ExcelRange(ExcelWorksheet sheet, int fromRow, int fromCol, int toRow, int toCol)
            : base(sheet)
        {
            _fromRow = fromRow;
            _fromCol = fromCol;
            _toRow = toRow;
            _toCol = toCol;
        }
        #endregion
        #region "Indexers"
        /// <summary>
        /// Access the range using an address
        /// </summary>
        /// <param name="Address">The address</param>
        /// <returns>A range object</returns>
        public ExcelRange this[string Address]
        {
            get
            {
                if (_worksheet.Names.ContainsKey(Address))
                {
                    if (_worksheet.Names[Address].IsName)
                    {
                        return null;
                    }
                    else
                    {
                        base.Address = _worksheet.Names[Address].Address;
                    }
                }
                else
                {
                    base.Address = Address;
                }
                return this;
            }
        }
        /// <summary>
        /// Access a single cell
        /// </summary>
        /// <param name="Row">The row</param>
        /// <param name="Col">The column</param>
        /// <returns>A range object</returns>
        public ExcelRange this[int Row, int Col]
        {
            get
            {
                ValidateRowCol(Row, Col);

                _fromCol = Col;
                _fromRow = Row;
                _toCol = Col;
                _toRow = Row;
                base.Address = GetAddress(_fromRow, _fromCol);
                return this;
            }
        }
        /// <summary>
        /// Access a range of cells
        /// </summary>
        /// <param name="FromRow">Start row</param>
        /// <param name="FromCol">Start column</param>
        /// <param name="ToRow">End Row</param>
        /// <param name="ToCol">End Column</param>
        /// <returns></returns>
        public ExcelRange this[int FromRow, int FromCol, int ToRow, int ToCol]
        {
            get
            {
                ValidateRowCol(FromRow, FromCol);
                ValidateRowCol(ToRow, ToCol);

                _fromCol = FromCol;
                _fromRow = FromRow;
                _toCol = ToCol;
                _toRow = ToRow;
                base.Address = GetAddress(_fromRow, _fromCol, _toRow, _toCol);
                return this;
            }
        }
        #endregion
        private static void ValidateRowCol(int Row, int Col)
        {
            if (Row < 1 || Row > ExcelPackage.MaxRows)
            {
                throw (new ArgumentException("Row out of range"));
            }
            if (Col < 1 || Col > ExcelPackage.MaxColumns)
            {
                throw (new ArgumentException("Column out of range"));
            }
        }

    }
}
