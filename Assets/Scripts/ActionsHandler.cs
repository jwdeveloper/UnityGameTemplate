using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DefaultNamespace.actions;
using UnityEngine;

namespace DefaultNamespace
{
    public class ActionsHandler : MonoBehaviour, IActionHandler
    {
        public bool pause;
        private readonly Queue<NpcActionRequest> _actions;
        private readonly CancellationToken _ctx;


        public ActionsHandler()
        {
            _ctx = new CancellationToken();
            _actions = new Queue<NpcActionRequest>();
            QueueAction(gameObject, Action.JUMP);
        }


        public void QueueAction(GameObject gameObject, Action action)
        {
            _actions.Enqueue(new NpcActionRequest
            {
                _action = action,
                _gameObject = gameObject
            });
        }

        private void Start()
        {
            Task.Factory.StartNew(o => HandleActions(), _ctx);
        }

        private async Task HandleActions()
        {
            while (true)
            {
                await Task.Delay(100, _ctx);
                if (pause)
                {
                    continue;
                }

                Debug.Log("Current tasks: "+_actions.Count);
                while (_actions.TryDequeue(out var actionRequest))
                {
                    Debug.Log("HANDLING TASK: "+actionRequest._action);
                    if (actionRequest._action == Action.WALKING_LEFT)
                    {
                        var walking = new Walking();
                        await walking.Handle(actionRequest._gameObject, _ctx);
                    }
                    
                    if (actionRequest._action == Action.WALKING_RIGHT)
                    {
                        var walking = new WalkingRight();
                        await walking.Handle(actionRequest._gameObject, _ctx);
                    }
                    
                    if (actionRequest._action == Action.JUMP)
                    {
                        var walking = new Jump();
                        await walking.Handle(actionRequest._gameObject, _ctx);
                    }
                }
            }
        }

        private void OnDestroy()
        {
            _ctx.ThrowIfCancellationRequested();
        }
    }


    public class NpcActionRequest
    {
        public GameObject _gameObject;
        public Action _action;
    }
}