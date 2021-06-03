using System;
using UnityEngine;

namespace Asteroids.Test
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _barrel;
        private int _countAmmunition;

        public int CountAmmunition => _countAmmunition;

        public IAmmunition Ammunition { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Ammunition.Test();
            }
        }

        public static IWeapon CreateWeapon(IAmmunition ammunition, int countAmmunition)
        {
            var weapon = new GameObject(nameof(Weapon)).AddComponent<Weapon>();
            weapon.Ammunition = ammunition;
            weapon._countAmmunition = countAmmunition;

            return weapon;
        }

        public static IWeapon CreateEmptyWeapon(IAmmunition ammunition, int countAmmunition)
        {
            var weapon = new GameObject(nameof(Weapon)).AddComponent<Weapon>();
            weapon.Ammunition = ammunition;
            weapon._countAmmunition = 0;

            return weapon;
        }
    }
}
