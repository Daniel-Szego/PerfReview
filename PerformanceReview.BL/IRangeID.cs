using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeOpenXml
{
    /// <summary>
    /// Id from a cell, column or row.
    /// </summary>
    interface IRangeID
    {
        /// <summary>
        /// This is the id for a cell, row or column.
        /// The id is a composit of the SheetID, the row number and the column number.
        /// Bit 1-14 SheetID, Bit 15-28 Column number (0 if entire column), Bit 29- Row number (0 if entire row).
        /// </summary>
        ulong RangeID
        {
            get;
            set;
        }
    }
}
