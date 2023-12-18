using System;
using Presenter.CannonBallPresenter;
using View.ShipView;

namespace View.CannonBallView
{
    public interface ICannonBallView
    {
        ICannonBallPresenter CannonBallPresenter { get; }

        IShipView OwnerShipView { get; }

        event Action<IShipView> OnHitShip;

        event Action OnHitAnythingOtherThanShip;

        void Explode();
    }
}