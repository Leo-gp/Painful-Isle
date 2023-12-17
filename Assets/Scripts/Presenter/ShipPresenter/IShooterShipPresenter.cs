namespace Presenter.ShipPresenter
{
    public interface IShooterShipPresenter : IShipPresenter
    {
        float RemainingTimeForFrontalShoot { get; }

        void FrontalShoot();

        bool CanFrontalShoot();

        void UpdateShootCooldown(float elapsedTime);
    }
}