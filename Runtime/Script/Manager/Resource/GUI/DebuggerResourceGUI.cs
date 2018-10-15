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
    public sealed class DebuggerResourceGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 5;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Resource";
            }
        }



        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }

        public void OnModuleGUI()
        {
            if (null==App.Resource) return;

            GUILayout.Box("Ref Count:".HexColor("green"),GUILayout.ExpandWidth(false));

            if(0<App.Resource.AssetAgencyCount)
                BlackFireGUI.BoxVerticalLayout(()=> {
                    BlackFireGUI.ScrollView("ResourceRefCountScrollView",id=> {

                        App.Resource.ForeachAssetAgency(current => {
                            var assetAgency = current.Value;
                            BlackFireGUI.HorizontalLayout(() => {
                                BlackFireGUI.DrawItem(
                                    string.Format("Path:{0}   ", assetAgency.AssetPath.HexColor("yellow") ),
                                    string.Format("RefCount:{4}   AcquireCount:{0}   RestoreCount:{1}   Type:{3}   HashCode:{2}", assetAgency.AcquireCount.HexColor("yellow"), assetAgency.RestoreCount.HexColor("yellow"), assetAgency.GetHashCode().ToString().HexColor("yellow"), assetAgency.AssetType.ToString().HexColor("yellow"), assetAgency.RefCount.ToString().HexColor("yellow")));
                            });
                        });

                    },GUILayout.ExpandHeight(false));

                });

        }

        public void OnDestroy()
        {
           
        }
    }
}
