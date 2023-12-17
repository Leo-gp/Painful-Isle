namespace Model.ShipModel
{
    public class ShooterShip : Ship, IShooterShip
    {
        protected ShooterShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            float frontalShootCooldown
        ) : base(maxHealth, moveSpeed, rotationSpeed)
        {
            FrontalShootCooldown = frontalShootCooldown;
        }

        public float FrontalShootCooldown { get; }
    }
}