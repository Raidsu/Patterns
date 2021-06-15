using System.Collections.Generic;
using Asteroids.GamePoints;
using UnityEngine;

namespace Asteroids.UInterface
{
    public class ViewPoints : IDisplayableUserInterface
    {
        public bool Successful { get; private set; }
        private readonly PointsInterpretator _pointsInterpretator;

        public ViewPoints(PointsInterpretator pointsInterpretator)
        {
            _pointsInterpretator = pointsInterpretator;
        }
        
        public bool ExecutePoints(long points)
        {
            _pointsInterpretator.PrintPoints(points);
            _pointsInterpretator.ViewPoints();
            Successful = true;
            return Successful;
        }
    }
}