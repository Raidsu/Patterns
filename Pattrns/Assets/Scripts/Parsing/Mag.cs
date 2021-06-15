namespace Asteroids.Parsing
{
    public class Mag : IUnit
    {
        public float HitPoints { get; set; }

        public Mag(float hitPoints)
        {
            HitPoints = hitPoints;
        }


        public void SetHitPoints(float hitPoints)
        {
            HitPoints = hitPoints;
        }
    }
}