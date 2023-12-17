namespace Model.ShipModel
{
    public class PlayerShooterShip : ShooterShip, IPlayerShooterShip
    {
        public PlayerShooterShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            float frontalShootCooldown,
            float sideShootCooldown
        ) : base(maxHealth, moveSpeed, rotationSpeed, frontalShootCooldown)
        {
            SideShootCooldown = sideShootCooldown;
        }

        public float SideShootCooldown { get; }
    }
}