using System;
using System.Collections;
using System.Collections.Generic;
using api.events;
using api.injection;
using events;
using UnityEngine;


public class InputHandler : BaseGameObject
{

    [Inject]
    private EventInvoker _eventInvoker;

    void Update()
    {
        var direction = Direction.None;
        if (Input.GetKey(KeyCode.A))
        {
            direction = Direction.Left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Direction.Right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = Direction.Up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Direction.Down;
        }
        
        if(direction == Direction.None)
            return;
        
        _eventInvoker.InvokeEvent(new InputEvent
        {
            Direction = direction
        });
    }
}
