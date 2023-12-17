namespace Presenter.ShipPresenter
{
    public interface IPlayerShooterShipPresenter : IShooterShipPresenter
    {
        float RemainingTimeForSideShoot { get; }

        void RightShoot();

        void LeftShoot();
    }
}