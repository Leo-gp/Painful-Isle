namespace Model.ShipModel
{
    public interface IAIShooterShip : IAIShip, IShooterShip
    {
        float ShootingRange { get; }
    }
}