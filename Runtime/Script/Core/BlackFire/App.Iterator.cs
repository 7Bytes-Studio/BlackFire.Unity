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
using UnityEngine;

namespace BlackFire.Unity
{
    public sealed partial class App
    {

        private static MonoBehaviour m_Mono;

        private static void SetIterator(MonoBehaviour mono)
        {
            m_Mono = mono;
            BlackFire.Iterator.IteratorStartCallback = BlackFire_IteratorStartCallback;
            BlackFire.Iterator.IteratorCancelCallback = BlackFire_IteratorCancelCallback;
        }


        private static void BlackFire_IteratorStartCallback(string name, IEnumerator enumerator)
        {
            m_Mono.StartCoroutine(enumerator);
        }


        private static void BlackFire_IteratorCancelCallback(string name, IEnumerator enumerator)
        {
            m_Mono.StopCoroutine(enumerator);
        }
        
        
        /// <summary>
        /// 框架迭代程序管理静态类。
        /// </summary>
        public static class Iterator
        {
            /// <summary>
            /// 所有的迭代器名字集合。
            /// </summary>
            public static IEnumerable<string> AllIteratorNames
            {
                get { return BlackFire.Iterator.AllIteratorNames; }
            }

            /// <summary>
            /// 是否存在迭代器>
            /// </summary>
            /// <param name="name">迭代器名字。</param>
            /// <returns>是否存在。</returns>
            public static bool HasIterator(string name)
            {
                return BlackFire.Iterator.HasIterator(name);
            }
    
    
            /// <summary>
            /// 启动迭代器。
            /// </summary>
            /// <param name="name">迭代器名字。</param>
            /// <param name="enumerator">迭代器接口。</param>
            /// <returns>是否已经启动了此迭代器。</returns>
            public static bool Start(string name, IEnumerator enumerator)
            {
                return BlackFire.Iterator.Start(name,enumerator);
            }
    
            
            /// <summary>
            /// 取消迭代器。
            /// </summary>
            /// <param name="name">迭代器名字。</param>
            public static void Cancel(string name)
            {
                BlackFire.Iterator.Cancel(name);
            }
        }
        
        
        
        
        
        
        
        
        

    }
}