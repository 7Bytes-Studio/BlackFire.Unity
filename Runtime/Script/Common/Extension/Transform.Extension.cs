/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    public static class TransformExtension
	{
        public static T FindComponent<T>(this Transform transform)
        {
            T target = default(T);
            Utility.Transform.TraverseParents(transform, t => null == (target = t.GetComponent<T>()) );
            return target;
        }
	
	}
}
