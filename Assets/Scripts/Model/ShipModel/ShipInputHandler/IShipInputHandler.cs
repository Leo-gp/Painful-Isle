namespace Model.ShipModel.ShipInputHandler
{
    public interface IShipInputHandler
    {
        float MoveInput { get; }

        float RotateInput { get; }
    }
}