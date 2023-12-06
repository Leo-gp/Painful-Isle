using System.Numerics;

namespace View.ShipView
{
    public interface IShipView
    {
        Vector2 Position { get; }

        float Rotation { get; }

        void Move(float force);

        void Rotate(float angle);
    }
}