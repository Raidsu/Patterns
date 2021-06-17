using UnityEngine;

namespace Asteroids.StateMotion
{
    public class State
    {
        private MotionStates _motionStates;
        public float Horizontal { get; set; }
        public float Vertival { get; set; }
        public float DeltaTime { get; set; }
        
        public float Speed { get; set; }
        public Transform ShipObject { get; set; }
        

        public State(MotionStates states)
        {
            _motionStates = states;
        }
        
        public MotionStates MotionStates
        {
            set
            {
                _motionStates = value;
                Debug.Log("State: " + _motionStates.GetType().Name);
            }
        }

        public void Request()
        {
            _motionStates.DoMotion(this, Horizontal,Vertival, DeltaTime, Speed, ShipObject);
        }

    }
}