using UnityEngine;

namespace Model.CannonBallModel.CannonBallData
{
    [CreateAssetMenu(menuName = "Create Cannon Ball Data", fileName = "Cannon Ball Data")]
    public class CannonBallData : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;

        public float Speed => speed;
        public float Damage => damage;
    }
}