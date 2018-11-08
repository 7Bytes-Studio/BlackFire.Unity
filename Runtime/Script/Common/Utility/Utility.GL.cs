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
        /// <summary>
        /// GL辅助类。
        /// </summary>
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
            
            public static Vector3[] Line2DPointsConvert(Vector3 firstPoint, Vector3 secondPoint, float lineWidth)
            {
                Vector3 normal = Quaternion.Euler(0f,0f,90f) * (secondPoint - firstPoint).normalized;
                var threshold = normal * lineWidth;
                Vector3[] points = new Vector3[4];
                points[0] = firstPoint  - threshold;
                points[1] = firstPoint  + threshold;
                points[2] = secondPoint + threshold;
                points[3] = secondPoint - threshold;
                return points;
            }
    
            public static void DrawLine2D(Vector3 firstPoint,Vector3 secondPoint,float lineWidth,Material material)
            {
                if (null == material) { throw new System.NullReferenceException("材质不能为空!"); }
    
                lineWidth = lineWidth/100f;
                UnityEngine.GL.PushMatrix();
                material.SetPass(0);
                UnityEngine.GL.LoadOrtho();
                UnityEngine.GL.Begin(UnityEngine.GL.QUADS);
                var points = Line2DPointsConvert(firstPoint,secondPoint,lineWidth);
                for (int i = 0; i < points.Length; i++)
                {
                    UnityEngine.GL.Vertex(points[i]);
                }
                UnityEngine.GL.End();
                UnityEngine.GL.PopMatrix();
      
            }
    
            public static void DrawLine2D(Vector3 firstPoint, Vector3 secondPoint, float lineWidth,Color color)
            {
                lineWidth = lineWidth / 100f;
                UnityEngine.GL.PushMatrix();
                UnityEngine.GL.Begin(UnityEngine.GL.QUADS);
                UnityEngine.GL.Color(color);
                var points = Line2DPointsConvert(firstPoint, secondPoint,lineWidth);
                for (int i = 0; i < points.Length; i++)
                {
                    UnityEngine.GL.Vertex(points[i]);
                }
                UnityEngine.GL.End();
                UnityEngine.GL.PopMatrix();
    
            }
    
            public static void DrawLine(Vector3 firstPoint, Vector3 secondPoint,Material material)
            {
                if (null == material) { throw new System.NullReferenceException("材质不能为空!"); }
    
                UnityEngine.GL.PushMatrix();
                material.SetPass(0);
                UnityEngine.GL.LoadOrtho();
                UnityEngine.GL.Begin(UnityEngine.GL.LINES);
                UnityEngine.GL.Vertex(firstPoint);
                UnityEngine.GL.Vertex(secondPoint);
                UnityEngine.GL.End();
                UnityEngine.GL.PopMatrix();
    
            }
    
            public static void DrawLines(Vector3[] vertexs, Material material)
            {
                if (null == material) { throw new System.NullReferenceException("材质不能为空!"); }
    
                UnityEngine.GL.PushMatrix();
                material.SetPass(0);
                UnityEngine.GL.LoadOrtho();
                UnityEngine.GL.Begin(UnityEngine.GL.LINES);
                for (int i = 0; i < vertexs.Length; i++)
                {
                    UnityEngine.GL.Vertex(vertexs[i]);
                    
                }
                UnityEngine.GL.End();
                UnityEngine.GL.PopMatrix();
    
            }
    
            public static void DrawLinesStrip(Vector3[] vertexs, Material material)
            {
                if (null == material) { throw new System.NullReferenceException("材质不能为空!"); }
    
                UnityEngine.GL.PushMatrix();
                material.SetPass(0);
                UnityEngine.GL.LoadOrtho();
                UnityEngine.GL.Begin(UnityEngine.GL.LINE_STRIP);
                for (int i = 0; i < vertexs.Length; i++)
                {
                    UnityEngine.GL.Vertex(vertexs[i]);
    
                }
                UnityEngine.GL.End();
                UnityEngine.GL.PopMatrix();
    
            }
    
            public static void DrawLineStrip(Vector3 firstPoint, Vector3 secondPoint,Material material)
            {
                if (null == material) { throw new System.NullReferenceException("材质不能为空!"); }
    
                UnityEngine.GL.PushMatrix();
                material.SetPass(0);
                UnityEngine.GL.LoadOrtho();
                UnityEngine.GL.Begin(UnityEngine.GL.LINE_STRIP);
                UnityEngine.GL.Vertex(firstPoint);
                UnityEngine.GL.Vertex(secondPoint);
                UnityEngine.GL.End();
                UnityEngine.GL.PopMatrix();
    
            }
            
            
        }

    }
}
