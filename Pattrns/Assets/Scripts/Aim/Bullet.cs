using UnityEngine;

namespace Asteroids.Aim
{
    public class Bullet : IPlayerInventory
    {
        public Rigidbody2D BulletInstance { get; }
        
        public Bullet(Rigidbody2D bulletInstance)
        {
            BulletInstance = bulletInstance;
        }

    }
}