using Presenter.ShipPresenter;

namespace View.Input
{
    public class PlayerShooterShipInputHandler : PlayerShipInputHandler, IPlayerShooterShipInputHandler
    {
        public PlayerShooterShipInputHandler(IShipPresenter shipPresenter) : base(shipPresenter)
        {
        }

        public bool FrontalShootInput => InputActions.Ship.FrontalShoot.WasPerformedThisFrame();

        public bool RightShootInput => InputActions.Ship.RightShoot.WasPerformedThisFrame();

        public bool LeftShootInput => InputActions.Ship.LeftShoot.WasPerformedThisFrame();
    }
}