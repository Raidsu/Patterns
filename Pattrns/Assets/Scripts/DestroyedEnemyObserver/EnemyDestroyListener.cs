using UnityEngine;

namespace Asteroids.DestroyedEnemyObserver
{
    public class EnemyDestroyListener
    {
        public void Add(IDestroyedEnemy value)
        {
            value.OnEnemyDestroyed += OnDestroyed;
        }

        public void Remove(IDestroyedEnemy value)
        {
            value.OnEnemyDestroyed -= OnDestroyed;
        }

        private void OnDestroyed(GameObject enemy)
        {
            Debug.Log($"Враг {enemy.name} был уничтожен.");
        }

    }
}