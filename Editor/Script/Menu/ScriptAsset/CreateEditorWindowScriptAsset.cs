/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEditor;

namespace BlackFire.Unity.Editor
{
    public class CreateEditorWindowScriptAsset : EndNameEditActionBase
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            UnityEngine.Object obj = CreateScriptAssetFromTemplate(pathName, resourceFile);
            ProjectWindowUtil.ShowCreatedAsset(obj);
        }
    }
}
