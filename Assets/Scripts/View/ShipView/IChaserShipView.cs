using System;

namespace View.ShipView
{
    public interface IChaserShipView : IShipView
    {
        event Action<IShipView> OnCollidedWithShip;
    }
}