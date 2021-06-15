using System;

namespace Asteroids.GamePoints
{
    public class PointsConverter
    {
        internal string ConvertPoints(long points)
        {
            if (points > 1000000000 && points < 999999999999)
            {
                return points / 1000000000 + "B";
            }
            else if (points > 1000000 && points < 999999999)
            {
                return points / 1000000 + "M";
            }
            else if (points > 1000 && points < 999999)
            {
                return points / 1000 + "K";
            }
            else
            {
                return points.ToString();
            }
        }
    }
}