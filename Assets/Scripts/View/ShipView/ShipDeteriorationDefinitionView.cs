using System;
using Model.ShipModel;
using UnityEngine;

namespace View.ShipView
{
    [Serializable]
    public struct ShipDeteriorationDefinitionView
    {
        [SerializeField] private ShipDeterioration deterioration;
        [SerializeField] private Sprite sprite;

        public ShipDeterioration Deterioration => deterioration;
        public Sprite Sprite => sprite;
    }
}