
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeOpenXml
{
    /// <summary>
    /// A single cell address 
    /// </summary>
    public class ExcelCellAddress
    {
        public ExcelCellAddress()
            : this(1, 1)
        {

        }

        private int _row;
        private int _column;
        private string _address;
        /// <summary>
        /// Initializes a new instance of the ExcelCellAddress class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public ExcelCellAddress(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        /// <summary>
        /// Initializes a new instance of the ExcelCellAddress class.
        /// </summary>
        ///<param name="address">The address</param>
        public ExcelCellAddress(string address)
        {
            this.Address = address; 
        }
        /// <summary>
        /// Row
        /// </summary>
        public int Row
        {
            get
            {
                return this._row;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Row cannot be less than 1.");
                }
                this._row = value;
                if(_column>0) 
                    _address = ExcelCellBase.GetAddress(_row, _column);
                else
                    _address = "#REF!";
            }
        }
        /// <summary>
        /// Column
        /// </summary>
        public int Column
        {
            get
            {
                return this._column;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Column cannot be less than 1.");
                }
                this._column = value;
                if (_row > 0)
                    _address = ExcelCellBase.GetAddress(_row, _column);
                else
                    _address = "#REF!";
            }
        }
        /// <summary>
        /// Celladdress
        /// </summary>
        public string Address
        {
            get
            {
                return _address;
            }
            internal set
            {
                _address = value;
                ExcelCellBase.GetRowColFromAddress(_address, out _row, out _column);
            }
        }
        /// <summary>
        /// If the address is an invalid reference (#REF!)
        /// </summary>
        public bool IsRef
        {
            get
            {
                return _row <= 0;
            }
        }
    }
}

