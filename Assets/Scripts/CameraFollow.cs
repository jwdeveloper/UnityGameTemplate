using System;
using api.events;
using api.injection;
using scriptable;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraTargetEvent : GameEvent
{
    public Camera Camera { get; set; }
    public Transform LastTarget { get; set; }
    public Transform NewTarget { get; set; }
}

public class CameraFollow : BaseGameObject
{
    [Inject] private Camera _camera;

    [Inject] private EventInvoker _eventInvoker;

    [SerializeField] private Transform _target;

    [SerializeField] private CameraSettings _cameraSettings;

    public Transform Target
    {
        get => _target;
        set
        {
            var @event = new CameraTargetEvent
            {
                LastTarget = _target,
                NewTarget = value,
                Camera = _camera
            };
            if (!_eventInvoker.InvokeEvent(@event))
            {
                return;
            }

            _target = value;
        }
    }


    void FixedUpdate()
    {
        if (_target is null)
        {
            return;
        }
        var desiredPosition = _target.position + _cameraSettings.Offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _cameraSettings.Speed);
        _camera.transform.position = smoothedPosition;
        _camera.transform.LookAt(_target);
    }
}