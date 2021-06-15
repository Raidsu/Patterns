using UnityEngine;
using UnityEngine.UIElements;

namespace Asteroids.GamePoints
{
    public class PointsInterpretator
    {
        private readonly TextField _text;
        private bool isVisible = false;
        private readonly PointsConverter _pointsConverter;

        public PointsInterpretator(TextField text)
        {
            _text = text;
            _pointsConverter = new PointsConverter();
        }

        public void PrintPoints(long points)
        {
            _text.value = _pointsConverter.ConvertPoints(points);
        }

        public void ViewPoints()
        {
            isVisible = !isVisible;
            _text.visible = isVisible;
        }
    }
    
    
}