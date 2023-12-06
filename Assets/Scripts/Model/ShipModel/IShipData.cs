namespace Model.ShipModel
{
    public interface IShipData
    {
        float Health { get; }

        float MoveSpeed { get; }

        float RotationSpeed { get; }
    }
}