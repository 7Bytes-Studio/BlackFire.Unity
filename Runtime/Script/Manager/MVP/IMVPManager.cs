/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using BlackFire.Unity.Pattern;

namespace BlackFire.Unity
{
    public interface IMVPManager:IManager
    {
        void BindVP(Type view, IEnumerable<Type> presenters);
        void BindMP(Type model, IEnumerable<Type> presenters);
        void UnBind(Type viewOrmodelOrpresenter);
        Pattern.ModelBase AcquireModel(Type model);
        ViewBase AcquireView(Type view);
        PresenterBase AcquirePresenter(Type presenter);
    }
}