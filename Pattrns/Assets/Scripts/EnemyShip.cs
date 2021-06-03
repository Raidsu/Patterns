namespace Asteroids
{
    public class EnemyShip : Enemy
    {
        public void DependencyInject(Health hp, Damage damage)
        {
            Health = hp;
            Damage = damage;
        }
    }
}