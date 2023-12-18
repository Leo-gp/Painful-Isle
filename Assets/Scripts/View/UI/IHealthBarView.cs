using Model.ShipModel;

namespace View.UI
{
    public interface IHealthBarView
    {
        void Initialize(IShip ship);

        void UpdateHealthBarSlider(float value);

        void Destroy();
    }
}