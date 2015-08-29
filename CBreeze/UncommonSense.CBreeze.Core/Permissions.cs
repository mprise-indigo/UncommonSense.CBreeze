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
    public class Permissions : IEnumerable<Permission>
    {
        private Dictionary<Int32,Permission> innerList = new Dictionary<Int32,Permission>();

        // Ctor made public to allow PermissionProperty to new up an instance
        public Permissions()
        {
        }

        public void Set(Int32 tableID, Boolean readPermission, Boolean insertPermission, Boolean modifyPermission, Boolean deletePermission)
        {
            Unset(tableID);
            innerList.Add(tableID, new Permission(tableID, readPermission, insertPermission, modifyPermission, deletePermission));
        }

        public void Reset()
        {
            innerList.Clear();
        }

        public bool Unset(Int32 tableID)
        {
            return innerList.Remove(tableID);
        }

        public IEnumerator<Permission> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}