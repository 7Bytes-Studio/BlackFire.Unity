/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.UI
{
    /// <summary>
    /// Unity的UI元素。
    /// </summary>
    public abstract class UnityUIElement : UIElement
    {

        /// <summary>
        /// 元素的样式。
        /// </summary>
        public Style Style;

        private Template m_Template = null;
        /// <summary>
        /// 元素的模板。
        /// </summary>
        public virtual Template Template 
        {
            get { return m_Template; }
            set
            {
                if (m_Template != value)
                {
                    OnTemplateChange(m_Template,value);
                    m_Template = value;
                }
            }
        }

        /// <summary>
        /// 模板被更改事件。
        /// </summary>
        /// <param name="oldTemplate">旧模板。</param>
        /// <param name="newTemplate">新模板。</param>
        protected virtual void OnTemplateChange(Template oldTemplate,Template newTemplate){}
        
        /// <summary>
        /// 显示元素。
        /// </summary>
        public abstract void Show();

        /// <summary>
        /// 隐藏元素。
        /// </summary>
        public abstract void Hide();

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public abstract bool Interactable { get; set; }

        /// <summary>
        /// 应用元素。
        /// </summary>
        public void Appliy()
        {
            OnApply(Style,Template);
        }

        /// <summary>
        /// 根据样式和模板进行UI调整的事件。
        /// </summary>
        /// <param name="style">样式。</param>
        /// <param name="template">模板。</param>
        protected abstract void OnApply(Style style,Template template);

    }
}