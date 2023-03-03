using System.Collections.Generic;
using api.events;
using api.injection;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : BaseGameObject
{
    [Inject] 
    private EventInvoker _eventInvoker;

    [Inject(InjectionType.FindComponent)]
    private CharacterController _characterController;

    [Inject(InjectionType.FindComponent)]
    private Rigidbody _rigidbody;

    [Inject]
    private UIDocument _gui;
}