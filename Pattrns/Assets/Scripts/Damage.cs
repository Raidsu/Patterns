namespace Asteroids
{
    public class Damage
    {
        public float Max { get; private set; }
        
        public Damage(float max)
        {
            Max = max;
        }

        public void ChangeDamage(float damage)
        {
            Max = damage;
        }
    }
}