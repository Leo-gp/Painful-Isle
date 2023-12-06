using System.Numerics;

namespace Model.ShipModel
{
    public class Ship : IShip
    {
        public Ship(IShipData shipData)
        {
            ShipData = shipData;
            CurrentHealth = shipData.Health;
            Deterioration = Deterioration.Healthy;
        }

        public IShipData ShipData { get; }
        public float CurrentHealth { get; set; }
        public Deterioration Deterioration { get; set; }

        public Vector2 Position { get; set; }

        public float RotationAngle { get; set; }
    }
}