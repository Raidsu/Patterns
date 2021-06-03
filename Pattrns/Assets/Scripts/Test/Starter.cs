using System;
using UnityEngine;

namespace Asteroids.Test
{
    internal sealed class Starter : MonoBehaviour
    {
        private void Start()
        {
            new Example().Test(new Inventory(), Weapon.CreateWeapon(new Ammunition(), 5));
        }
    }
}
