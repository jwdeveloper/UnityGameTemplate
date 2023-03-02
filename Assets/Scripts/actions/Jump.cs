using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace.actions
{
    public class Jump : IAction
    {
        public async Task Handle(GameObject gameObject, CancellationToken ctx)
        {
            for (var i = 0; i < 10; i++)
            {
                gameObject.transform.position += Vector3.up;
                await Task.Delay(10, ctx);
                Debug.Log("JUMPING "+i);
            }
        }
    }
}