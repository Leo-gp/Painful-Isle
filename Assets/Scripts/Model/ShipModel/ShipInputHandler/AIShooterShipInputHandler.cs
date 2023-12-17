using Presenter.ShipPresenter;

namespace Model.ShipModel.ShipInputHandler
{
    public class AIShooterShipInputHandler : AIShipInputHandler, IShooterShipInputHandler
    {
        private readonly IAIShooterShipPresenter _shipPresenter;

        public AIShooterShipInputHandler(IAIShip ship, IAIShooterShipPresenter shipPresenter) : base(ship)
        {
            _shipPresenter = shipPresenter;
        }

        public override float MoveInput => _shipPresenter.CanMove() ? base.MoveInput : 0f;

        public bool FrontalShootInput => _shipPresenter.CanFrontalShoot();
    }
}