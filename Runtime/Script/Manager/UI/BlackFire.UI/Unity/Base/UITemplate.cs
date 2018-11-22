/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// UI模板。
    /// </summary>
    public abstract class UITemplate : LogicalForm,IUITemplate
    {
        /// <summary>
        /// 虚拟世界形体的逻辑接口。
        /// </summary>
        public override ILogic Logic
        {
            get { return this; }
        }
        
        private UnityUIElement m_Owner = null;
        /// <summary>
        /// 模板的持有者。
        /// </summary>
        public UnityUIElement Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }
    }
}