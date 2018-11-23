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

namespace BlackFire.Unity
{
    /// <summary>
    /// 集合显示。
    /// </summary>
    public class CollectionView : IEnumerable
    {
        /// <summary>
        /// 当前项被更改事件。
        /// </summary>
        public event EventHandler CurrentChanged;
        
        /// <summary>
        /// 是否能排序。
        /// </summary>
        public virtual bool CanSort
        {
            get { return false; }
        }

        /// <summary>
        /// 能否打组。
        /// </summary>
        public virtual bool CanGroup
        {
            get { return false; }
        }
        
        /// <summary>
        /// 能否过滤。
        /// </summary>
        public virtual bool CanFilter
        {
            get { return false; }
        }

        /// <summary>
        /// 当前项。
        /// </summary>
        public virtual object CurrentItem
        {
            get { throw new NotImplementedException(); }
        }
        
        /// <summary>
        /// 当前游标。
        /// </summary>
        public virtual int CurrentPosition
        {
            get { throw new NotImplementedException(); }
        }
        
        /// <summary>
        /// 显示数目。
        /// </summary>
        public virtual int Count 
        {
            get { return m_Items.Count; }
        }
        
        /// <summary>
        /// 目标项的所在索引位。
        /// </summary>
        /// <param name="item">目标项。</param>
        /// <returns>索引。(-1代表异常)</returns>
        public virtual int IndexOf(object item)
        {
            return m_Items.IndexOf(item);
        }

        /// <summary>
        /// 通过索引获取目标项。
        /// </summary>
        /// <param name="index">索引。</param>
        /// <returns>目标项。</returns>
        public virtual object GetItemAt(int index)
        {
            if (0<= index && index<m_Items.Count)
            {
                return m_Items[index];
            }
            return null;
        }

        /// <summary>
        /// 移动当前项到目标游标对应的位置。
        /// </summary>
        /// <param name="position">游标。</param>
        /// <returns>是否移动成功。</returns>
        public virtual bool MoveToPosition(object item,int position)
        {
            if (position >= m_Items.Count || 0>position) return false;
            
            var index = m_Items.IndexOf(item); //移动前的索引位置。
            
            if (index == position) return true;
            
            var toMove = m_Items[index]; //将要移动的项

            object t = null;
            if (position<index)
            {
                for (int i = index; i > position ; i--)
                {
                    m_Items[i] = m_Items[i-1];
                }
                m_Items[position] = toMove;
            }
            else
            {
                for (int i = index; i < position ; i--)
                {
                    m_Items[i] = m_Items[i+1];
                }
                m_Items[position] = toMove;  
            }
            return true; 
        }

        /// <summary>
        /// 添加项。
        /// </summary>
        /// <param name="item">项。</param>
        /// <returns>是否添加成功。</returns>
        public virtual bool AddItem(object item)
        {
            if (!m_Items.Contains(item))
            {
                m_Items.Add(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移除项。
        /// </summary>
        /// <param name="item">项。</param>
        /// <returns>是否移除。</returns>
        public virtual bool Remove(object item)
        {
            return m_Items.Remove(item);
        }
     
        private List<object> m_Items =new List<object>();
        public IEnumerator GetEnumerator()
        {
            yield return m_Items.GetEnumerator();
        }
        
    }
    
    
    
}