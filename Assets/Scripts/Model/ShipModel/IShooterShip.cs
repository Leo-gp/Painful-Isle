namespace Model.ShipModel
{
    public interface IShooterShip : IShip
    {
        float FrontalShootCooldown { get; }
    }
}