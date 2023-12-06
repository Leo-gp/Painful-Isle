using Model.ShipModel;
using Presenter.ShipPresenter;
using UnityEngine;
using View.Input;
using Vector2 = System.Numerics.Vector2;

namespace View.ShipView
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class ShipView : MonoBehaviour, IShipView
    {
        public ShipView targetShip; // TODO: Remove. Testing only

        private Rigidbody2D _rb;
        private IShipInputHandler _shipInputHandler;
        private ShipPresenter _shipPresenter;
        private SpriteRenderer _spriteRenderer;

        protected virtual void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _shipPresenter = CreateShipPresenter();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            // TODO: Remove. Testing only
            if (targetShip != null)
                _shipInputHandler = new AIChaserShipInputHandler(_shipPresenter.Ship, targetShip._shipPresenter.Ship);
            else
                _shipInputHandler = new PlayerShooterShipInputHandler();
        }

        private void Update()
        {
            _shipPresenter.HandleMovement(_shipInputHandler.MoveInput);
            _shipPresenter.HandleRotation(_shipInputHandler.RotateInput);
        }

        protected abstract void OnCollisionEnter2D(Collision2D other);

        public Vector2 Position => new(transform.position.x, transform.position.y);

        public float Rotation => transform.eulerAngles.z;

        public void Move(float force)
        {
            _rb.AddForce(-transform.up * force);
        }

        public void Rotate(float angle)
        {
            _rb.rotation -= angle;
        }

        protected abstract ShipPresenter CreateShipPresenter();
    }
}