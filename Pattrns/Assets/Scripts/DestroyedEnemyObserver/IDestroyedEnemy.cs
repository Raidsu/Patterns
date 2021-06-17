using System;
using UnityEngine;

namespace Asteroids.DestroyedEnemyObserver
{
    public interface IDestroyedEnemy
    {
        event Action<GameObject> OnEnemyDestroyed;
        void ReportEnemyDestroyed(GameObject enemy);

    }
}