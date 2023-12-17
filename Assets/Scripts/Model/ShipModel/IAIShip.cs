namespace Model.ShipModel
{
    public interface IAIShip : IShip
    {
        IShip Target { get; }
    }
}