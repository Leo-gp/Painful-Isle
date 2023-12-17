namespace Model.ShipModel.ShipInputHandler
{
    public interface IShooterShipInputHandler : IShipInputHandler
    {
        bool FrontalShootInput { get; }
    }
}