using System;
using System.Collections.Generic;
using Asteroids.GamePoints;
using UnityEngine;
using UnityEngine.UIElements;

namespace Asteroids.UInterface
{
    public class DispleyableUserInterface : MonoBehaviour
    {
        [SerializeField] private TextField _pointsTextField;
        [SerializeField] private long _curentPlayerPoints=0;
        
        private IDisplayableUserInterface _displayPlayerPoints;
        private List<IDisplayableUserInterface> _displayableCommands;

        private void Start()
        {
            _displayPlayerPoints = new ViewPoints(new PointsInterpretator(_pointsTextField));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
               _displayPlayerPoints.ExecutePoints(_curentPlayerPoints);
            }

        }
    }
}