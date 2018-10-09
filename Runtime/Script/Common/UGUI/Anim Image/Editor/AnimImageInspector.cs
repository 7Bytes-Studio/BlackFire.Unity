//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
	[CustomEditor(typeof(AnimImage), false)]
	public class AnimImageInspector : GraphicEditor
	{
		private SerializedProperty m_SP_Rows;
		private SerializedProperty m_SP_Cols;
		private SerializedProperty m_SP_Sprite;
		private SerializedProperty m_SP_Fps;
		private SerializedProperty m_SP_Start;
		private SerializedProperty m_SP_End;
		private SerializedProperty m_SP_RaycastTarget;
		private SerializedProperty m_SP_Loop;
		private SerializedProperty m_SP_HasFinished;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_SP_Rows = serializedObject.FindProperty("m_Rows");
			m_SP_Cols = serializedObject.FindProperty("m_Cols");
			m_SP_Sprite = serializedObject.FindProperty("m_Sprite");
			m_SP_Fps = serializedObject.FindProperty("m_Fps");
			m_SP_Start = serializedObject.FindProperty("m_Start");
			m_SP_End = serializedObject.FindProperty("m_End");
			m_SP_RaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
			m_SP_Loop = serializedObject.FindProperty("m_Loop");
			m_SP_HasFinished = serializedObject.FindProperty("m_HasFinished");
		}

		public override void OnInspectorGUI()
		{
			var t = (AnimImage) target;
			
			GUILayout.Space(10);

			BlackFireEditorGUI.BoxVerticalLayout(()=>
			{
				EditorGUILayout.PropertyField(m_SP_Sprite);

				if (null != t.Sprite)
				{
					EditorGUILayout.PropertyField(m_SP_Rows);
					EditorGUILayout.PropertyField(m_SP_Cols);
					GUI.color = Color.cyan;
					EditorGUILayout.HelpBox(string.Format("Total {0} frames.",m_SP_Rows.intValue*m_SP_Cols.intValue),MessageType.None);
					GUI.color = Color.white;
					EditorGUILayout.PropertyField(m_SP_Start);
					EditorGUILayout.PropertyField(m_SP_End);
					EditorGUILayout.PropertyField(m_SP_Fps);	
					EditorGUILayout.PropertyField(m_SP_Loop);
				}
				
				EditorGUILayout.PropertyField(m_SP_RaycastTarget);
				
				if (null != t.Sprite)
				{
						BlackFireEditorGUI.HorizontalLayout(() =>
						{
							GUILayout.Space(EditorGUIUtility.labelWidth);
							if (GUILayout.Button("Set Native Size",EditorStyles.miniButton))
							{
								t.SetNativeSize();
								EditorUtility.SetDirty(t);
							}
						});
				}

//				if (null == t.Sprite)
//				{
//					m_SP_Rows.intValue = 0;
//					m_SP_Cols.intValue = 0;
//					m_SP_Skip.intValue = 0;
//					m_SP_Fps.floatValue = 60f;
//				}
				
			});
			
				
			GUILayout.Space(10);
			EditorGUILayout.PropertyField(m_SP_HasFinished);
			
			serializedObject.ApplyModifiedProperties();
		}
		
		
		
	}
}