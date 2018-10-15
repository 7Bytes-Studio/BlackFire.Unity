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
    public sealed class DebuggerIteratorGUI : IDebuggerModuleGUI
    {


        public int Priority
        {
            get
            {
                return 11;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Iterator";
            }
        }


        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }


        public void OnModuleGUI()
        {


                BlackFireGUI.VerticalLayout(() =>
                {

                    BlackFireGUI.BoxHorizontalLayout(() =>
                    {

                        BlackFireGUI.ScrollView("Iterator/IteratorNames", id =>
                        {
                            foreach (var name in BlackFire.Iterator.AllIteratorNames)
                            {
                                GUILayout.Label(string.Format("{0} : {1}","Name".HexColor("yellow"),name.HexColor("green")));
                            }
                        });
                    });

                });

        }

        public void OnDestroy()
        {
            
        }




    }
}
