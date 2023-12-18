using Model.ShipModel.ShipData;

namespace Model.ShipModel
{
    public class AIChaserShip : ChaserShip, IAIShip
    {
        public AIChaserShip
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            ShipDeteriorationConfiguration deteriorationConfiguration,
            float explosionDamage,
            IShip target
        ) : base(maxHealth, moveSpeed, rotationSpeed, deteriorationConfiguration, explosionDamage)
        {
            Target = target;
        }

        public IShip Target { get; }
    }
}