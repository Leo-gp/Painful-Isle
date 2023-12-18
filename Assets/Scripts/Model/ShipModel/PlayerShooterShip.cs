using Model.ShipModel.ShipData;

namespace Model.ShipModel
{
    public class PlayerShooterShip : ShooterShip, IPlayerShooterShip
    {
        public PlayerShooterShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            ShipDeteriorationConfiguration deteriorationConfiguration,
            float frontalShootCooldown,
            float sideShootCooldown
        ) : base(maxHealth, moveSpeed, rotationSpeed, deteriorationConfiguration, frontalShootCooldown)
        {
            SideShootCooldown = sideShootCooldown;
        }

        public float SideShootCooldown { get; }
    }
}