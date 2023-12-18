using UnityEngine;

namespace Model.ShipModel.ShipData
{
    public abstract class ShipData : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private ShipDeteriorationConfiguration deteriorationConfiguration;
        public ShipDeteriorationConfiguration DeteriorationConfiguration => deteriorationConfiguration;
        public float Health => health;
        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;
    }
}