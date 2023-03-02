using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace.actions
{
    public interface IAction
    {
        public  Task Handle(GameObject gameObject, CancellationToken ctx);
    }
}