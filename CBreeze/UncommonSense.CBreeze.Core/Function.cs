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
    public partial class Function : KeyedItem<int>, IHasName, IHasParameters, IHasVariables
    {
        public Function(int id, string name)
        {
            ID = id;
            Name = name;
            CodeLines = new CodeLines();
            Parameters = new Parameters(this);
            ReturnValue = new FunctionReturnValue();
            Variables = new Variables(this);
        }

        public string Name
        {
            get;
            protected set;
        }

        public bool? Local
        {
            get;
            set;
        }

        public TransactionModel? TransactionModel
        {
            get;
            set;
        }

        public string HandlerFunctions
        {
            get;
            set;
        }

        public TestFunctionType? TestFunctionType
        {
            get;
            set;
        }

#if NAV2015
        public UpgradeFunctionType? UpgradeFunctionType
        {
            get;
            set;
        }
#endif

        public Functions Container
        {
            get;
            internal set;
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }

        public Parameters Parameters
        {
            get;
            protected set;
        }

        public FunctionReturnValue ReturnValue
        {
            get;
            protected set;
        }

        public Variables Variables
        {
            get;
            protected set;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
