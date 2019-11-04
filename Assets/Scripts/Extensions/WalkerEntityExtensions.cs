using Entities;

namespace Systems
{
    public static class WalkerEntityExtensions
    {
        private const float accelerationFactor = 3f;

        public static void SetMovementParameters(this WalkerEntity walker)
        {
            var pathComponent = walker.Component.PathComponent;
            var pathLength = walker.Component.PathComponent.Path.GetLengthOfPath();
            walker.Agent.speed = pathLength / pathComponent.FinishTime;
            walker.Agent.acceleration = walker.Agent.speed * accelerationFactor;
        }
    }
}
