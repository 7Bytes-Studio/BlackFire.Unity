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
    public static partial class Utility
    {

        public static class Game
        {

            #region Fps

            private static float s_FpsMeasuringDelta = 1f;
            private static float s_TimePassed = 0.0f;
            private static int s_FrameCount = 0;
            private static float s_FPS = 0.0f;

            public static float Fps()
            {
                s_FrameCount = s_FrameCount + 1;
                s_TimePassed = s_TimePassed + Time.unscaledDeltaTime;

                if (s_TimePassed > s_FpsMeasuringDelta)
                {
                    s_FPS = s_FrameCount / s_TimePassed;

                    s_TimePassed = 0.0f;
                    s_FrameCount = 0;
                }
                return s_FPS;
            }

            #endregion

        }



    }
}
