/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using BlackFire.Unity.Editor.Runtime;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 资产(形体)。
    /// </summary>
    public sealed partial class Asset
    {

//        [BeginHorizontal]
//        [Inspector(group = "Renderer",rendererType = "ButtonRenderer",order = 1)]
//        private void Record()
//        {
//            var renderers = GetComponentsInChildren<Renderer>(true);
//            if (null == renderers || 0 == renderers.Length) return;
//            RendererInfos.Clear();
//            foreach (var renderer in renderers)
//            {
//                var info = new RendererInfo()
//                {
//                    Name = renderer.name,
//                    Renderer = renderer,
//                };
//                foreach (var mat in renderer.materials)
//                {
//                    info.Shaders.Add(mat.shader);
//                }
//                RendererInfos.Add(info);
//            }
//        }
//        [EndHorizontal]
//        [Inspector(group = "Renderer",rendererType = "ButtonRenderer",order = 2)]
//        private void Restore()
//        {
//            foreach (var rendererInfo in RendererInfos)
//            {
//                for (int i = 0; i < rendererInfo.Renderer.materials.Length; i++)
//                {
//                    rendererInfo.Renderer.materials[i].shader = rendererInfo.Shaders[i];
//                }
//            }
//        }
//        
//        [Inspector(group = "Renderer",order = 3)]
//        public List<RendererInfo> RendererInfos = new List<RendererInfo>();
//        
//        [Serializable] public sealed class RendererInfo
//        {
//            [ReadOnly] public string Name;
//
//            [ReadOnly] public Renderer Renderer;
//            
//            [ReadOnly] public List<Shader> Shaders = new List<Shader>(); //一个材质 对应一个shader。
//        }
        
        
    }
}