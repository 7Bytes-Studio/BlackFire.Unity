//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFire.Unity
{
    public sealed class FormGroupModule:IFormGroupModule
    {
        public bool CreateFormGroup<T>(long groupId, string groupName, int groupWeight) where T : FormGroup
        {
            return Organize.CreateGroup<T>(groupId,groupName,groupWeight);
        }

        public long QueryFormGroupId(string formGroupName)
        {
            return Organize.GetGroupId(formGroupName);
        }

        public bool JoinFormGroup(long groupId, FormGroupMember formGroupMember, int groupMemberWeight)
        {
            return Organize.Join(groupId, formGroupMember, groupMemberWeight);
        }

        public bool LeaveFormGroup(long groupId, long formGroupMemberId)
        {
            return Organize.Leave(groupId, formGroupMemberId);
        }

        public bool ExecuteCommand<T>(long groupId, FormCommandCallback<T> callback) where T : Event.IEventHandler
        {
            return Organize.ExecuteCommand<T>(groupId,i=>callback.Invoke(i),false);
        }
    }
}