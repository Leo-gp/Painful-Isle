using UnityEngine;

namespace Model.ShipModel.ShipData
{
    [CreateAssetMenu(menuName = "Create Ship Data", fileName = "Ship Data")]
    public class ShipData : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        public float Health => health;
        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;
    }
}