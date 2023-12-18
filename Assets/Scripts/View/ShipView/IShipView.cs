using System.Numerics;
using Model.ShipModel;
using Presenter.ShipPresenter;

namespace View.ShipView
{
    public interface IShipView
    {
        IShipPresenter ShipPresenter { get; }

        Vector2 Position { get; }

        float Rotation { get; }

        Vector2 UpVector { get; }

        Vector2 RightVector { get; }

        void Move(float force);

        void Rotate(float angle);

        void Explode();

        void UpdateHealthBarSlider(float percentage);

        void UpdateDeterioration(ShipDeterioration shipDeterioration);
    }
}