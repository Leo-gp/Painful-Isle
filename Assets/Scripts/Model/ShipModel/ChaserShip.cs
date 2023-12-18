using Model.ShipModel.ShipData;

namespace Model.ShipModel
{
    public abstract class ChaserShip : Ship, IChaserShip
    {
        protected ChaserShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            ShipDeteriorationConfiguration deteriorationConfiguration,
            float explosionDamage
        ) : base(maxHealth, moveSpeed, rotationSpeed, deteriorationConfiguration)
        {
            ExplosionDamage = explosionDamage;
        }

        public float ExplosionDamage { get; }
    }
}