using UnityEngine;

namespace Model.ShipModel.ShipData
{
    public abstract class ShooterShipData : ShipData
    {
        [SerializeField] private float frontalShootCooldown;

        public float FrontalShootCooldown => frontalShootCooldown;
    }
}