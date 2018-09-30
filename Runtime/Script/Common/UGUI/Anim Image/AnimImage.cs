//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BlackFire.Unity
{
    [AddComponentMenu("BlackFire/UI/Anim Image", 11)]
    public sealed class AnimImage : MaskableGraphic
    {
        public AnimImage()
        {
            useLegacyMeshGeneration = false;
        }
        
        [SerializeField] private int m_Cols;
        public int Cols
        {
            get { return m_Cols; }
            set { m_Cols = value; }
        }
        
        [SerializeField] private int m_Rows;
        public int Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }


        public float Width
        {
            get
            {
                if (0==m_Cols)
                {
                    return 1f;
                }
                return 1f / m_Cols;
            }
        }
        
        public float Height
        {
            get
            {
                if (0==m_Rows)
                {
                    return 1f;
                }
                return 1f / m_Rows;
            }
        }
        
        


        [SerializeField] private Vector2 m_UV0 = new Vector2(0.0f,0.0f);
        [SerializeField] private Vector2 m_UV1 = new Vector2(0.0f,1.0f);
        [SerializeField] private Vector2 m_UV2 = new Vector2(1.0f,1.0f);
        [SerializeField] private Vector2 m_UV3 = new Vector2(1.0f,0.0f);
        
        
        private List<UIUV> m_UIUVList = new List<UIUV>();

        [SerializeField] private Texture m_Texture;
        
        protected override void OnValidate()
        {
            base.OnValidate();
            Init_UIUV();
        }

        protected override void Awake()
        {
            base.Awake();
            Init_UIUV();
        }

        private void Init_UIUV()
        {
            if (0==m_Rows || 0==m_Cols) return;
            
            var x = Width;
            var y = Height;
            
            m_UIUVList.Clear();
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    m_UIUVList.Add(new UIUV()
                    {
                        UV0 = new Vector2(j*x,(m_Rows-i-1)*y),
                        UV1 = new Vector2(j*x,(m_Rows-i)*y),
                        UV2 = new Vector2((j+1)*x,(m_Rows-i)*y),
                        UV3 = new Vector2((j+1)*x,(m_Rows-i-1)*y)
                    });                   
                }
            }
        }

      
        [SerializeField] [Range(0,300)] private float m_Fps = 60f;
        public float Fps
        {
            get { return m_Fps; }
            set { m_Fps = value; }
        }
        
        private float m_Tmp = 0f;
        private void Update()
        {
            if (0!=m_UIUVList.Count && 0!=m_Fps)
            {
                if ((m_Tmp+=Time.deltaTime)>=(1f/m_Fps))
                {
                    SetAllDirty();
                    m_Tmp = 0f;
                }
            }            
        }
        
        
        
        [SerializeField]
        private Sprite m_Sprite;
        
        public Sprite Sprite
        {
            get { return m_Sprite; }
            set { m_Sprite = value; }
        }
        
        public override Texture mainTexture
        {
            get
            {
                if (Sprite == null)
                {
                    if (material != null && material.mainTexture != null)
                    {
                        return material.mainTexture;
                    }
                    return s_WhiteTexture;
                }

                return Sprite.texture;
            }
        }
                
        public float pixelsPerUnit
        {
            get
            {
                float num1 = 100f;
                if (null!=Sprite)
                    num1 = Sprite.pixelsPerUnit;
                float num2 = 100f;
                if (null!=canvas)
                    num2 = canvas.referencePixelsPerUnit;
                return num1 / num2;
            }
        }
                
        public override void SetNativeSize()
        {
            if (null==m_Sprite) return;
            float x = (m_Sprite.rect.width / pixelsPerUnit)*Width;
            float y = (m_Sprite.rect.height / pixelsPerUnit)*Height;
            rectTransform.anchorMax = rectTransform.anchorMin;
            rectTransform.sizeDelta = new Vector2(x, y);
            SetAllDirty();
        }

        private int m_Index = 0;
        [SerializeField] private int m_Skip = 0;
        public int Skip
        {
            get { return m_Skip; }
            set { m_Skip = value; }
        }

        [SerializeField] private bool m_Loop = true;
        private bool m_HasFinishedFlag = false;
        
        [Serializable] public class HasFinishedUnityEvent:UnityEvent<object,object>
        {
            
        }

        [SerializeField] private HasFinishedUnityEvent m_HasFinished = null;

        public HasFinishedUnityEvent HasFinished
        {
            get { return m_HasFinished; }
            set { m_HasFinished = value; }
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {

            if (0==m_UIUVList.Count)
            {
                base.OnPopulateMesh(toFill);   
                return;
            }
            
            UIUV uiuv = null;
            Rect pixelAdjustedRect = this.GetPixelAdjustedRect();
            Vector4 vector4 = new Vector4(pixelAdjustedRect.x, pixelAdjustedRect.y, pixelAdjustedRect.x + pixelAdjustedRect.width, pixelAdjustedRect.y + pixelAdjustedRect.height);
            Color32 color = (Color32) this.color;
            toFill.Clear();

#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
                uiuv = m_UIUVList[0];
            }
#endif

            if (null==uiuv)
            {

                if (!m_HasFinishedFlag)
                {
                    var i = m_Index++ % (m_UIUVList.Count-m_Skip);
                    if (1 < m_Index && 0 == i)
                    {
                        m_Index = 0;
                        if (!m_Loop)
                        {
                            m_HasFinishedFlag = true;
                            if (null!=m_HasFinished)
                            {
                                m_HasFinished.Invoke(this, null);
                            }
                        }
                    }
                    uiuv = m_UIUVList[i];
                }
                else
                {
                    uiuv = m_UIUVList[m_UIUVList.Count-m_Skip-1];
                }
            }
            
            toFill.AddVert(new Vector3(vector4.x, vector4.y), color, uiuv.UV0);
            toFill.AddVert(new Vector3(vector4.x, vector4.w), color, uiuv.UV1);
            toFill.AddVert(new Vector3(vector4.z, vector4.w), color, uiuv.UV2);
            toFill.AddVert(new Vector3(vector4.z, vector4.y), color, uiuv.UV3);
            
            toFill.AddTriangle(0, 1, 2);
            toFill.AddTriangle(2, 3, 0);
            
        }
    }


    public sealed class UIUV
    {
        public Vector2 UV0;
        public Vector2 UV1;
        public Vector2 UV2;
        public Vector2 UV3;

        public Vector2[] ToUV()
        {
            return new Vector2[]
            {
                UV0,
                UV1,
                UV2,
                UV3,
            };
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", UV0, UV1, UV2, UV3);
        }
    }

    
    
    

} 