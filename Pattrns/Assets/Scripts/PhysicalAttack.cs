using UnityEngine;

namespace Asteroids
{
    public class PhysicalAttack : IAttack
    {
        private readonly Transform _barrel;
        private readonly float _force;
        public PhysicalAttack(Transform barrel, float force)
        {
            _barrel = barrel;
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