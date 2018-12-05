//
// Copyright (c) 2016 Easy Editor 
// All Rights Reserved 
//  
//

using UnityEngine;

namespace BlackFire.Unity.Editor.Runtime
{
    /// <summary>
    /// Read only attribute. To prevent from modifying a serialized property in the inspector.
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute
    {}
}
