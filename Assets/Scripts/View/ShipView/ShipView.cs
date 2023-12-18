using Model.ShipModel.ShipInputHandler;
using Presenter.ShipPresenter;
using UnityEngine;
using View.UI;
using Vector2 = System.Numerics.Vector2;

namespace View.ShipView
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class ShipView : MonoBehaviour, IShipView
    {
        [SerializeField] private HealthBarView healthBarViewPrefab;

        private Collider2D _collider;
        private IHealthBarView _healthBarView;
        private Rigidbody2D _rb;
        private SpriteRenderer _spriteRenderer;

        protected IShipInputHandler ShipInputHandler;

        protected virtual void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            ShipPresenter = CreateShipPresenter();
            ShipInputHandler = CreateShipInputHandler();
            _healthBarView = CreateHealthBarView();
        }

        protected virtual void Update()
        {
            ShipPresenter.Move(ShipInputHandler.MoveInput);
            ShipPresenter.Rotate(ShipInputHandler.RotateInput);
        }

        public IShipPresenter ShipPresenter { get; private set; }

        public Vector2 Position => new(transform.position.x, transform.position.y);

        public float Rotation => transform.eulerAngles.z;

        public Vector2 UpVector => new(-transform.up.x, -transform.up.y);

        public Vector2 RightVector => new(-transform.right.x, -transform.right.y);

        public void Move(float force)
        {
            _rb.AddForce(-transform.up * force);
        }

        public void Rotate(float angle)
        {
            _rb.rotation -= angle;
        }

        public void Explode()
        {
            _collider.enabled = false;
        }

        public void UpdateHealthBarSlider(float percentage)
        {
            _healthBarView.UpdateHealthBarSlider(percentage);
        }

        private IHealthBarView CreateHealthBarView()
        {
            var healthBarView = Instantiate(healthBarViewPrefab);
            healthBarView.Initialize(ShipPresenter.Ship);
            healthBarView.name = $"{name} HealthBar";
            return healthBarView;
        }

        protected abstract IShipPresenter CreateShipPresenter();

        protected abstract IShipInputHandler CreateShipInputHandler();
    }
}