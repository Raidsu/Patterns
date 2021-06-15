using Asteroids.Test;
using UnityEngine;

namespace Asteroids.Aim
{
    public class ShipWeapon : IAttack
    {
        private IPlayerInventory _bullet;
        private Transform _barrel;
        private float _force;
        
        public ShipWeapon(IPlayerInventory bullet, Transform barrelPosition, float force)
        {
            _bullet = bullet;
            _barrel = barrelPosition;
            _force = force;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrel = barrelPosition;
        }

        public void SetBullet(IPlayerInventory bullet)
        {
            _bullet = bullet;
        }

        public void SetForce(float force)
        {
            _force = force;
        }

        
        public void Attack()
        {
            var temAmmunition = ServiceLocator.Resolve<IServiceLocator>().GetBullet();
            temAmmunition.transform.position = _barrel.position;
            temAmmunition.transform.rotation = _barrel.rotation;
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _force);
        }
    }
}