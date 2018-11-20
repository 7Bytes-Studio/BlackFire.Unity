/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
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
            if(null!=m_Visualchildren)
                for (int i = 0; i < m_Visualchildren.Count; i++)
                {
                    yield return m_Visualchildren[i];
                }
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
                child.VisualParent = this;
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
                child.VisualParent = null;
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


        #region RoutedEvents

        /// <summary>
        /// 路由事件处理函数。
        /// </summary>
        /// <param name="sender">发送者。</param>
        /// <param name="args">事件参数。</param>
        protected internal virtual void OnRoutedEvents(object sender,RoutedEventArgs args)
        {
            
        }


        #endregion
        
        
        
        
        /// <summary>
        /// 遍历策略。
        /// </summary>
        public enum TraverseStrategy
        {
            /// <summary>
            /// 广度遍历。
            /// </summary>
            Breadth,
            /// <summary>
            /// 深度遍历。
            /// </summary>
            Depth
        }
            
        
        #region ReverseTraverse Action<Visual> callback

        /// <summary>
        /// 反向遍历可视化节点。
        /// </summary>
        /// <param name="node">可视化节点。</param>
        /// <param name="callback">反向遍历回调。</param>
        public static void ReverseTraverse(Visual node,Action<Visual> callback)
        {
            if(null==callback || null==node) return;
            
            var current = node;
            while (null!=current)
            {
                callback.Invoke(current);
                current = current.VisualParent;
            }
        }

        #endregion
        
        #region ReverseTraverse Predicate<Visual> callback

        /// <summary>
        /// 反向遍历可视化节点。
        /// </summary>
        /// <param name="node">可视化节点。</param>
        /// <param name="callback">反向遍历回调。</param>
        public static void ReverseTraverse(Visual node,Predicate<Visual> callback)
        {
            if(null==callback || null==node) return;
            
            var current = node;
            while (null!=current)
            {
                if (callback.Invoke(current))
                    return;
                current = current.VisualParent;
            }
        }

        #endregion
        
 
        #region Action<Visual> callback

        /// <summary>
        /// 遍历可视化节点。
        /// </summary>
        /// <param name="node">可视化节点。</param>
        /// <param name="callback">遍历回调。</param>
        /// <param name="traverseStrategy">遍历策略。</param>
        public static void Traverse(Visual node,Action<Visual> callback,TraverseStrategy traverseStrategy = TraverseStrategy.Breadth)
        {
            if(null==callback || null==node) return;

            callback.Invoke(node);
            switch (traverseStrategy)
            {
                case TraverseStrategy.Breadth : Breadth(node,callback);
                    break;
                case TraverseStrategy.Depth : Depth(node,callback);
                    break;
                default: return;
            }   
        }
        
        private static void Breadth(Visual node,Action<Visual> callback)
        {
            foreach (Visual child in node)
            {
                callback.Invoke(child);
            }
            foreach (Visual child in node)
            {
                Breadth(child,callback);
            }
        }
        
        private static void Depth(Visual node,Action<Visual> callback)
        {
            foreach (Visual child in node)
            {
                Depth(child,callback);
                callback.Invoke(child);
            }
        }

        #endregion
        

        #region Predicate<Visual> callback

        /// <summary>
        /// 遍历可视化节点。
        /// </summary>
        /// <param name="node">可视化节点。</param>
        /// <param name="callback">遍历回调。</param>
        /// <param name="traverseStrategy">遍历策略。</param>
        public static void Traverse(Visual node,Predicate<Visual> callback,TraverseStrategy traverseStrategy = TraverseStrategy.Breadth)
        {
            if(null==callback || null==node) return;

            callback.Invoke(node);
            switch (traverseStrategy)
            {
                case TraverseStrategy.Breadth : Breadth(node,callback);
                    break;
                case TraverseStrategy.Depth : Depth(node,callback);
                    break;
                default: return;
            }   
        }

        
        private static void Breadth(Visual node,Predicate<Visual> callback)
        {
            foreach (Visual child in node)
            {
                if(callback.Invoke(child))
                    return;
            }
            foreach (Visual child in node)
            {
                Breadth(child,callback);
            }
        }
        
        private static void Depth(Visual node,Predicate<Visual> callback)
        {
            foreach (Visual child in node)
            {
                Depth(child,callback);
                if(callback.Invoke(child))
                    return;
            }
        }

        #endregion

        
    }
}