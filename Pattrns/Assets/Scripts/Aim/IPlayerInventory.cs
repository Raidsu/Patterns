using UnityEngine;

namespace Asteroids.Aim
{
    public interface IPlayerInventory
    {
        Rigidbody2D BulletInstance { get; }
    }
}