﻿//
// Copyright (c) 2016 Easy Editor 
// All Rights Reserved 
//  
//

using UnityEngine;
using UEObject = UnityEngine.Object;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using BlackFire.Unity.Editor.Runtime;

namespace BlackFire.Unity.Editor
{
    public class RendererFinder {

        /// <summary>
        /// Gets the list of fields to render in inspector interface.
        /// </summary>
        /// <param name="target">The targeted object.</param>
        /// <returns></returns>
        public static List<InspectorItemRenderer> GetListOfFields(object target, SerializedObject serializedObject, string targetPath = "")
        {
            List<InspectorItemRenderer> fieldRenderers = new List<InspectorItemRenderer>();
            BindingFlags flags = (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            IEnumerable<FieldInfo> fieldInfos = FieldInfoHelper.GetAllFieldsTillUnityBaseClass(target.GetType(), flags);
            string currentGroup = "";
            
            Type currentType = null;
            IEnumerable<FieldInfo> fieldInfoList = fieldInfos as IList<FieldInfo> ?? fieldInfos.ToList();
            if (fieldInfoList.Any())
            {
                currentType = fieldInfoList.First().DeclaringType;
            }

            foreach (FieldInfo fieldInfo in fieldInfoList)
            {
                InspectorItemRenderer renderer = null;

                if (FieldInfoHelper.IsSerializedInUnity(fieldInfo))
                {
                    string propertyPath = "";
                    if(string.IsNullOrEmpty(targetPath))
                    {
                        propertyPath = fieldInfo.Name;
                    }
                    else
                    {
                        propertyPath = targetPath + "." + fieldInfo.Name;
                    }

                    renderer = InspectorItemRenderer.GetRendererFromFieldInfo(fieldInfo, serializedObject, propertyPath);
                }
                else
                {
                    InspectorAttribute inspectorAttribute = AttributeHelper.GetAttribute<InspectorAttribute> (fieldInfo);

                    if (inspectorAttribute != null && !FieldInfoHelper.IsSerializedInUnity(fieldInfo))
                    {
                        Debug.LogWarning("You assigned the attribute" +
                        " [Inspector] to the field " + fieldInfo.Name + " of object " + target.GetType() + " which is not serialized by Unity. EasyEditor will not render it.");
                    }
                }

                if (renderer != null)
                {
                    if(renderer.entityInfo.fieldInfo.DeclaringType != currentType)
                    {
                        currentGroup = "";
                        currentType = renderer.entityInfo.fieldInfo.DeclaringType;
                    }

                    AssignGroup(renderer, currentGroup);
                    currentGroup = renderer.inspectorAttribute.group;

                    fieldRenderers.Add(renderer);
                }
            }

            return fieldRenderers;
        }

        private static void AssignGroup(InspectorItemRenderer renderer, string currentGroup)
        {
            if(renderer.inspectorAttribute.group == "")
            {
                renderer.inspectorAttribute.group = currentGroup;
            }
        }

        /// <summary>
        /// Gets the list of methods to render in the inspector interface.
        /// </summary>
        /// <param name="caller">The caller.</param>
        /// <returns></returns>
        public static List<InspectorItemRenderer> GetListOfMethods(object caller, SerializedObject serializedObject, string pathToCaller = null)
        {
            List<InspectorItemRenderer> methodRenderers = new List<InspectorItemRenderer>();

            BindingFlags flags = (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            List<MethodInfo> methodInfos = MethodInfoHelper.GetAllMethodsTillUnityBaseClass(caller.GetType(), flags);

            foreach (MethodInfo methodInfo in methodInfos)
            {
                InspectorItemRenderer renderer = InspectorItemRenderer.GetRendererFromMethodInfo(methodInfo, caller, serializedObject, pathToCaller);
                
                if (renderer != null)
                {
                    methodRenderers.Add(renderer);
                }
            }

            return methodRenderers;
        }
    }
}