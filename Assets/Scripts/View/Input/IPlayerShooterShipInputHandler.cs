using Model.ShipModel.ShipInputHandler;

namespace View.Input
{
    public interface IPlayerShooterShipInputHandler : IShooterShipInputHandler
    {
        bool RightShootInput { get; }

        bool LeftShootInput { get; }
    }
}