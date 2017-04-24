using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class DateTimeParameter : Parameter
    {
        public DateTimeParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public override ParameterType Type => ParameterType.DateTime;
    }
}