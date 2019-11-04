namespace Components
{
    public class WalkerComponent
    {
        public PathComponent PathComponent { get; }
        public int NextPointId { get; set; }
        public int Direction { get; set; }
        public bool IsMoving { get; set; }

        public WalkerComponent(PathComponent pathComponent)
        {
            this.PathComponent = pathComponent;
            NextPointId = 0;
            Direction = 1;
            IsMoving = false;
        }
    }
}
