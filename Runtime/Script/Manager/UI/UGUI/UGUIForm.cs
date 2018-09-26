//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace BlackFire.Unity
{
    /// <summary>
    /// UI形体。
    /// </summary>
    public abstract class UGUIForm : UIForm
    {
        
        public override void Open()
        {
            
        }

        public override void Close()
        {
            
        }
        
        #region View

        private Canvas m_Canvas = null;
        public Canvas Canvas { get { return m_Canvas ?? (m_Canvas = GetComponent<Canvas>()); } }

        [SerializeField]
        [Range(0f, 1f)]
        private float m_Alpha = 1f;

        [SerializeField]
        private bool m_Interactable = true;

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Alpha = m_Alpha;
            Interactable = m_Interactable;
        }
#endif

        /// <summary>
        /// CanvasGroup组件缓存。
        /// </summary>
        private CanvasGroup m_CachedCanvasGroup = null;

        /// <summary>
        /// CanvasGroup。
        /// </summary>
        public CanvasGroup CanvasGroup { get { return m_CachedCanvasGroup ?? (m_CachedCanvasGroup = GetComponent<CanvasGroup>()); } }

        /// <summary>
        /// GraphicRaycaster组件缓存。
        /// </summary>
        private GraphicRaycaster m_GraphicRaycaster = null;

        /// <summary>
        /// GraphicRaycaster。
        /// </summary>
        public GraphicRaycaster GraphicRaycaster { get { return m_GraphicRaycaster ?? (m_GraphicRaycaster = GetComponent<GraphicRaycaster>()); } }


        /// <summary>
        /// 是否可交互。
        /// </summary>
        public virtual bool Interactable
        {
            get
            {
                return null != CanvasGroup ? CanvasGroup.interactable : false;
            }

            set
            {
                if (null != GraphicRaycaster)
                {
                    GraphicRaycaster.enabled = value;
                }

                if (null != CanvasGroup)
                {
                    CanvasGroup.interactable = value;
                }
            }
        }

        /// <summary>
        /// Alpha值。
        /// </summary>
        public virtual float Alpha
        {
            get
            {
                return null != CanvasGroup ? CanvasGroup.alpha : 1f;
            }

            set
            {
                if (null != CanvasGroup)
                {
                    CanvasGroup.alpha = value;
                }
            }
        }

        /// <summary>
        /// 显示的层级。
        /// </summary>
        public virtual int DisplayLevel
        {
            get
            {
                return SiblingIndex;
            }
            set
            {
                SiblingIndex = value;
            }
        }

        #endregion
        
        
        #region RectTransform


        private RectTransform m_CachedRectTransform = null;
        /// <summary>
        /// The cached rect transform component.
        /// </summary>
        public RectTransform CachedRectTransform { get { return m_CachedRectTransform ?? (m_CachedRectTransform = GetComponent<RectTransform>()); } }


        #endregion
        
    }
}