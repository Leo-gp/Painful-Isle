using System.Numerics;

namespace Model.ShipModel
{
    public abstract class Ship : IShip
    {
        protected Ship(float maxHealth, float moveSpeed, float rotationSpeed)
        {
            MaxHealth = maxHealth;
            MoveSpeed = moveSpeed;
            RotationSpeed = rotationSpeed;
            CurrentHealth = maxHealth;
            ShipDeterioration = ShipDeterioration.Healthy;
        }

        public float MaxHealth { get; }

        public float MoveSpeed { get; }

        public float RotationSpeed { get; }

        public float CurrentHealth { get; set; }

        public ShipDeterioration ShipDeterioration { get; set; }

        public Vector2 Position { get; set; }

        public float RotationAngle { get; set; }
    }
}