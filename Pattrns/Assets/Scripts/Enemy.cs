using System;
using Asteroids.DestroyedEnemyObserver;
using Asteroids.Object_Pool;
using TreeEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour, IDestroyedEnemy 
    {
        public static IEnemyFactory Factory;
        public static IEnemyShipFactory ShipFactory;
        private Transform _rotPool;
        private Health _health;
        private Damage _damage;
        private Rigidbody2D _rigidbody;
        private EnemyDestroyListener _enemyDestroyListener;
        private const int MsgbrokerDestroymessage = 1;

        public Enemy()
        {
            _enemyDestroyListener = new EnemyDestroyListener();
            _enemyDestroyListener.Add(this);
        }
        
        public Damage Damage
        {
            get
            {
                return _damage;
            }
            protected set => _damage = value;
        }
        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReportEnemyDestroyed(gameObject);
                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
        
            enemy.Health = hp;
        
            return enemy;
        }
        
        public static EnemyShip CreateEnemyShip(Health hp, Damage damage)
        {
            var enemy = Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));
        
            enemy.Health = hp;
            enemy.Damage = damage;
        
            return enemy;
        }

        public static Enemy CreateAsteroidEnemyWithPool(EnemyPool enemyPool, Health hp)
        {
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);
            enemy._health = hp;
            return enemy;
        }
        
        public static Enemy CreateEnemyShipWithPool(EnemyPool enemyPool, Health hp, Damage damage)
        {
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);
            enemy._health = hp;
            enemy._damage = damage;
        
            return enemy;
        }
        
        private void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        private void OnBecameInvisible()
        {
            ReturnToPool();
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);

            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }


        public void AddForce()
        {
            var flightVector = Random.insideUnitCircle;
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(new Vector2(flightVector.x,flightVector.y),ForceMode2D.Impulse);
        }

        public event Action<GameObject> OnEnemyDestroyed = delegate(GameObject enemy) {  };
        public void ReportEnemyDestroyed(GameObject enemy)
        {
            OnEnemyDestroyed.Invoke(enemy);
        }
    }
}
