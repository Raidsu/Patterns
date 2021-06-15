using UnityEngine;

namespace Asteroids.Aim
{
    public class Aim : IAim
    {
        public float AimDistanse { get; }
        public Transform BarrelPositionAim { get; }
        public GameObject AimInstance { get; }

        public Aim(float aimDistanse, Transform barrelPositionAim, GameObject aimInstance)
        {
            AimDistanse = aimDistanse;
            BarrelPositionAim = barrelPositionAim;
            AimInstance = aimInstance;
        }
    }
}