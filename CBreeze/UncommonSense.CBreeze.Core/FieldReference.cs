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
    public partial class FieldReference
    {
        private String fieldName;

        internal FieldReference(String fieldName)
        {
            this.fieldName = fieldName;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

    }
}