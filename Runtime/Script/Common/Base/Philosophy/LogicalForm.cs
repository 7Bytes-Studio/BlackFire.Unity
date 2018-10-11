//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 逻辑化形体(本质是资产和逻辑结合)。
    /// </summary>
    [RequireComponent(typeof(Asset))]
    public abstract class LogicalForm : VirtualWorldForm , IAssetEventHandler
    {

        /// <summary>
        /// 虚拟世界形体的逻辑接口。
        /// </summary>
        public abstract ILogic Logic { get;  }

        /// <summary>
        /// 显示虚拟世界形体。
        /// </summary>
        public virtual void Show()
        {
            OnShow();
        }
        
        /// <summary>
        /// 隐藏虚拟世界形体。
        /// </summary>
        public virtual void Hide()
        {
            OnHide();
        }
        
    }
}
