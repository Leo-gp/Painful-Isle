using System.Numerics;

namespace Model.ShipModel
{
    public interface IShip
    {
        IShipData ShipData { get; }
        float CurrentHealth { get; set; }
        Deterioration Deterioration { get; set; }
        Vector2 Position { get; set; }
        float RotationAngle { get; set; }
    }
}