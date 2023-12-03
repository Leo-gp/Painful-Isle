namespace Model.ShipModel
{
    public class Ship
    {
        public Ship(ShipData shipData)
        {
            ShipData = shipData;
            CurrentHealth = shipData.Health;
            Deterioration = Deterioration.Healthy;
        }

        public ShipData ShipData { get; }
        public float CurrentHealth { get; set; }
        public Deterioration Deterioration { get; set; }
    }
}