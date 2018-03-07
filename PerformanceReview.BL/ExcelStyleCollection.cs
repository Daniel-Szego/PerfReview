using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace OfficeOpenXml
{
    /// <summary>
    /// Base collection class for styles.
    /// </summary>
    /// <typeparam name="T">The style type</typeparam>
    public class ExcelStyleCollection<T> : IEnumerable<T>
    {
        public ExcelStyleCollection()
        {
            _setNextIdManual = false;
        }
        bool _setNextIdManual;
        public ExcelStyleCollection(bool SetNextIdManual)
        {
            _setNextIdManual = SetNextIdManual;
        }
        public XmlNode TopNode { get; set; }
        internal List<T> _list = new List<T>();
        Dictionary<string, int> _dic = new Dictionary<string, int>();
        internal int NextId=0;
        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        #endregion
        public T this[int PositionID]
        {
            get
            {
                return _list[PositionID];
            }
        }
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }
        //internal int Add(T item)
        //{
        //    _list.Add(item);
        //    if (_setNextIdManual) NextId++;
        //    return _list.Count-1;
        //}
        internal int Add(string key, T item)
        {
            _list.Add(item);
            if (!_dic.ContainsKey(key.ToLower())) _dic.Add(key.ToLower(), _list.Count - 1);
            if (_setNextIdManual) NextId++;
            return _list.Count-1;
        }
        /// <summary>
        /// Finds the key 
        /// </summary>
        /// <param name="key">the key to be found</param>
        /// <param name="obj">The found object.</param>
        /// <returns>True if found</returns>
        internal bool FindByID(string key, ref T obj)
        {
            if (_dic.ContainsKey(key.ToLower()))
            {
                obj = _list[_dic[key.ToLower()]];
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Find Index
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal int FindIndexByID(string key)
        {
            if (_dic.ContainsKey(key.ToLower()))
            {
                return _dic[key.ToLower()];
            }
            else
            {
                return int.MinValue;
            }
        }
        internal bool ExistsKey(string key)
        {
            return _dic.ContainsKey(key.ToLower());
        }
        internal void Sort(Comparison<T> c)
        {
            _list.Sort(c);
        }
    }
}
