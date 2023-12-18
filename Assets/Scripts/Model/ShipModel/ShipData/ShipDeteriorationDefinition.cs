using System;
using UnityEngine;

namespace Model.ShipModel.ShipData
{
    [Serializable]
    public struct ShipDeteriorationDefinition
    {
        [SerializeField] private float health;
        [SerializeField] private ShipDeterioration deterioration;

        public float Health => health;
        public ShipDeterioration Deterioration => deterioration;
    }
}