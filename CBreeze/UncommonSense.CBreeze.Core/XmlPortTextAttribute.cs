// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortTextAttribute : XmlPortNode
    {
        private XmlPortTextAttributeProperties properties = new XmlPortTextAttributeProperties();

        public XmlPortTextAttribute(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortTextAttribute;
            }
        }

        public XmlPortTextAttributeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}