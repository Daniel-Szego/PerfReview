using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.VBA
{
    /// <summary>
    /// A VBA reference
    /// </summary>
    public class ExcelVbaReference
    {
        /// <summary>
        /// Constructor.
        /// Defaults ReferenceRecordID to 0xD
        /// </summary>
        public ExcelVbaReference()
        {
            ReferenceRecordID = 0xD;
        }
        /// <summary>
        /// The reference record ID. See MS-OVBA documentation for more info. 
        /// </summary>
        public int ReferenceRecordID { get; internal set; }
        /// <summary>
        /// The name of the reference
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// LibID
        /// For more info check MS-OVBA 2.1.1.8 LibidReference and 2.3.4.2.2 PROJECTREFERENCES
        /// </summary>
        public string Libid { get; set; }
        /// <summary>
        /// A string representation of the object (the Name)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
    /// <summary>
    /// A reference to a twiddled type library
    /// </summary>
    public class ExcelVbaReferenceControl : ExcelVbaReference
    {
        /// <summary>
        /// Constructor.
        /// Sets ReferenceRecordID to 0x2F
        /// </summary>
        public ExcelVbaReferenceControl()
        {
            ReferenceRecordID = 0x2F;
        }
        /// <summary>
        /// LibIdExternal 
        /// For more info check MS-OVBA 2.1.1.8 LibidReference and 2.3.4.2.2 PROJECTREFERENCES
        /// </summary>
        public string LibIdExternal { get; set; }
        /// <summary>
        /// LibIdTwiddled
        /// For more info check MS-OVBA 2.1.1.8 LibidReference and 2.3.4.2.2 PROJECTREFERENCES
        /// </summary>
        public string LibIdTwiddled { get; set; }
        /// <summary>
        /// A GUID that specifies the Automation type library the extended type library was generated from.
        /// </summary>
        public Guid OriginalTypeLib { get; set; }
        internal uint Cookie { get; set; }
    }
    /// <summary>
    /// A reference to an external VBA project
    /// </summary>
    public class ExcelVbaReferenceProject : ExcelVbaReference
    {
        /// <summary>
        /// Constructor.
        /// Sets ReferenceRecordID to 0x0E
        /// </summary>
        public ExcelVbaReferenceProject()
        {
            ReferenceRecordID = 0x0E;
        }
        /// <summary>
        /// LibIdRelative
        /// For more info check MS-OVBA 2.1.1.8 LibidReference and 2.3.4.2.2 PROJECTREFERENCES
        /// </summary>
        public string LibIdRelative { get; set; }
        /// <summary>
        /// Major version of the referenced VBA project
        /// </summary>
        public uint MajorVersion { get; set; }
        /// <summary>
        /// Minor version of the referenced VBA project
        /// </summary>
        public ushort MinorVersion { get; set; }
    }
}
