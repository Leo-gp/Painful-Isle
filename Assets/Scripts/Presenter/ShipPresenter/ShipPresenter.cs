using System;
using Model.ShipModel;
using View.ShipView;

namespace Presenter.ShipPresenter
{
    public abstract class ShipPresenter : IShipPresenter
    {
        protected ShipPresenter(IShip ship, IShipView shipView)
        {
            Ship = ship;
            ShipView = shipView;
        }

        public IShip Ship { get; }

        public IShipView ShipView { get; }

        public void Move(float force)
        {
            ShipView.Move(force * Ship.MoveSpeed);
            Ship.Position = ShipView.Position;
        }

        public void Rotate(float angle)
        {
            ShipView.Rotate(angle * Ship.RotationSpeed);
            Ship.RotationAngle = ShipView.Rotation;
        }

        public void TakeDamage(float amount)
        {
            Ship.CurrentHealth = MathF.Max(Ship.CurrentHealth - amount, 0f);
            if (Ship.CurrentHealth <= 0f) Explode();
            ShipView.UpdateHealthBarSlider(Ship.CurrentHealth / Ship.MaxHealth * 100f);
        }

        public virtual bool CanMove()
        {
            return !Ship.IsDestroyed;
        }

        public virtual bool CanRotate()
        {
            return !Ship.IsDestroyed;
        }

        private void Explode()
        {
            ShipView.Explode();
        }
    }
}