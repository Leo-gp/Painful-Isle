namespace Model.ShipModel.ShipData
{
    public interface IShipDeteriorationDefinition
    {
        float Health { get; }
        ShipDeterioration Deterioration { get; }
    }
}