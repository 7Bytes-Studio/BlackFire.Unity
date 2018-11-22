/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 虚拟世界形体。
    /// </summary>
    public abstract class VirtualWorldForm : Form , IAssetEventHandler
    {

        #region Lifecircle
                
        protected Asset Asset;
        void IAssetEventHandler.OnInit(Asset asset)
        {
            Asset = asset;
            OnInit();
        }

        void IAssetEventHandler.OnShow()
        {
            OnShow();
        }

        void IAssetEventHandler.OnUpdate()
        {
            OnUpdate();
        }

        void IAssetEventHandler.OnHide()
        {
            OnHide();
        }

        void IAssetEventHandler.OnDestroyed()
        {
            OnDestroyed();
        }

        protected virtual void OnInit()
        {
        }
        protected virtual void OnShow() 
        {
        }
        protected virtual void OnUpdate() 
        {
        }
        protected virtual void OnHide()
        {
        }
        protected virtual void OnDestroyed()
        {
        }
                
        #endregion
        
    }
}
