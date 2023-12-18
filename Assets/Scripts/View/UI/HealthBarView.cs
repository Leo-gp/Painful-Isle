using Model.ShipModel;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private Vector2 offset;
        [SerializeField] private Slider slider;

        private IShip _ship;

        private void Start()
        {
            transform.rotation = Quaternion.identity;
        }

        private void Update()
        {
            transform.position = new Vector2(_ship.Position.X + offset.x, _ship.Position.Y + offset.y);
        }

        public void Initialize(IShip ship)
        {
            _ship = ship;
        }

        public void UpdateHealthBarSlider(float percentage)
        {
            slider.value = percentage * slider.maxValue / 100f;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}