using Model.ShipModel;
using Presenter.ShipPresenter;
using UnityEngine;

namespace View.ShipView
{
    public class ChaserShipView : ShipView
    {
        [SerializeField] private ChaserShipData shipData;

        protected override void OnCollisionEnter2D(Collision2D other)
        {
        }

        protected override ShipPresenter CreateShipPresenter()
        {
            return new ChaserShipPresenter(new Ship(shipData), this);
        }
    }
}