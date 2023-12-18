using System.Numerics;
using Model.ShipModel.ShipData;

namespace Model.ShipModel
{
    public abstract class Ship : IShip
    {
        protected Ship
        (
            float maxHealth,
            float moveSpeed,
            float rotationSpeed,
            ShipDeteriorationConfiguration deteriorationConfiguration
        )
        {
            MaxHealth = maxHealth;
            MoveSpeed = moveSpeed;
            RotationSpeed = rotationSpeed;
            CurrentHealth = maxHealth;
            DeteriorationConfiguration = deteriorationConfiguration;
        }

        public float MaxHealth { get; }

        public float MoveSpeed { get; }

        public float RotationSpeed { get; }

        public float CurrentHealth { get; set; }

        public ShipDeterioration Deterioration { get; set; }

        public ShipDeteriorationConfiguration DeteriorationConfiguration { get; }

        public Vector2 Position { get; set; }

        public float RotationAngle { get; set; }

        public bool IsDestroyed => CurrentHealth <= 0f;
    }
}