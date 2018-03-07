using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.VBA
{
    /// <summary>
    /// Type of VBA module
    /// </summary>
    public enum eModuleType
    {
        /// <summary>
        /// A Workbook or Worksheet objects
        /// </summary>
        Document=0,
        /// <summary>
        /// A Module
        /// </summary>
        Module=1,
        /// <summary>
        /// A Class
        /// </summary>
        Class=2,
        /// <summary>
        /// Designer, typically a user form
        /// </summary>
        Designer=3
    }
    internal delegate void ModuleNameChange(string value);

    /// <summary>
    /// A VBA code module. 
    /// </summary>
    public class ExcelVBAModule
    {
        string _name = "";
        ModuleNameChange _nameChangeCallback = null;
        internal ExcelVBAModule()
        {
            Attributes = new ExcelVbaModuleAttributesCollection();
        }
        internal ExcelVBAModule(ModuleNameChange nameChangeCallback) :
            this()
        {
            _nameChangeCallback = nameChangeCallback;
        }
        /// <summary>
        /// The name of the module
        /// </summary>
        public string Name 
        {   
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                streamName = value;
                if (_nameChangeCallback != null)
                {
                    _nameChangeCallback(value);
                }
            }
        }
        /// <summary>
        /// A description of the module
        /// </summary>
        public string Description { get; set; }
        private string _code="";
        /// <summary>
        /// The code without any module level attributes.
        /// <remarks>Can contain function level attributes.</remarks> 
        /// </summary>
        public string Code {
            get
            {
                return _code;
            }
            set
            {
                if(value.StartsWith("Attribute",StringComparison.InvariantCultureIgnoreCase) || value.StartsWith("VERSION",StringComparison.InvariantCultureIgnoreCase))
                {
                    throw(new InvalidOperationException("Code can't start with an Attribute or VERSION keyword. Attributes can be accessed through the Attributes collection."));
                }
                _code = value;
            }
        }
        /// <summary>
        /// A reference to the helpfile
        /// </summary>
        public int HelpContext { get; set; }
        /// <summary>
        /// Module level attributes.
        /// </summary>
        public ExcelVbaModuleAttributesCollection Attributes { get; internal set; }
        /// <summary>
        /// Type of module
        /// </summary>
        public eModuleType Type { get; internal set; }
        /// <summary>
        /// If the module is readonly
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// If the module is private
        /// </summary>
        public bool Private { get; set; }
        internal string streamName { get; set; }
        internal ushort Cookie { get; set; }
        internal uint ModuleOffset { get; set; }
        internal string ClassID { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
