using Model.ShipModel;
using Presenter.ShipPresenter;
using UnityEngine;

namespace View.ShipView
{
    public class ShooterShipView : ShipView
    {
        [SerializeField] private ShooterShipData shipData;

        protected override void OnCollisionEnter2D(Collision2D other)
        {
        }

        protected override ShipPresenter CreateShipPresenter()
        {
            return new ShooterShipPresenter(new Ship(shipData), this);
        }
    }
}