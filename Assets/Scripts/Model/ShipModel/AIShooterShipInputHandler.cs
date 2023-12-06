namespace Model.ShipModel
{
    public class AIShooterShipInputHandler : IAIShooterShipInputHandler
    {
        public float MoveInput { get; }

        public float RotateInput { get; }

        public IShip Self { get; }

        public IShip TargetShip { get; }

        public bool FrontalShootInput { get; }

        public bool RightShootInput { get; }

        public bool LeftShootInput { get; }
    }
}