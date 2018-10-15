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
	public static class StringExtension
    {
        public static string HexColor(this string text,string hexColor)
        {
            return string.Format("<color={0}>{1}</color>", hexColor, text);
        }

        public static string HexColor(this int intText, string hexColor)
        {
            return string.Format("<color={0}>{1}</color>", hexColor, intText);
        }

    }
}
