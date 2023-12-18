using Model.ShipModel.ShipData;

namespace Model.ShipModel
{
    public class AIShooterShip : ShooterShip, IAIShooterShip
    {
        public AIShooterShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            ShipDeteriorationConfiguration deteriorationConfiguration,
            float frontalShootCooldown,
            IShip target,
            float shootingRange
        ) : base(maxHealth, moveSpeed, rotationSpeed, deteriorationConfiguration, frontalShootCooldown)
        {
            Target = target;
            ShootingRange = shootingRange;
        }

        public IShip Target { get; }

        public float ShootingRange { get; }
    }
}