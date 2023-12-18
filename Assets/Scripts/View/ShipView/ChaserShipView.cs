using System;
using Presenter.ShipPresenter;
using UnityEngine;

namespace View.ShipView
{
    public abstract class ChaserShipView : ShipView, IChaserShipView
    {
        private ChaserShipPresenter _shipPresenter;

        protected override void Awake()
        {
            base.Awake();
            _shipPresenter = ShipPresenter as ChaserShipPresenter;
        }

        private void OnEnable()
        {
            _shipPresenter?.OnEnable();
        }

        private void OnDisable()
        {
            _shipPresenter?.OnDisable();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out ShipView shipView)) OnCollidedWithShip?.Invoke(shipView);
        }

        public event Action<IShipView> OnCollidedWithShip;
    }
}