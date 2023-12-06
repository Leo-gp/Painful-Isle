namespace Model.ShipModel
{
    public interface IAIShipInputHandler : IShipInputHandler
    {
        IShip Self { get; }

        IShip TargetShip { get; }
    }
}