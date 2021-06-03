using UnityEngine;

namespace Asteroids
{
    public class GetDamage
    {

        public float GetDamaged(GameObject other)
        {
            return other.GetComponent<Enemy>().Damage.Max;
        }
    }
}