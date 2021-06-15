using System;
using UnityEngine;

namespace Asteroids.LockWeapon
{
    public class WeaponProxy : IAttack
    {
        private IAttack _attack;
        private readonly LockWeapon _lockWeapon;

        public WeaponProxy(IAttack attack, LockWeapon lockWeapon)
        {
            _attack = attack;
            _lockWeapon = lockWeapon;
        }
        public void Attack()
        {
            if (_lockWeapon.IsLocked)
            {
                Debug.Log("Weapon is lock. Press H to unlock");                
            }
            else
            {
                _attack.Attack();
            }
        }
    }
}