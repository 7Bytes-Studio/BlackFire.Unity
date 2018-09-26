//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// UI形体。
    /// </summary>
    public abstract class UIForm : LogicalForm
    {
        public abstract void Open();

        public abstract void Close();

        protected override void OnInit()
        {
            
        }

        protected override void OnShow()
        {
            Open();
        }

        protected override void OnUpdate()
        {
           
        }

        protected override void OnHide()
        {
            Close();
        }

        protected override void OnDestroyed()
        {
            
        }

    }
}