using System;
using UnityEngine;

namespace Model.ShipModel.ShipData
{
    [Serializable]
    public struct ShipDeteriorationDefinition : IShipDeteriorationDefinition
    {
        [SerializeField] private float health;
        [SerializeField] private ShipDeterioration deterioration;

        public float Health => health;
        public ShipDeterioration Deterioration => deterioration;
    }
}