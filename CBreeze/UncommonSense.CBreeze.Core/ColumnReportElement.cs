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
    public partial class ColumnReportElement : ReportElement, IHasOptionString
    {
        public ColumnReportElement(int id, int? indentationLevel)
            : base(id, indentationLevel)
        {
            Properties = new ColumnReportElementProperties();
        }

        public override ReportElementType Type
        {
            get
            {
                return ReportElementType.Column;
            }
        }

        public ColumnReportElementProperties Properties
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public string GetOptionString()
        {
            return Properties.OptionString;
        }
    }
}
