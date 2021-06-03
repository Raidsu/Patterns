using System;
using UnityEngine;

namespace Asteroids
{
    public class BulletMarker : MonoBehaviour
    {
        public delegate void OnBulletCollision(GameObject bullet);
        public event OnBulletCollision DestroyBullet;
        
        private void OnCollisionEnter(Collision other)
        {
            DestroyBullet?.Invoke(gameObject);
        }
    }
}