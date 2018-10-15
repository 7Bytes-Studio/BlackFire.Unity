/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;

namespace BlackFire.Unity
{
    
    public delegate void FormCommandCallback<T>(T i) where T:Event.IEventHandler;
    
    /// <summary>
    /// Form Group模块接口。
    /// </summary>
    public interface IFormGroupModule
    {
        
        /// <summary>
        /// 创建组。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="groupName">组名。</param>
        /// <param name="groupWeight">组权重。</param>
        /// <typeparam name="T">组类型。</typeparam>
        /// <returns>是否创建成功。</returns>
        bool CreateFormGroup<T>(long groupId,string groupName,int groupWeight) where T : FormGroup;

        /// <summary>
        /// 创建组成员。
        /// </summary>
        /// <param name="form">形体。</param>
        /// <param name="id">组成员Id。</param>
        /// <param name="name">组成员名字。</param>
        /// <returns>是否创建成功。</returns>
        bool CreateFormGroupMember(Form form, long id, string name);
        
        /// <summary>
        /// 查询小组Id。
        /// </summary>
        /// <param name="formGroupName">小组名。</param>
        /// <returns>小组Id。</returns>
        long QueryFormGroupId(string formGroupName);
        
        /// <summary>
        /// 加入组。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="formGroupMemberId">组成员Id。</param>
        /// <param name="groupMemberWeight">组成员权重。</param>
        /// <returns>是否加入成功。</returns>
        bool JoinFormGroup(long groupId,long formGroupMemberId, int groupMemberWeight);
        
        /// <summary>
        /// 离开组。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="formGroupMemberId">组成员。</param>
        /// <returns>是否离开成功。</returns>
        bool LeaveFormGroup(long groupId,long formGroupMemberId);

        /// <summary>
        /// 下达命令。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="callback">命令会调。</param>
        /// <typeparam name="T">命令类型。</typeparam>
        /// <returns>命令是否执行成功。</returns>
        bool ExecuteCommand<T>(long groupId, FormCommandCallback<T> callback) where T : Event.IEventHandler;

    }
}