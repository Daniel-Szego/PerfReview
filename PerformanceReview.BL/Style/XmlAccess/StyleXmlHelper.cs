using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace OfficeOpenXml.Style.XmlAccess
{
    /// <summary>
    /// Xml helper class for cell style classes
    /// </summary>
    public abstract class  StyleXmlHelper : XmlHelper
    {
        internal StyleXmlHelper(XmlNamespaceManager nameSpaceManager) : base(nameSpaceManager)
        { 

        }
        internal StyleXmlHelper(XmlNamespaceManager nameSpaceManager, XmlNode topNode) : base(nameSpaceManager, topNode)
        {
        }
        internal abstract XmlNode CreateXmlNode(XmlNode top);
        internal abstract string Id
        {
            get;
        }
        internal long useCnt=0;
        internal int newID=int.MinValue;
    }
}
