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
using BlackFire.Unity.Editor.Runtime;
using UnityEngine;

namespace CatEditor
{
    
    public class UnitTest:UnitTestBase
    {
        public int public_SubInt;
        private int private_SubInt;
        private static int private_static_SubInt;
        
        
        public int public_SubInt_P { get; set; }
        private int private_SubInt_P { get; set; }
        private static int private_static_SubInt_P { get; set; }
        
        
        private void Start()
        {
           var ro = new ReflectObject(this);
        }
    }
    
    [RequireComponent(typeof(Transform))]
    [Groups("...")]
    public class UnitTestBase:MonoBehaviour
    {
        public int public_BaseInt;
        private int private_BaseInt;
        private static int private_static_BaseInt;


        public int public_BaseInt_P { get; set; }
        private int private_BaseInt_P { get; set; }
        private static int private_static_BaseInt_P { get; set; }
        
        
        private void Start()
        {
            var ro = new ReflectObject(this.GetType());
        }
    }



}