namespace Asteroids.Parsing
{
    public class Infantry : IUnit
    {
        public float HitPoints { get; set; }

        public Infantry(float hitPoints)
        {
            HitPoints = hitPoints;
        }


        public void SetHitPoints(float hitPoints)
        {
            HitPoints = hitPoints;
        }
    }
}