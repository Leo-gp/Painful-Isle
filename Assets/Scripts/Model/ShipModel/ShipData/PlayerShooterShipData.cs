using UnityEngine;

namespace Model.ShipModel.ShipData
{
    [CreateAssetMenu(menuName = "Create Player Shooter Ship Data", fileName = "Player Shooter Ship Data")]
    public class PlayerShooterShipData : ShooterShipData
    {
        [SerializeField] private float sideShootCooldown;

        public float SideShootCooldown => sideShootCooldown;
    }
}