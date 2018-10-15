/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 资源管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Manager/Resource")]
    public sealed partial class ResourceManager : ManagerBase ,IResourceManager
	{
        protected override void OnStart()
        {
            base.OnStart();
            Init_Resource();
            Init_AssetsBundle();
            Init_Scene();
            Init_Agency();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Update_Resource();
            Update_AssetsBundle();
            Update_Scene();
            Update_Agency();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            Destroy_Resource();
            Destroy_AssetsBundle();
            Destroy_Scene();
            Destroy_Agency();
        }
    }
}
