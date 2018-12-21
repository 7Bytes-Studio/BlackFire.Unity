/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using UnityEngine;

namespace BlackFire.Unity
{
    [Serializable]
    public struct SVector3
    {
        public SVector3(Vector3 value)
        {
            this.x = value.x;
            this.y = value.y;
            this.z = value.z;
        }

        public float x;

        public float y;

        public float z;

        public override string ToString()
        {
            return string.Format("({0},{1},{2})",x,y,z);
        }
    }


    public static class SVector3Extension
    {
        public static Vector3 ToVector3(this SVector3 sVector3)
        {
            return new Vector3(sVector3.x,sVector3.y,sVector3.z);
        }
        
        public static SVector3 ToSVector3(this Vector3 sVector3)
        {
            return new SVector3(sVector3);
        }
    }

}