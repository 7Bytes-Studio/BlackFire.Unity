//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 资产(形体)。
    /// </summary>
    public sealed class Asset : Nature
    {

        /// <summary>
        /// 资产组名。
        /// </summary>
        public string GroupName { get; internal set; }

        /// <summary>
        /// 资产组Id。
        /// </summary>
        public long GroupId { get; internal set; }

        /// <summary>
        /// 资产Id。
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// 资产被唤醒事件。
        /// </summary>
        private void Awake()
        {
            TunnelingEvent<IAssetEventHandler>(i=>i.OnInit(this));
        }


        /// <summary>
        /// 显示资产。
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            TunnelingEvent<IAssetEventHandler>(i=>i.OnShow());
        }

        /// <summary>
        /// 轮询资产。
        /// </summary>
        private void Update()
        {
            TunnelingEvent<IAssetEventHandler>(i=>i.OnUpdate());
        }

        /// <summary>
        /// 隐藏资产。
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
            TunnelingEvent<IAssetEventHandler>(i=>i.OnHide());
        }


        /// <summary>
        /// 资产被销毁事件。
        /// </summary>
        private void OnDestroy()
        {
            TunnelingEvent<IAssetEventHandler>(i=>i.OnDestroyed());
        }


        /// <summary>
        /// 隧道事件。
        /// </summary>
        private void TunnelingEvent<T>(Action<T> callback,int tunnelingLayer=int.MaxValue)
        {
            int currentLayer = 0;
            BreadthTraverse(transform,callback,ref currentLayer,tunnelingLayer);
        }

        private void BreadthTraverse<T>(Transform node,Action<T> callback,ref int currentLayer,int tunnelingLayer)
        {
            Queue<Transform> queue = new Queue<Transform>();
            foreach (Transform child in node)
            {
                var t = child.GetComponent<T>();
                if (null!=t)
                {
                    callback.Invoke(t);
                }
                queue.Enqueue(child);
            }

            if (++currentLayer>=tunnelingLayer) return;
            
            while (0!=queue.Count)
            {
                var tf = queue.Dequeue();
                BreadthTraverse<T>(tf,callback,ref currentLayer,tunnelingLayer);
            }
        }


        public override string ToString()
        {
            return string.Format("Group Name : {0} \nGroup Id : {1}\nId : {2}", GroupName,GroupId, Id);
        }

    }


    /// <summary>
    /// 资产事件处理者接口。
    /// </summary>
    public interface IAssetEventHandler
    {
        void OnInit(Asset asset);
        
        void OnShow();

        void OnUpdate();
        
        void OnHide();

        void OnDestroyed();
    }


    /// <summary>
    /// 资产扩展类。
    /// </summary>
    public static class AssetExtension
    {

        /// <summary>
        /// 获取游戏形体。
        /// </summary>
        public static LogicalForm GetLogicalForm(this Asset asset)
        {
            return asset.GetComponent<LogicalForm>();
        }
        
        /// <summary>
        /// 获取游戏形体逻辑接口。
        /// </summary>
        public static ILogic GetLogic(this Asset asset)
        {
            var logicalForm = asset.GetComponent<LogicalForm>();
            return null != logicalForm ? logicalForm.Logic : default(ILogic);
        }

    }

}