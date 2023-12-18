using UnityEngine;

namespace Model.ShipModel.ShipData
{
    [CreateAssetMenu(menuName = "Data/Create Chaser Ship Data", fileName = "Chaser Ship Data")]
    public class ChaserShipData : ShipData
    {
        [SerializeField] private float explosionDamage;

        public float ExplosionDamage => explosionDamage;
    }
}