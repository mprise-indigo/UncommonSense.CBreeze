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
    public class XmlPortTextElementProperties : Properties
    {
        private TableFieldTypeProperty dataType = new TableFieldTypeProperty("DataType");
        private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
        private MinOccursProperty minOccurs = new MinOccursProperty("MinOccurs");
        private ScopedTriggerProperty onAfterAssignVariable = new ScopedTriggerProperty("OnAfterAssignVariable");
        private ScopedTriggerProperty onBeforePassVariable = new ScopedTriggerProperty("OnBeforePassVariable");
        private TextTypeProperty textType = new TextTypeProperty("TextType");
#if NAV2013R2
        private NullableBooleanProperty unbound = new NullableBooleanProperty("Unbound");
#endif
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTextElementProperties()
        {
            innerList.Add(dataType);
            innerList.Add(variableName);
            innerList.Add(textType);
            innerList.Add(minOccurs);
            innerList.Add(maxOccurs);
            innerList.Add(onAfterAssignVariable);
            innerList.Add(onBeforePassVariable);
#if NAV2013R2
            innerList.Add(unbound);
#endif
            innerList.Add(width);
        }

        public TableFieldType? DataType
        {
            get
            {
                return this.dataType.Value;
            }
            set
            {
                this.dataType.Value = value;
            }
        }

        public MaxOccurs? MaxOccurs
        {
            get
            {
                return this.maxOccurs.Value;
            }
            set
            {
                this.maxOccurs.Value = value;
            }
        }

        public MinOccurs? MinOccurs
        {
            get
            {
                return this.minOccurs.Value;
            }
            set
            {
                this.minOccurs.Value = value;
            }
        }

        public Trigger OnAfterAssignVariable
        {
            get
            {
                return this.onAfterAssignVariable.Value;
            }
        }

        public Trigger OnBeforePassVariable
        {
            get
            {
                return this.onBeforePassVariable.Value;
            }
        }

        public TextType? TextType
        {
            get
            {
                return this.textType.Value;
            }
            set
            {
                this.textType.Value = value;
            }
        }

#if NAV2013R2
        public bool? Unbound
        {
            get
            {
                return this.unbound.Value;
            }
            set
            {
                this.unbound.Value = value;
            }
        }
#endif

        public System.String VariableName
        {
            get
            {
                return this.variableName.Value;
            }
            set
            {
                this.variableName.Value = value;
            }
        }

        public System.Int32? Width
        {
            get
            {
                return this.width.Value;
            }
            set
            {
                this.width.Value = value;
            }
        }
    }
}
