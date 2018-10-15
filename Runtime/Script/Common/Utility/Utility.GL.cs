/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;
using UnityEngine;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        public static class GL
        {

            public static Vector3[] QuadrangleLine(Vector3 origin, Vector3 end,float width)
            {
                var vector = (end - origin).normalized;
                var virticalVector = Quaternion.AngleAxis(90, Vector3.forward) * vector;
                return new Vector3[] {
                                        origin + virticalVector * (width / 2),
                                        origin - virticalVector * (width / 2),
                                        end + virticalVector * (width / 2),
                                        end - virticalVector * (width / 2),
                                     };
            }
        }

    }
}
