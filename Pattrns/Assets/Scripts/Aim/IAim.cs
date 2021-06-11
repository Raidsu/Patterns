using UnityEngine;

namespace Asteroids.Aim
{
    public interface IAim
    {
        float AimDistanse { get; }
        Transform BarrelPositionAim { get; }
        GameObject AimInstance { get; }

    }
}