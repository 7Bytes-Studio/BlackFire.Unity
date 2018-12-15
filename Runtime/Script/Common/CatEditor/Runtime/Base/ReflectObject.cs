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
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

namespace CatEditor
{
    /// <summary>
    /// 反射对象。
    /// </summary>
    public class ReflectObject
    {
        public ReflectObject(object target)
        {
            this.Target = target;
            this.Type = target.GetType();
            
            //FieldInfos = ReflectFields();
            //PropertyInfos = ReflectProperties();
            MethodInfos = ReflectMethodInfos();
        }

        public object Target;
        public Type Type;

        public IEnumerable<FieldInfo> FieldInfos;
        public IEnumerable<PropertyInfo> PropertyInfos;
        public IEnumerable<MethodInfo> MethodInfos;

        
        protected virtual IEnumerable<FieldInfo> ReflectFields()
        {
            var list = new List<FieldInfo>();
            var bindingflags = BindingFlags.Instance  |
                               BindingFlags.NonPublic |
                               BindingFlags.Public    |
                               BindingFlags.Static    |
                               BindingFlags.DeclaredOnly;   
            
            var currentType = this.Type;
            while (null!=currentType&&currentType!=typeof(MonoBehaviour))
            {
                var fieldInfos = currentType.GetFields(bindingflags);
                list.AddRange(fieldInfos);
                currentType = currentType.BaseType;
            }

            foreach (var item in list)
            {
                Debug.Log(item);
            }
            
            return list;
        }

        
        protected virtual IEnumerable<PropertyInfo> ReflectProperties()
        {
            var list = new List<PropertyInfo>();
            var bindingflags = BindingFlags.Instance  |
                               BindingFlags.NonPublic |
                               BindingFlags.Public    |
                               BindingFlags.Static    |
                               BindingFlags.DeclaredOnly;   
            
            var currentType = this.Type;
            while (null!=currentType&&currentType!=typeof(MonoBehaviour))
            {
                var propertyInfos = currentType.GetProperties(bindingflags);
                list.AddRange(propertyInfos);
                currentType = currentType.BaseType;
            }

            foreach (var item in list)
            {
                Debug.Log(item);
            }
            
            return list;
        }
        
        
        protected virtual IEnumerable<MethodInfo> ReflectMethodInfos()
        {
            var list = new List<MethodInfo>();
            var bindingflags = BindingFlags.Instance  |
                               BindingFlags.NonPublic |
                               BindingFlags.Public    |
                               BindingFlags.Static    |
                               BindingFlags.DeclaredOnly;   
            
            var currentType = this.Type;
            while (null!=currentType&&currentType!=typeof(MonoBehaviour))
            {
                var methodInfos = currentType.GetMethods(bindingflags);
                list.AddRange(methodInfos);
                currentType = currentType.BaseType;
            }

            foreach (var item in list)
            {
                Debug.Log(item);
            }
            
            return list;
        }
        
        
        
        protected virtual void ReflectAttributes()
        {
            var list = new List<Attribute>();
            var attributes = Attribute.GetCustomAttributes(this.Type,true);
            list.AddRange(attributes);
            
            foreach (var attribute in attributes)
            {

            }
        }

    }
}