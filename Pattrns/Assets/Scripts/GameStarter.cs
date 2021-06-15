using System;
using Asteroids.Abstrac_Factory;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(10);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);
            enemy.AddForce();
            return;
            
            
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            Enemy.CreateEnemyShip(new Health(100.0f, 100f), new Damage(10f));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));
            
            IEnemyShipFactory enemyShipFactory = new EnemyShipFactory();
            enemyShipFactory.Create(new Health(100.0f, 100.0f),new Damage(10f));

            Enemy.Factory.Create(new Health(100.0f, 100.0f));
            Enemy.ShipFactory.Create(new Health(100.0f, 100.0f), new Damage(10f));


            var platform = new PlatformFactory().Create(Application.platform);

            //System.Threading.ThreadPool.QueueUserWorkItem(state => Debug.Log("Test"));
        }

    }
}
