namespace Model.CannonBallModel
{
    public class CannonBall : ICannonBall
    {
        public CannonBall(float damage)
        {
            Damage = damage;
        }

        public float Damage { get; }
    }
}