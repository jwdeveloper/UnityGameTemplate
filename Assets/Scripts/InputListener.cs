using System;
using api.events;
using api.injection;
using events;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class InputListener : BaseGameObject
    {
        [Inject] private EventInvoker _eventInvoker;

        public Transform target;
        public bool IsActive { get; set; } = true;

        public float Speed = 4;

        private void OnEnable()
        {
            _eventInvoker.OnEvent<events.InputEvent>(OnInput);
        }

        [EventListener]
        private void OnInput(events.InputEvent @event)
        {
            Debug.Log("Move event" + @event.Direction);
            if (!IsActive)
            {
                return;
            }
            switch (@event.Direction)
            {
                case Direction.Right:
                    target.position -= transform.forward * Speed * Time.deltaTime;
                    break;
                case Direction.Left:
                    target.position += transform.forward * Speed * Time.deltaTime;
                    break;
                case Direction.Down:
                    target.position -= transform.right * Speed * Time.deltaTime;
                    break;
                case Direction.Up:
                    target.position += transform.right * Speed * Time.deltaTime;
                    break;
            }
        }
    }
}