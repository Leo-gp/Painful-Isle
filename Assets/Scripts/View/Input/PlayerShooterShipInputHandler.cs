namespace View.Input
{
    public class PlayerShooterShipInputHandler : PlayerShipInputHandler, IPlayerShooterShipInputHandler
    {
        public bool FrontalShootInput => InputActions.Ship.FrontalShoot.WasPerformedThisFrame();

        public bool RightShootInput => InputActions.Ship.RightShoot.WasPerformedThisFrame();

        public bool LeftShootInput => InputActions.Ship.LeftShoot.WasPerformedThisFrame();
    }
}