namespace Model.ShipModel
{
    public interface IShooterShipInputHandler : IShipInputHandler
    {
        bool FrontalShootInput { get; }

        bool RightShootInput { get; }

        bool LeftShootInput { get; }
    }
}