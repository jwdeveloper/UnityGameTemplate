using System;
using UnityEngine;

namespace api.injection
{
    [AttributeUsage(AttributeTargets.Field)]
    public class Injection : Attribute
    {
        
        private readonly InjectionType _injectionType;

        public InjectionType InjectionType => _injectionType;

        public Injection(InjectionType name)
        {
            this._injectionType = _injectionType;
        }
    }


    public enum InjectionType
    {
        FindObject, FindComponent, CreateComponent, CreateObject
    }
}