using System.Collections.Generic;
using UnityEngine;

namespace Model.ShipModel.ShipData
{
    [CreateAssetMenu
        (
            menuName = "Data/Create Ship Deterioration Configurations",
            fileName = "Ship Deterioration Configurations"
        )
    ]
    public class ShipDeteriorationConfiguration : ScriptableObject
    {
        [SerializeField] private List<ShipDeteriorationDefinition> deteriorationDefinitions;

        public List<ShipDeteriorationDefinition> DeteriorationDefinitions => deteriorationDefinitions;
    }
}