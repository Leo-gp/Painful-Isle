using Presenter.ShipPresenter;

namespace Model.ShipModel.ShipInputHandler
{
    public class AIShooterShipInputHandler : AIShipInputHandler, IShooterShipInputHandler
    {
        private readonly IAIShooterShipPresenter _shipPresenter;

        public AIShooterShipInputHandler
        (
            IAIShip ship,
            IAIShooterShipPresenter shipPresenter
        ) : base(ship, shipPresenter)
        {
            _shipPresenter = shipPresenter;
        }

        public bool FrontalShootInput => _shipPresenter.CanFrontalShoot();
    }
}