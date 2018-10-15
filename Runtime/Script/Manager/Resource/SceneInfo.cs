/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine.SceneManagement;

namespace BlackFire.Unity
{
    public class SceneInfo
    {
        public SceneInfo(string sceneName, LoadSceneMode loadSceneModle = LoadSceneMode.Additive, bool allowSceneActivation = false)
        {
            SceneName = sceneName;
            LoadSceneModle = loadSceneModle;
            AllowSceneActivation = allowSceneActivation;
        }

        public string SceneName { get; private set; }
        public LoadSceneMode LoadSceneModle { get; private set; }
        public bool AllowSceneActivation { get; private set; }
    }
}
