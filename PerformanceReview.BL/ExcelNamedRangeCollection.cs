using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OfficeOpenXml
{
    /// <summary>
    /// Collection for named ranges
    /// </summary>
    public class ExcelNamedRangeCollection : IEnumerable<ExcelNamedRange>
    {
        internal ExcelWorksheet _ws;
        internal ExcelWorkbook _wb;
        internal ExcelNamedRangeCollection(ExcelWorkbook wb)
        {
            _wb = wb;
            _ws = null;
        }
        internal ExcelNamedRangeCollection(ExcelWorkbook wb, ExcelWorksheet ws)
        {
            _wb = wb;
            _ws = ws;
        }
        Dictionary<string, ExcelNamedRange> _dic = new Dictionary<string, ExcelNamedRange>();
        /// <summary>
        /// Add a new named range
        /// </summary>
        /// <param name="Name">The name</param>
        /// <param name="Range">The range</param>
        /// <returns></returns>
        public ExcelNamedRange Add(string Name, ExcelRangeBase Range)
        {
            ExcelNamedRange item;
            if (Range.IsName)
            {

                item = new ExcelNamedRange(Name, _wb,_ws);
            }
            else
            {
                item = new ExcelNamedRange(Name, _ws, Range.Worksheet, Range.Address);
            }
            
            _dic.Add(Name.ToLower(), item);
            return item;
        }
        /// <summary>
        /// Add a defined name referencing value
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ExcelNamedRange AddValue(string Name, object value)
        {
            var item = new ExcelNamedRange(Name,_wb, _ws);
            item.NameValue = value;
            _dic.Add(Name.ToLower(), item);
            return item;
        }
        /// <summary>
        /// Add a defined name referencing a formula -- the method name contains a typo.
        /// This method is obsolete and will be removed in the future.
        /// Use <see cref="AddFormula"/>
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Formula"></param>
        /// <returns></returns>
        [Obsolete("Call AddFormula() instead.  See Issue Tracker Id #14687")]
        public ExcelNamedRange AddFormla(string Name, string Formula)
        {
            return  this.AddFormula(Name, Formula);
        }

        /// <summary>
        /// Add a defined name referencing a formula
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Formula"></param>
        /// <returns></returns>
        public ExcelNamedRange AddFormula(string Name, string Formula)
        {
            var item = new ExcelNamedRange(Name, _wb, _ws);
            item.NameFormula = Formula;
            _dic.Add(Name.ToLower(), item);
            return item;
        }
        /// <summary>
        /// Remove a defined name from the collection
        /// </summary>
        /// <param name="Name">The name</param>
        public void Remove(string Name)
        {
            _dic.Remove(Name.ToLower());
        }
        /// <summary>
        /// Checks collection for the presence of a key
        /// </summary>
        /// <param name="key">key to search for</param>
        /// <returns>true if the key is in the collection</returns>
        public bool ContainsKey(string key)
        {
            return _dic.ContainsKey(key.ToLower());
        }
        /// <summary>
        /// The current number of items in the collection
        /// </summary>
        public int Count
        {
            get
            {
                return _dic.Count;
            }
        }
        /// <summary>
        /// Name indexer
        /// </summary>
        /// <param name="Name">The name (key) for a Named range</param>
        /// <returns>a reference to the range</returns>
        /// <remarks>
        /// Throws a KeyNotFoundException if the key is not in the collection.
        /// </remarks>
        public ExcelNamedRange this[string Name]
        {
            get
            {
                return _dic[Name.ToLower()];
            }
        }

        #region "IEnumerable"
        #region IEnumerable<ExcelNamedRange> Members
        /// <summary>
        /// Implement interface method IEnumerator&lt;ExcelNamedRange&gt; GetEnumerator()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ExcelNamedRange> GetEnumerator()
        {
            return _dic.Values.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        /// <summary>
        /// Implement interface method IEnumeratable GetEnumerator()
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dic.Values.GetEnumerator();
        }

        #endregion
        #endregion
    }
}
