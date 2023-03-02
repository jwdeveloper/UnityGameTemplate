using System;
using System.Collections.Generic;
using api.events;
using api.injection;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace DefaultNamespace
{
    public class Player : BaseGameObject
    {
        [SerializeField] [Injection(InjectionType.FindObject)]
        private List<Camera> camera;

        [SerializeField] [Injection(InjectionType.FindObject)]
        private EventInvoker eventInvoker;


        private async void OnEnable()
        {
            eventInvoker.OnEvent<JumpEvent>(e =>
            {
                Debug.Log("Hello world");
                e.Cancel = true;
            });


            var result = eventInvoker.InvokeEvent(new JumpEvent
            {
                Height = 12,
                Player = this,
            });
            
            
        }


        private async void test()
        {
            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(100); //Task.Delay input is in milliseconds
                gameObject.transform.position += new Vector3(10, 0, 0);
                Debug.Log(i);
            }
        }
    }
}