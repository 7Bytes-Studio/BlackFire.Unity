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
    /// 逻辑化形体(本质是资产和逻辑结合)。
    /// </summary>
    //[RequireComponent(typeof(Asset))]
    public abstract class LogicalForm : VirtualWorldForm 
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
