namespace Model.ShipModel
{
    public interface IPlayerShooterShip : IShooterShip
    {
        float SideShootCooldown { get; }
    }
}