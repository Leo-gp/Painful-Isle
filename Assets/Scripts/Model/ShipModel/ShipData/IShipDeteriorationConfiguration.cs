using System.Collections.Generic;

namespace Model.ShipModel.ShipData
{
    public interface IShipDeteriorationConfiguration
    {
        List<IShipDeteriorationDefinition> DeteriorationDefinitions { get; }
    }
}