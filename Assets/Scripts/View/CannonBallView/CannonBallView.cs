using System;
using Model.CannonBallModel;
using Model.CannonBallModel.CannonBallData;
using Presenter.CannonBallPresenter;
using UnityEngine;
using View.ShipView;

namespace View.CannonBallView
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    public class CannonBallView : MonoBehaviour, ICannonBallView
    {
        private static readonly int ExplodeAnimatorParamId = Animator.StringToHash("Explode");

        [SerializeField] private CannonBallData cannonBallData;
        [SerializeField] private AnimationClip explosionAnimation;
        [SerializeField] private AudioClip explosionSound;

        private Animator _animator;
        private Collider2D _collider;
        private Vector2 _direction;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
            CannonBallPresenter = CreateCannonBallPresenter();
        }

        private void FixedUpdate()
        {
            if (_rb.bodyType == RigidbodyType2D.Dynamic) _rb.velocity = _direction * cannonBallData.Speed;
        }

        private void OnEnable()
        {
            CannonBallPresenter.OnEnable();
        }

        private void OnDisable()
        {
            CannonBallPresenter.OnDisable();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IShipView shipView))
                OnHitShip?.Invoke(shipView);
            else
                OnHitAnythingOtherThanShip?.Invoke();
        }

        public IShipView OwnerShipView { get; private set; }

        public ICannonBallPresenter CannonBallPresenter { get; private set; }

        public event Action<IShipView> OnHitShip;

        public event Action OnHitAnythingOtherThanShip;

        public void Explode()
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _collider.enabled = false;
            _animator.SetTrigger(ExplodeAnimatorParamId);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Destroy(gameObject, explosionAnimation.length);
        }

        public void Initialize(Vector2 position, Vector2 direction, IShipView ownerShipView)
        {
            transform.position = position;
            _direction = direction;
            OwnerShipView = ownerShipView;
        }

        private ICannonBallPresenter CreateCannonBallPresenter()
        {
            var cannonBall = CreateCannonBall();
            return new CannonBallPresenter(cannonBall, this);
        }

        private ICannonBall CreateCannonBall()
        {
            return new CannonBall(cannonBallData.Damage);
        }
    }
}