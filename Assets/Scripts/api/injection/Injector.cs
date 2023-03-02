using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

namespace api.injection
{
    public class Injector
    {
        public static void Inject(MonoBehaviour target)
        {
            var clazz = target.GetType();
            var fields = clazz.GetFields(BindingFlags.NonPublic |
                                         BindingFlags.Instance);
            foreach (var field in fields)
            {
                if (!field.HasAttribute(typeof(Injection)))
                {
                    continue;
                }

                var fieldType = field.GetAccessorType();
                var attribute = field.GetAttribute<Injection>();
                object value = null;
                if (IsList(fieldType))
                {
                    value = findManyObjects(attribute.InjectionType, target, fieldType);
                }
                else
                {
                    value = findOneObject(attribute.InjectionType, target, fieldType);
                }

                field.SetValue(target, value);
            }
        }

        private static object findOneObject(InjectionType injectionType, MonoBehaviour target, Type fieldType)
        {
            switch (injectionType)
            {
                case InjectionType.FindComponent:
                {
                    return target.GetComponent(fieldType);
                }
                case InjectionType.FindObject:
                {
                    return GameObject.FindObjectOfType(fieldType);
                }
                case InjectionType.CreateComponent:
                {
                    return target.gameObject.AddComponent(fieldType);
                }
            }

            throw new NotImplementedException();
        }

        private static object findManyObjects(InjectionType injectionType, MonoBehaviour target, Type fieldType)
        {
            var getListType = fieldType.GetGenericArguments()[0];
            object arrayResult = null;
            switch (injectionType)
            {
                case InjectionType.FindComponent:
                {
                    arrayResult = target.GetComponents(getListType);
                    break;
                }
                case InjectionType.FindObject:
                {
                    arrayResult = GameObject.FindObjectsOfType(getListType);
                    break;
                }
                case InjectionType.CreateComponent:
                {
                    throw new NotImplementedException($" {{injectionType}} Not implemented for lists");
                }
            }


        

            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(getListType);
            var instance = Activator.CreateInstance(constructedListType);

          
            var addAllMethod = instance.GetType().GetMethod("AddRange");
            addAllMethod.Invoke(instance, new[]{arrayResult});
            return instance;
        }

        public static bool IsList(Type interfaceType)
        {
            if(interfaceType.GetGenericArguments().Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}