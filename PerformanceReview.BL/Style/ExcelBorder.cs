﻿using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.Style.XmlAccess;

namespace OfficeOpenXml.Style
{
    /// <summary>
    /// Cell Border style
    /// </summary>
    public sealed class Border : StyleBase
    {
        internal Border(ExcelStyles styles, OfficeOpenXml.XmlHelper.ChangedEventHandler ChangedEvent, int PositionID, string address, int index) :
            base(styles, ChangedEvent, PositionID, address)
	    {
            Index = index;
        }
        /// <summary>
        /// Left border style
        /// </summary>
        public ExcelBorderItem Left
        {
            get
            {
                return new ExcelBorderItem(_styles, _ChangedEvent, _positionID, _address, eStyleClass.BorderLeft, this);
            }
        }
        /// <summary>
        /// Right border style
        /// </summary>
        public ExcelBorderItem Right
        {
            get
            {
                return new ExcelBorderItem(_styles, _ChangedEvent, _positionID, _address, eStyleClass.BorderRight, this);
            }
        }
        /// <summary>
        /// Top border style
        /// </summary>
        public ExcelBorderItem Top
        {
            get
            {
                return new ExcelBorderItem(_styles, _ChangedEvent, _positionID, _address, eStyleClass.BorderTop, this);
            }
        }
        /// <summary>
        /// Bottom border style
        /// </summary>
        public ExcelBorderItem Bottom
        {
            get
            {
                return new ExcelBorderItem(_styles, _ChangedEvent, _positionID, _address, eStyleClass.BorderBottom, this);
            }
        }
        /// <summary>
        /// 0Diagonal border style
        /// </summary>
        public ExcelBorderItem Diagonal
        {
            get
            {
                return new ExcelBorderItem(_styles, _ChangedEvent, _positionID, _address, eStyleClass.BorderDiagonal, this);
            }
        }
        /// <summary>
        /// A diagonal from the bottom left to top right of the cell
        /// </summary>
        public bool DiagonalUp 
        {
            get
            {
                if (Index >=0)
                {
                    return _styles.Borders[Index].DiagonalUp;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.Border, eStyleProperty.BorderDiagonalUp, value, _positionID, _address));
            }
        }
        /// <summary>
        /// A diagonal from the top left to bottom right of the cell
        /// </summary>
        public bool DiagonalDown 
        {
            get
            {
                if (Index >= 0)
                {
                    return _styles.Borders[Index].DiagonalDown;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.Border, eStyleProperty.BorderDiagonalDown, value, _positionID, _address));
            }
        }
        internal override string Id
        {
            get { return Top.Id + Bottom.Id +Left.Id + Right.Id + Diagonal.Id + DiagonalUp + DiagonalDown; }
        }
        /// <summary>
        /// Set the border style around the range.
        /// </summary>
        /// <param name="Style">The border style</param>
        public void BorderAround(ExcelBorderStyle Style)
        {
            var addr = new ExcelAddress(_address);
            SetBorderAroundStyle(Style, addr);
        }
        /// <summary>
        /// Set the border style around the range.
        /// </summary>
        /// <param name="Style">The border style</param>
        /// <param name="Color">The color of the border</param>
        public void BorderAround(ExcelBorderStyle Style, System.Drawing.Color Color)
        {            
            var addr=new ExcelAddress(_address);
            SetBorderAroundStyle(Style, addr);

            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderTop, eStyleProperty.Color, Color.ToArgb().ToString("X"), _positionID, new ExcelAddress(addr._fromRow, addr._fromCol, addr._fromRow, addr._toCol).Address));
            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderBottom, eStyleProperty.Color, Color.ToArgb().ToString("X"), _positionID, new ExcelAddress(addr._toRow, addr._fromCol, addr._toRow, addr._toCol).Address));
            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderLeft, eStyleProperty.Color, Color.ToArgb().ToString("X"), _positionID, new ExcelAddress(addr._fromRow, addr._fromCol, addr._toRow, addr._fromCol).Address));
            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderRight, eStyleProperty.Color, Color.ToArgb().ToString("X"), _positionID, new ExcelAddress(addr._fromRow, addr._toCol, addr._toRow, addr._toCol).Address));
        }

        private void SetBorderAroundStyle(ExcelBorderStyle Style, ExcelAddress addr)
        {
            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderTop, eStyleProperty.Style, Style, _positionID, new ExcelAddress(addr._fromRow, addr._fromCol, addr._fromRow, addr._toCol).Address));
            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderBottom, eStyleProperty.Style, Style, _positionID, new ExcelAddress(addr._toRow, addr._fromCol, addr._toRow, addr._toCol).Address));
            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderLeft, eStyleProperty.Style, Style, _positionID, new ExcelAddress(addr._fromRow, addr._fromCol, addr._toRow, addr._fromCol).Address));
            _ChangedEvent(this, new StyleChangeEventArgs(eStyleClass.BorderRight, eStyleProperty.Style, Style, _positionID, new ExcelAddress(addr._fromRow, addr._toCol, addr._toRow, addr._toCol).Address));
        }
    }
}
