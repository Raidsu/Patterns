using System.Collections.Generic;
using System.Linq;
using Asteroids.Aim;
using UnityEngine;

namespace Asteroids
{
    public class BulletPool : IServiceLocator , IPlayerInventory
    {
        private Dictionary<GameObject,IPlayerInventory> _clip;
        private readonly Sprite _bulletSprite;
        private readonly BulletMarker _bulletMarker;
        public Rigidbody2D BulletInstance { get; }
        
        
        
        public BulletPool(Sprite bulletSpritePrefab)
        {
            _clip = new Dictionary<GameObject, IPlayerInventory>();
            _bulletSprite = bulletSpritePrefab;
            _bulletMarker = new BulletMarker();
            _bulletMarker.DestroyBullet += ReturnBullet;
        }

        public void CreateBullets (int numOfBulletsToCreate)
        {
            for (var index = 0; index < numOfBulletsToCreate; index++)
            {
                var bullet = new GameObject().SetName("Bullet").AddBoxCollider2D().AddRigidbody2D(2f).AddSprite(_bulletSprite);
                bullet.gameObject.AddComponent<BulletMarker>();
                var shipBullet = new Bullet(bullet.GetComponent<Rigidbody2D>());
                _clip.Add(bullet,shipBullet);
                bullet.SetActive(false);
            }
        }

        public GameObject GetBullet()
        {
            var allBullets = Object.FindObjectsOfType<BulletMarker>();

            foreach (var t in allBullets)
            {
                if (t.gameObject.activeInHierarchy == true)
                    return t.gameObject;
            }
            
            CreateBullets(1);
            return allBullets.Last().gameObject;
        }

        public IPlayerInventory GetBulletInterface()
        {
            var allBullets = Object.FindObjectsOfType<BulletMarker>();
            foreach (var t in allBullets)
            {
                if (t.gameObject.activeInHierarchy == true)
                {
                    if (_clip.ContainsKey(t.gameObject))
                    {
                        return _clip[t.gameObject];
                    }
                }
            }
            CreateBullets(1);
            return _clip.Last().Value;
        }

        public void ReturnBullet(GameObject bullet)
        {
            var allBullets = Object.FindObjectsOfType<BulletMarker>();

            foreach (var t in allBullets)
            {
                if (t.gameObject.GetInstanceID() == bullet.GetInstanceID())
                   t.gameObject.SetActive(false);
            }
            
        }


        ~BulletPool()
        {
            _bulletMarker.DestroyBullet -= ReturnBullet;
        }


        
    }
    
    
}