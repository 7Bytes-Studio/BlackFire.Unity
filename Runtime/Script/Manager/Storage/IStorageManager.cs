/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.DB;

namespace BlackFire.Unity
{
    public interface IStorageManager:IManager
    {
        IConnection CreateConnection(string connectionAlias, string databasePath);
        IConnection AcquireConnection(string connectionAlias);
        void CloseConnection(string connectionAlias);
    }
}