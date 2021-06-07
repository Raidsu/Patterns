using UnityEngine;

namespace Asteroids
{
    public interface IServiceLocator
    {
        public void CreateBullets(int numOfBulletsToCreate);
        public GameObject GetBullet();
        public void ReturnBullet(GameObject bullet);

    }
}