using UnityEngine;

namespace Asteroids
{
    public class EnemyShipFactory : IEnemyShipFactory
    {
       public Enemy Create(Health hp, Damage damage)
        {
            var enemy = Object.Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));
        
            enemy.DependencyInject(hp,damage);
            
       
            return enemy;
        }
    }
}