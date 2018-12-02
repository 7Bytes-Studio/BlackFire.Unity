/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity
{
    /// <summary>
    /// Unity的UI元素。
    /// </summary>
    public abstract class UnityUIElement : UIElement
    {

#region RoutedEvent

        public static readonly RoutedEvent BeginDragEvent = new RoutedEvent("BeginDragEvent");
        public static readonly RoutedEvent DragEvent = new RoutedEvent("DragEvent");
        public static readonly RoutedEvent EndDragEvent = new RoutedEvent("EndDragEvent");
        public static readonly RoutedEvent DeselectEvent = new RoutedEvent("DeselectEvent");
        public static readonly RoutedEvent PointerClickEvent = new RoutedEvent("PointerClickEvent");
        public static readonly RoutedEvent PointerDownEvent = new RoutedEvent("PointerDownEvent");
        public static readonly RoutedEvent PointerUpEvent = new RoutedEvent("PointerUpEvent");
        public static readonly RoutedEvent PointerEnterEvent = new RoutedEvent("PointerEnterEvent");
        public static readonly RoutedEvent PointerExitEvent = new RoutedEvent("PointerExitEvent");

#endregion

        
        
        
        
        
        
        
        
        
        
        

        private Style m_Style = null;

        /// <summary>
        /// 元素的样式。
        /// </summary>
        public Style Style
        {
            get { return m_Style; }
            set
            {
                if (m_Style != value)
                {
                    OnStyleChange(m_Style,value);
                    m_Style = value;
                } 
            }
        }

        /// <summary>
        /// 样式被更改事件。
        /// </summary>
        /// <param name="oldStyle">旧样式。</param>
        /// <param name="newStyle">新样式。</param>
        protected virtual void OnStyleChange(Style oldStyle,Style newStyle){}
        
        private IUITemplate m_Template = null;
        /// <summary>
        /// 元素的模板。
        /// </summary>
        public virtual IUITemplate Template 
        {
            get { return m_Template; }
            set
            {
                if (m_Template != value)
                {
                    value.Owner = this;
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
        protected virtual void OnTemplateChange(IUITemplate oldTemplate,IUITemplate newTemplate){}

        /// <summary>
        /// 显示元素。
        /// </summary>
        public virtual void Show()
        {
            Template.Show();
        }

        /// <summary>
        /// 隐藏元素。
        /// </summary>
        public virtual void Hide()
        {
            Template.Hide();
        }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public virtual bool Interactable
        {
            get { return Template.Interactable;}
            set { Template.Interactable = value; }
        }

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
        protected virtual void OnApply(Style style, IUITemplate template){}

    }
}