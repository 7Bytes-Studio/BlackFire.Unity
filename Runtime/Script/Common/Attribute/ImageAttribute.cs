//
// Copyright (c) 2016 Easy Editor 
// All Rights Reserved 
//  
//

using UnityEngine;

namespace BlackFire.Unity.Editor.Runtime
{
    public enum ImageAlignement
    {
        Left,
        Center,
        Right
    }

    public class ImageAttribute : PropertyAttribute
    {
        public ImageAlignement alignement = ImageAlignement.Center;
        public float size = 0f;
    }
}
