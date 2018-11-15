/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BlackFire.UI
{
    /// <summary>
    /// 可视化的对象。
    /// </summary>
    public abstract class Visual : IEnumerable
    {
        private Visual m_Parent;
        public virtual Visual VisualParent
        {
            get { return m_Parent; }
            set { SetVisualParent(value); }
        } 
        
        protected virtual int VisualChildrenCount
        {
            get { return Visualchildren.Count(); }
        }

        private List<Visual> m_Visualchildren = new List<Visual>();
        protected virtual IEnumerable<Visual> Visualchildren
        {
            get { return m_Visualchildren; }
        }
        
        public IEnumerator GetEnumerator()
        {
            return Visualchildren as IEnumerator;
        }

        public virtual void AddVisualChild(Visual child)
        {
            if (!m_Visualchildren.Contains(child))
            {
                m_Visualchildren.Add(child);
                OnVisualChildrenChanged(child,null);
            }
        }

        public virtual void RemoveVisualChild(Visual child)
        {
            if (m_Visualchildren.Contains(child))
            {
                m_Visualchildren.Remove(child);
                OnVisualChildrenChanged(null,child);
            }
        }

        public virtual Visual GetVisualChild(int index)
        {
            if (0<=index&&index<m_Visualchildren.Count)
            {
                return m_Visualchildren[index];
            }
            return default(Visual);
        }

        public virtual void SetVisualParent(Visual parent)
        {
            if(m_Parent!=parent)
                OnVisualParentChanged(m_Parent,parent);
            m_Parent = parent;
        }
        
        protected virtual void OnVisualChildrenChanged(Visual visualAdded, Visual visualRemoved)
        {
            
        }

        protected virtual void OnVisualParentChanged(Visual oldParent,Visual newParent)
        {
            
        }
    }
}