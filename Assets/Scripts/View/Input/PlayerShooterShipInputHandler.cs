using Model.ShipModel.ShipInputHandler;

namespace View.Input
{
    public class PlayerShooterShipInputHandler : PlayerShipInputHandler, IShooterShipInputHandler
    {
        public bool RightShootInput => InputActions.Ship.RightShoot.WasPerformedThisFrame();

        public bool LeftShootInput => InputActions.Ship.LeftShoot.WasPerformedThisFrame();

        public bool FrontalShootInput => InputActions.Ship.FrontalShoot.WasPerformedThisFrame();
    }
}