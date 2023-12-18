using System;
using System.Linq;
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
            UpdateDeterioration();
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

        private void UpdateDeterioration()
        {
            Ship.Deterioration = GetCurrentDeterioration();
            ShipView.UpdateDeterioration(Ship.Deterioration);
        }

        private ShipDeterioration GetCurrentDeterioration()
        {
            return Ship.DeteriorationConfiguration.DeteriorationDefinitions
                .OrderBy(definition => definition.Health)
                .Where(definition => Ship.CurrentHealth <= definition.Health)
                .Select(definition => definition.Deterioration)
                .FirstOrDefault();
        }

        private void Explode()
        {
            ShipView.Explode();
        }
    }
}