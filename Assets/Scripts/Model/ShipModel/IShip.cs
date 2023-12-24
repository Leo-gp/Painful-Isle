using System.Numerics;
using Model.ShipModel.ShipData;

namespace Model.ShipModel
{
    public interface IShip
    {
        float MaxHealth { get; }
        float MoveSpeed { get; }
        float RotationSpeed { get; }
        float CurrentHealth { get; set; }
        ShipDeterioration Deterioration { get; set; }
        IShipDeteriorationConfiguration DeteriorationConfiguration { get; }
        Vector2 Position { get; set; }
        float RotationAngle { get; set; }
        bool IsDestroyed { get; }
    }
}