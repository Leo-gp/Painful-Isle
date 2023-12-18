using System.Numerics;

namespace Model.ShipModel
{
    public interface IShip
    {
        float MaxHealth { get; }
        float MoveSpeed { get; }
        float RotationSpeed { get; }
        float CurrentHealth { get; set; }
        ShipDeterioration ShipDeterioration { get; set; }
        Vector2 Position { get; set; }
        float RotationAngle { get; set; }
        bool IsDestroyed { get; }
    }
}