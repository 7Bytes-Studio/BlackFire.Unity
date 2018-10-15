/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.Pattern;

namespace BlackFire.Unity
{
    public abstract class View : ViewBase,IView
    {

        protected override void OnInit()
        {
            
        }

        protected override void OnUpdate()
        {
            
        }

        protected override void OnDestroy()
        {
            
        }

        protected override IView ViewInterface
        {
            get { return this; }
        }
    }
}