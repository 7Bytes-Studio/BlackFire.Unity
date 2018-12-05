//
// Copyright (c) 2016 Easy Editor 
// All Rights Reserved 
//  
//

using UEObject = UnityEngine.Object;
using System;

namespace BlackFire.Unity.Editor
{
    /// <summary>
    /// Render some custom editor code.
    /// </summary>
	public class CustomRenderer : InspectorItemRenderer {

        public override void Render(Action preRender = null)
        {
            base.Render(preRender);
			entityInfo.methodInfo.Invoke(entityInfo.caller, null);
        }

	}
}