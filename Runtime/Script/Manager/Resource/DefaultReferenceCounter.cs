/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.Unity
{
    public sealed class DefaultReferenceCounter : IReferenceCounter
    {
        public int RefCount { get; private set; }

        public int CumulativeCount { get; private set; }

        public int RegressiveCount { get; private set; }

        public event Action OnRefCountIsZero;

        public void Cumulative(object ref_owner)
        {
            ++CumulativeCount;
            ++RefCount;
        }

        public void Regressive(object ref_owner)
        {
            if (RefCount <= 0) return;
            --RefCount;
            ++RegressiveCount;
            if (0==RefCount && null!= OnRefCountIsZero)
            {
                OnRefCountIsZero.Invoke();
            }
        }
    }
}
