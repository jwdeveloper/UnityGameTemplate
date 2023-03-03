using System;
using UnityEngine;

namespace api.injection
{
    [AttributeUsage(AttributeTargets.Field)]
    public class Inject : Attribute
    {
        
        private readonly InjectionType _injectionType;

        public InjectionType InjectionType => _injectionType;

        public Inject(InjectionType name = InjectionType.FindObject)
        {
            this._injectionType = _injectionType;
        }
    }


    public enum InjectionType
    {
        FindObject, FindComponent, CreateComponent, CreateObject
    }
}