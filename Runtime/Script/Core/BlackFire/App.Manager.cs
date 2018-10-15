/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;

namespace BlackFire.Unity
{
    public sealed partial class App
    {
        private static LinkedList<IManager> s_ManagerLinkedList = new LinkedList<IManager>();

        public static void RegisterManager(IManager manager)
        {
            if (!s_ManagerLinkedList.Contains(manager))
            {
                s_ManagerLinkedList.AddLast(manager);
            }
            else
            {
                throw new System.Exception("请勿重复注册管家，每一个管家有且只有一个实例！");
            }
        }

        public static void UnRegisterManager(IManager manager)
        {
            if (s_ManagerLinkedList.Contains(manager))
            {
                s_ManagerLinkedList.Remove(manager);
            }
        }

        private static void StartUnityManager(App instance)
        {
            if (null != instance)
            {
                BlackFire.Unity.Utility.Transform.TraverseChilds(instance.transform, trans =>
                {
                    var manager = trans.GetComponent<IManager>();
                    if (null != manager && manager.IsWorking)
                    {
                        manager.StartManager();
                    }
                });
            }
        }

        private static void ShutdownUnityManager(App instance)
        {
            if (null != instance)
            {
                BlackFire.Unity.Utility.Transform.TraverseChilds(instance.transform, trans =>
                {
                    var manager = trans.GetComponent<IManager>();
                    if (null != manager && manager.IsWorking)
                    {
                        manager.ShutdownManager();
                    }
                });
            }
        }

        public static T GetManager<T>() where T : IManager
        {
            var current = s_ManagerLinkedList.First;
            while (null != current)
            {
                if (current.Value is T)
                {
                    return (T) current.Value;
                }

                current = current.Next;
            }

            return default(T);
        }



    }
}