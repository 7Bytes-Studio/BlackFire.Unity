/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        /// <summary>
        /// 时间帮助类。
        /// </summary>
        public static class Time
        {
            private static StandardTime s_CachedStandardTime = new StandardTime();
    
            public static StandardTime Convert(int seconds)
            {
                s_CachedStandardTime.Set(0,0,0);
                s_CachedStandardTime.SetHour( seconds/3600 % 24);
                s_CachedStandardTime.SetMinute( seconds/60 % 60);
                s_CachedStandardTime.SetSecond( seconds % 3600 );
                return s_CachedStandardTime;
            }
        }
    }

    [System.Serializable]
    public struct StandardTime
    {

        public StandardTime(int hour, int minute, int second)
        {
            m_Hour = hour;
            m_Minute = minute;
            m_Second = second;
        }

        [UnityEngine.SerializeField]
        private int m_Hour;
        [UnityEngine.SerializeField]
        private int m_Minute;
        [UnityEngine.SerializeField]
        private int m_Second;

        public void Set(int hour, int minute, int second)
        {
            m_Hour = hour;
            m_Minute = minute;
            m_Second = second;
        }

        public void SetHour(int hour)
        {
            Hour = hour;
        }

        public void SetMinute(int minute)
        {
            Minute = minute;
        }

        public void SetSecond(int second)
        {
            Second = second;
        }


        public int Hour   { get { return m_Hour; }   private set { m_Hour = value %= 24; } }
        public int Minute { get { return m_Minute; } private set { m_Minute = value %= 60; } }
        public int Second { get { return m_Second; } private set { m_Second = value %= 60; } }


        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}",Hour,Minute,Second);
        }
    }
}
