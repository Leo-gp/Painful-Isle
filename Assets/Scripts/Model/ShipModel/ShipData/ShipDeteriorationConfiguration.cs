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
    public class ShipDeteriorationConfiguration : ScriptableObject, IShipDeteriorationConfiguration
    {
        [SerializeField] private List<ShipDeteriorationDefinition> deteriorationDefinitions;

        public List<IShipDeteriorationDefinition> DeteriorationDefinitions =>
            deteriorationDefinitions.ConvertAll(x => (IShipDeteriorationDefinition)x);
    }
}