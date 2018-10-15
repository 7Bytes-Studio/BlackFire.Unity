/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.DB;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 存储管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Manager/Storage")]
    public sealed partial class StorageManager : ManagerBase, IStorageManager
    {
        private ISqliteModule m_SqliteModule = null;

        protected override void OnStart()
        {
            base.OnStart();
            InitModules();
        }

        private void InitModules()
        {
            RegisterModule<ISqliteModule>();
            m_SqliteModule = GetModule<ISqliteModule>();
            m_SqliteModule.ConnectionFactory = (alias, path) => new DefaultSqliteConnection(alias,new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create));
        }
    }
}