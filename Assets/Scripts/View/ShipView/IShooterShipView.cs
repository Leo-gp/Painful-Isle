using System.Numerics;

namespace View.ShipView
{
    public interface IShooterShipView : IShipView
    {
        void Shoot(Vector2 position, Vector2 direction);
    }
}