using Model.ShipModel.ShipData;

namespace Model.ShipModel
{
    public abstract class ShooterShip : Ship, IShooterShip
    {
        protected ShooterShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            ShipDeteriorationConfiguration deteriorationConfiguration,
            float frontalShootCooldown
        ) : base(maxHealth, moveSpeed, rotationSpeed, deteriorationConfiguration)
        {
            FrontalShootCooldown = frontalShootCooldown;
        }

        public float FrontalShootCooldown { get; }
    }
}