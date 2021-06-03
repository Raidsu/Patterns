using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class BulletPool
    {
        private Dictionary<int,GameObject> _clip;
        private readonly GameObject _bullet;
        private BulletMarker _bulletMarker;
        public BulletPool(GameObject bulletPrefab)
        {
            _clip = new Dictionary<int, GameObject>();
            _bullet = bulletPrefab;
            _bulletMarker = new BulletMarker();
            _bulletMarker.DestroyBullet += ReturnBullet;
        }

        public void CreateBullets (int numOfBulletsToCreate)
        {
            for (var index = 0; index < numOfBulletsToCreate; index++)
            {
                var bullet = Object.Instantiate(_bullet);
                _clip.Add(bullet.GetInstanceID(),bullet);
                bullet.SetActive(false);
            }
        }

        public GameObject GetBullet()
        {
            foreach (var bullet in _clip.Where(item => item.Value.activeInHierarchy == false))
            {
                return bullet.Value;
            }
            CreateBullets(1);
            return _clip.Values.Last();
        }

        public void ReturnBullet(GameObject bullet)
        {
            _clip[bullet.GetInstanceID()].SetActive(false);
        }


        ~BulletPool()
        {
            _bulletMarker.DestroyBullet -= ReturnBullet;
        }
        
    }
    
    
}