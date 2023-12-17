using UnityEngine;
using View.ShipView;

namespace View.CannonBallView
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    public class CannonBallView : MonoBehaviour
    {
        private static readonly int ExplodeAnimatorParamId = Animator.StringToHash("Explode");

        [SerializeField] private float speed;
        [SerializeField] private AnimationClip explosionAnimation;
        [SerializeField] private AudioClip explosionSound;

        private Animator _animator;
        private Collider2D _collider;
        private Vector2 _direction;
        private IShipView _ownerShipView;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }

        private void FixedUpdate()
        {
            if (_rb.bodyType == RigidbodyType2D.Dynamic) _rb.velocity = _direction * speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<IShipView>() == _ownerShipView) return;

            Explode();
        }

        public void Initialize(Vector2 position, Vector2 direction, IShipView ownerShipView)
        {
            transform.position = position;
            _direction = direction;
            _ownerShipView = ownerShipView;
        }

        private void Explode()
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _collider.enabled = false;
            _animator.SetTrigger(ExplodeAnimatorParamId);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Destroy(gameObject, explosionAnimation.length);
        }
    }
}