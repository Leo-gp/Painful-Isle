using UnityEngine;

namespace Model.ShipModel
{
    [CreateAssetMenu(menuName = "Create Shooter Ship Data", fileName = "Shooter Ship Data")]
    public class ShooterShipData : ShipData
    {
        [SerializeField] private float frontalShootRate;
        [SerializeField] private float sideShootRate;

        public float FrontalShootRate => frontalShootRate;
        public float SideShootRate => sideShootRate;
    }
}