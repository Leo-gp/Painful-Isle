using System.Collections.Generic;
using UnityEngine;

namespace View.ShipView
{
    [CreateAssetMenu
        (
            menuName = "Data/Create Ship Deterioration View Configurations",
            fileName = "Ship Deterioration View Configurations"
        )
    ]
    public class ShipDeteriorationConfigurationView : ScriptableObject
    {
        [SerializeField] private List<ShipDeteriorationDefinitionView> deteriorationViewDefinitions;

        public List<ShipDeteriorationDefinitionView> DeteriorationViewDefinitions => deteriorationViewDefinitions;
    }
}