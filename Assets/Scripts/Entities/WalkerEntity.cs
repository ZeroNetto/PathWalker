using Components;
using UnityEngine;
using UnityEngine.AI;

namespace Entities
{
    public class WalkerEntity
    {
        public GameObject Object { get; set; }
        public NavMeshAgent Agent => Object.gameObject.GetComponent<NavMeshAgent>();
        public WalkerComponent Component { get; }

        public WalkerEntity(PathComponent pathComponent)
        {
            Component = new WalkerComponent(pathComponent);
        }
    }
}
