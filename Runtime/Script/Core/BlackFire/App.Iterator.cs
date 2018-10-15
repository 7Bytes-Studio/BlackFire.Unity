/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections;
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

    }
}