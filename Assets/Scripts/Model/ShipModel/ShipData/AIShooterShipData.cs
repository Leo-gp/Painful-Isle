using UnityEngine;

namespace Model.ShipModel.ShipData
{
    [CreateAssetMenu(menuName = "Create AI Shooter Ship Data", fileName = "AI Shooter Ship Data")]
    public class AIShooterShipData : ShooterShipData
    {
        [SerializeField] private float shootingRange;

        public float ShootingRange => shootingRange;
    }
}