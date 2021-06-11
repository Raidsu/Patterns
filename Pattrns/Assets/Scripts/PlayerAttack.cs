namespace Asteroids
{
    public class PlayerAttack
    {
        private readonly IAttack _attack;

        public PlayerAttack(IAttack attack)
        {
            _attack = attack;
        }

        public void Attack()
        {
            _attack.Attack();
        }
    }
}