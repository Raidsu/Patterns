using Asteroids.Aim;
using UnityEngine;

namespace Asteroids
{
    public interface IServiceLocator
    {
        public void CreateBullets(int numOfBulletsToCreate);
        public GameObject GetBullet();
        public IPlayerInventory GetBulletInterface();
        public void ReturnBullet(GameObject bullet);

    }
}