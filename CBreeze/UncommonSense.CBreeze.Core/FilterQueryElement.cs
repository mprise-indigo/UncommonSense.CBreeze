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
    public partial class FilterQueryElement : QueryElement
    {
        private FilterQueryElementProperties properties = new FilterQueryElementProperties();

        public FilterQueryElement(Int32 id, String name, Int32? indentationLevel) : base(id, name, indentationLevel)
        {
        }

        public override QueryElementType Type
        {
            get
            {
                return QueryElementType.Filter;
            }
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public FilterQueryElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }
    }
}