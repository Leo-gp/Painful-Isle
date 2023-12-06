using UnityEngine;

namespace Model.ShipModel
{
    public abstract class ShipData : ScriptableObject, IShipData
    {
        [SerializeField] private float health;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        public float Health => health;
        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;
    }
}