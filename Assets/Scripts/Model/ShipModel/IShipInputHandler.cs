namespace Model.ShipModel
{
    public interface IShipInputHandler
    {
        float MoveInput { get; }

        float RotateInput { get; }
    }
}