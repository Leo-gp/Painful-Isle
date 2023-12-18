using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public interface IShipPresenter
    {
        IShip Ship { get; }

        IShipView ShipView { get; }

        void Move(float force);

        void Rotate(float angle);

        void TakeDamage(float amount);

        bool CanMove();

        bool CanRotate();
    }
}