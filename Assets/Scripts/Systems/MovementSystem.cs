using UnityEngine;
using Entities;

namespace Systems
{
    public class MovementSystem
    {
        private const float minDistance = 2f;

        public void MoveToNextPoint(WalkerEntity walker)
        {
            var curPosition = walker.Object.transform.position;
            var path = walker.Component.PathComponent.Path;

            if ((walker.Component.NextPointId >= path.Count || walker.Component.NextPointId < 0) && walker.Component.PathComponent.IsLooped)
            {
                walker.Component.Direction = -walker.Component.Direction;
                walker.Component.NextPointId += 2 * walker.Component.Direction;
            }
            else if (walker.Component.NextPointId >= path.Count && !walker.Component.PathComponent.IsLooped)
            {
                return;
            }

            var nextPosition = walker.Component.PathComponent.Path[walker.Component.NextPointId];

            if (Vector3.Distance(curPosition, nextPosition) > minDistance && !walker.Component.IsMoving)
            {
                walker.Agent.SetDestination(nextPosition);
            }
            else if (Vector3.Distance(curPosition, nextPosition) <= minDistance)
            {
                walker.Component.NextPointId += walker.Component.Direction;
                walker.Agent.SetDestination(nextPosition);
            }
        }
    }
}
