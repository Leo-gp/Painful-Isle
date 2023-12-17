namespace Model.ShipModel
{
    public class AIChaserShip : Ship, IAIShip
    {
        public AIChaserShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            IShip target
        ) : base(maxHealth, moveSpeed, rotationSpeed)
        {
            Target = target;
        }

        public IShip Target { get; }
    }
}