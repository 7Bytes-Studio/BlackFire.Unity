//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace BlackFire.Unity
{
	public interface IFormManager:IManager
	{
		Asset Instantiate(Asset asset,string groupName,long id,string name,int weight);
		void Destroy(long groupId,long id);
		bool CreateFormGroup<T>(string groupName,long groupId,int groupWeight) where T : FormGroup;
		bool ExecuteCommand<T>(long groupId, FormCommandCallback<T> callback) where T : Event.IEventHandler;
		long GetFormGroupId(string formGroupName);
	}

	/// <summary>
    /// Form管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Form")]
    public sealed partial class FormManager : ManagerBase, IFormManager
	{

		private IFormGroupModule m_FormGroupModule = null;
		
		protected override void OnStart()
        {
            base.OnStart();
	        m_FormGroupModule = new FormGroupModule();
	        CreateFormGroup<DefaultFormGroup>("Default",0,0);
        }

		
		
		
		
		private SortedDictionary<string,Asset> m_AssetDic = new SortedDictionary<string, Asset>();
		
		public Asset Instantiate(Asset asset,string groupName,long id,string name,int weight)
		{
			var groupId = m_FormGroupModule.QueryFormGroupId(groupName);
			var guid = string.Format("{0}:{1}", groupId, id);
			if (!m_AssetDic.ContainsKey(guid))
			{
				var ins = GameObject.Instantiate<Asset>(asset);
				ins.GroupName = groupName;
				ins.GroupId = groupId;
				ins.Id = id;
				m_AssetDic.Add(guid,ins);

				m_FormGroupModule.JoinFormGroup(groupId,new FormGroupMember(ins,id,name),weight);
				
				return ins;
			}
			return m_AssetDic[guid];
		}


		public void Destroy(long groupId,long id)
		{
			var guid = string.Format("{0}:{1}", groupId, id);
			if (m_AssetDic.ContainsKey(guid))
			{
				var target = m_AssetDic[guid];
				GameObject.DestroyImmediate(target);

				m_FormGroupModule.LeaveFormGroup(groupId,id);
				
				m_AssetDic.Remove(guid);
			}
		}

		public bool CreateFormGroup<T>(string groupName, long groupId, int groupWeight) where T : FormGroup
		{
			return m_FormGroupModule.CreateFormGroup<T>(groupId,groupName,groupWeight);
		}


		public bool ExecuteCommand<T>(long groupId, FormCommandCallback<T> callback) where T : Event.IEventHandler
		{
			return m_FormGroupModule.ExecuteCommand<T>(groupId,callback);
		}


		public long GetFormGroupId(string formGroupName)
		{
			return m_FormGroupModule.QueryFormGroupId(formGroupName);
		}


	}




	public static class IFormManagerExtension
	{
		public static T Instantiate<T>(this IFormManager formManager,Asset asset,string groupName,long id,string name,int weight) where T:LogicalForm
		{
			if (null == asset.GetComponent<LogicalForm>()) return default(T);
			
			var ins = formManager.Instantiate(asset, groupName, id, name, weight);
			return ins.GetComponent<LogicalForm>() as T;
		}
		
		public static T Instantiate<T>(this IFormManager formManager,Asset asset,string groupName,long id) where T:LogicalForm
		{
			if (null == asset.GetComponent<LogicalForm>()) return default(T);
			
			var ins = formManager.Instantiate(asset, groupName, id, asset.name+"_"+Time.realtimeSinceStartup, 0);
			return ins.GetComponent<LogicalForm>() as T;
		}
		
		
		public static Asset Instantiate(this IFormManager formManager,Asset asset,string groupName,long id) 
		{
			return formManager.Instantiate(asset, groupName, id, asset.name+"_"+Time.realtimeSinceStartup, 0);
		}


		public static bool CreateFormGroup<T>(this IFormManager formManager,string groupName, long groupId) where T : FormGroup
		{
			return formManager.CreateFormGroup<T>(groupName,groupId,0);
		}
		
		
		public static bool ExecuteCommand<T>(this IFormManager formManager,string groupName, FormCommandCallback<T> callback) where T : Event.IEventHandler
		{
			var groupId = formManager.GetFormGroupId(groupName);
			return formManager.ExecuteCommand<T>(groupId,callback);
		}
		

	}

}
