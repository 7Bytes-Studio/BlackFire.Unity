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
        /// <summary>
        /// 可视化结点。
        /// </summary>
        public virtual Visual VisualParent
        {
            get { return m_Parent; }
            set { SetVisualParent(value); }
        } 
        
        /// <summary>
        /// 可视化结点的数量。
        /// </summary>
        public virtual int VisualChildrenCount
        {
            get { return Visualchildren.Count(); }
        }

        private List<Visual> m_Visualchildren = new List<Visual>();
        /// <summary>
        /// 可视化结点的孩子集合。
        /// </summary>
        public virtual IEnumerable<Visual> Visualchildren
        {
            get { return m_Visualchildren; }
        }
        
        public IEnumerator GetEnumerator()
        {
            return Visualchildren as IEnumerator;
        }

        /// <summary>
        /// 添加可视化结点的孩子结点。
        /// </summary>
        /// <param name="child">孩子。</param>
        public virtual void AddVisualChild(Visual child)
        {
            if (!m_Visualchildren.Contains(child))
            {
                m_Visualchildren.Add(child);
                OnVisualChildrenChanged(child,null);
            }
        }

        /// <summary>
        /// 移除可视化结点的孩子结点。
        /// </summary>
        /// <param name="child">孩子。</param>
        public virtual void RemoveVisualChild(Visual child)
        {
            if (m_Visualchildren.Contains(child))
            {
                m_Visualchildren.Remove(child);
                OnVisualChildrenChanged(null,child);
            }
        }

        /// <summary>
        /// 获取可视化结点的孩子。
        /// </summary>
        /// <param name="index">索引。</param>
        /// <returns>目标孩子结点。</returns>
        public virtual Visual GetVisualChild(int index)
        {
            if (0<=index&&index<m_Visualchildren.Count)
            {
                return m_Visualchildren[index];
            }
            return default(Visual);
        }

        /// <summary>
        /// 设置可视化结点的父亲结点。。
        /// </summary>
        /// <param name="parent">父亲节点。</param>
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