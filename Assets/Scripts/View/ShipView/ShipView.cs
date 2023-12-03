using Presenter.ShipPresenter;
using UnityEngine;

namespace View.ShipView
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class ShipView : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private ShipPresenter _shipPresenter;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _shipPresenter = CreateShipPresenter();
        }

        protected abstract void OnCollisionEnter2D(Collision2D other);

        protected abstract ShipPresenter CreateShipPresenter();
    }
}