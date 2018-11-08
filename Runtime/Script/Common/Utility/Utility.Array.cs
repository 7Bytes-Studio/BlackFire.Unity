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
        /// 数组辅助类。
        /// </summary>
        public static class Array
        {
            
            /// <summary>
            /// 切数组。
            /// </summary>
            /// <param name="array">源数组。</param>
            /// <param name="startIndex">从哪里开始切。</param>
            /// <param name="endIndex">从哪里结束切。</param>
            /// <typeparam name="T">数组元素类型。</typeparam>
            /// <returns>切后数组。</returns>
            public static T[] Slice<T>(T[] array, int startIndex, int endIndex)
            {
                if (0 > (endIndex - startIndex)) return null; //输入长度不对，创建数组会出错
                T[] t_NewArray = new T[endIndex- startIndex];
                if (null != array)
                {
                    if (array.Length > startIndex && array.Length > endIndex)
                    {
                        for (int i = 0; i < t_NewArray.Length; i++)
                        {
                            t_NewArray[i] = array[ startIndex>= endIndex ? endIndex: startIndex++];
                        }
                        return t_NewArray;
                    }
                    else
                    {
                        //数组输入的长度不对，已经超越了原有的长度
                        return null;
                    }

                }
                else
                {
                    //数组为空
                    return null;
                }
            }

            /// <summary>
            /// 合并数组。
            /// </summary>
            /// <param name="firstArray">第一个数组。</param>
            /// <param name="firstArrayStartIndex">第一个数组起始索引。</param>
            /// <param name="firstArrayEndIndex">第一个数组结束索引。</param>
            /// <param name="secondArray">第二个数组。</param>
            /// <param name="secondArrayStartIndex">第二个属猪的起始索引。</param>
            /// <param name="secondArrayEndIndex">第二个数组的结束索引。</param>
            /// <typeparam name="T">数组元素类型。</typeparam>
            /// <returns>合并后的数组。</returns>
            public static T[] Merge<T>(T[] firstArray, int firstArrayStartIndex, int firstArrayEndIndex, T[] secondArray, int secondArrayStartIndex, int secondArrayEndIndex)
            {
                if (firstArrayStartIndex >= firstArrayEndIndex) return null;
                else if (secondArrayStartIndex >= secondArrayEndIndex) return null;
                else if (null==firstArray) return null;
                else if (null==secondArray) return null;

                T[] t_NewArray = new T[(firstArrayEndIndex- firstArrayStartIndex)+(secondArrayEndIndex-secondArrayStartIndex)];
                for (int i = 0; i < t_NewArray.Length; i++)
                {
                    if (firstArrayStartIndex < firstArrayEndIndex)
                        t_NewArray[i] = firstArray[firstArrayStartIndex++];
                    else if (secondArrayStartIndex<secondArrayEndIndex)
                        t_NewArray[i] = secondArray[secondArrayStartIndex++];
                }
                return t_NewArray;

            }

            /// <summary>
            /// 合并数组。
            /// </summary>
            /// <param name="firstArray">第一个数组。</param>
            /// <param name="secondArray">第二个数组。</param>
            /// <typeparam name="T">数组元素类型。</typeparam>
            /// <returns>合并后的数组。</returns>
            public static T[] Merge<T>(T[] firstArray,T[] secondArray)
            {
                return Merge<T>(firstArray,0,firstArray.Length,secondArray,0,secondArray.Length);
            }

        }

    }
}
