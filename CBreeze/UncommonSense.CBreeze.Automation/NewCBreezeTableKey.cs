﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeTableKey", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(TableKey))]
    [Alias("Key")]
    public class NewCBreezeTableKey : NewItemCmdlet<TableKey, Table>
    {
        protected override void AddItemToInputObject(TableKey item, Table inputObject)
        {
            inputObject.Keys.Add(item);
        }

        protected override IEnumerable<TableKey> CreateItems()
        {
            var tableKey = new TableKey(Fields);

            tableKey.Enabled = Enabled;
            tableKey.Properties.Clustered = Clustered;
            tableKey.Properties.KeyGroups = KeyGroups;
            tableKey.Properties.MaintainSIFTIndex = MaintainSIFTIndex;
            tableKey.Properties.MaintainSQLIndex = MaintainSQLIndex;
            tableKey.Properties.SQLIndex.AddRange(SQLIndex ?? new string[] { });
            tableKey.Properties.SumIndexFields.AddRange(SumIndexFields ?? new string[] { });

            yield return tableKey;
        }

        [Parameter()]
        public bool? Clustered
        {
            get;
            set;
        }

        [Parameter()]
        public bool? Enabled
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string[] Fields
        {
            get;
            set;
        }

        [Parameter()]
        public string KeyGroups
        {
            get;
            set;
        }

        [Parameter()]
        public bool? MaintainSIFTIndex
        {
            get;
            set;
        }

        [Parameter()]
        public bool? MaintainSQLIndex
        {
            get;
            set;
        }

        [Parameter()]
        public string[] SQLIndex
        {
            get;
            set;
        }

        [Parameter()]
        public string[] SumIndexFields
        {
            get;
            set;
        }
    }
}