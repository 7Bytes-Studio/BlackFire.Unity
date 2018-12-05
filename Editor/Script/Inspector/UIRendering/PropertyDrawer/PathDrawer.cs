//
// Copyright (c) 2016 Easy Editor 
// All Rights Reserved 
//  
//

using BlackFire.Unity.Editor.Runtime;
using UnityEditor;
using UnityEngine;
using UEObject = UnityEngine.Object;

namespace BlackFire.Unity.Editor
{
    /// <summary>
    /// Dropping an asset on this string property will assign the path of the asset to this string.
    /// </summary>
    [CustomPropertyDrawer(typeof(PathAttribute))]
    public class PathDrawer : PropertyDrawer 
    {
        string temporaryAssetPath = "";
        string assetPath = "";
        bool pathChecked = false;

        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
        {
            if(UnityEngine.Event.current.type == EventType.DragUpdated)
            {
                if(!pathChecked)
                {
                    foreach(UEObject obj in DragAndDrop.objectReferences)
                    {
                        if(!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(obj)))
                        {
                            temporaryAssetPath = AssetDatabase.GetAssetPath(obj);
                            break;
                        }
                    }

                    pathChecked = true;
                }
            }

            if(UnityEngine.Event.current.type == EventType.DragExited)
            {
                if(position.Contains(UnityEngine.Event.current.mousePosition))
                {
                    assetPath = temporaryAssetPath;
                }

                pathChecked = false;
            }

            if(!string.IsNullOrEmpty(assetPath))
            {
                property.stringValue = assetPath;
            }

            EditorGUI.PropertyField(position, property);
        }
    }
}