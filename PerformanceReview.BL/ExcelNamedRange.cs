using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeOpenXml
{
    /// <summary>
    /// A named range. 
    /// </summary>
    public sealed class ExcelNamedRange : ExcelRangeBase 
    {
        ExcelWorksheet _sheet;
        /// <summary>
        /// A named range
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="nameSheet">The sheet containing the name. null if its a global name</param>
        /// <param name="sheet">Sheet where the address points</param>
        /// <param name="address">The address</param>
        public ExcelNamedRange(string name, ExcelWorksheet nameSheet , ExcelWorksheet sheet, string address) :
            base(sheet, address)
        {
            Name = name;
            _sheet = nameSheet;

        }
        internal ExcelNamedRange(string name,ExcelWorkbook wb, ExcelWorksheet nameSheet) :
            base(wb, nameSheet, name, true)
        {
            Name = name;
            _sheet = nameSheet;
        }

        /// <summary>
        /// Name of the range
        /// </summary>
        public string Name
        {
            get;
            internal set;
        }
        /// <summary>
        /// Is the named range local for the sheet 
        /// </summary>
        public int LocalSheetId
        {
            get
            {
                if (_sheet == null)
                {
                    return -1;
                }
                else
                {
                    return _sheet.PositionID-1;
                }
            }
        }        
        /// <summary>
        /// Is the name hidden
        /// </summary>
        public bool IsNameHidden
        {
            get;
            set;
        }
        /// <summary>
        /// A comment for the Name
        /// </summary>
        public string NameComment
        {
            get;
            set;
        }
        internal object NameValue { get; set; }
        internal string NameFormula { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
