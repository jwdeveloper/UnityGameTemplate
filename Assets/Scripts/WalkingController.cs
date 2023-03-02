using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Action = DefaultNamespace.Action;

public class WalkingController : MonoBehaviour
{

    private IActionHandler _actionsHandler;


    private void Awake()
    {
        
    }

    void Start()
    {
        _actionsHandler = FindObjectOfType<ActionsHandler>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            _actionsHandler.QueueAction(gameObject, Action.WALKING_LEFT);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _actionsHandler.QueueAction(gameObject, Action.WALKING_RIGHT);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _actionsHandler.QueueAction(gameObject, Action.JUMP);
        }
    }
}
