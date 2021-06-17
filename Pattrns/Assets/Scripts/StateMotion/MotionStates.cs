using UnityEngine;

namespace Asteroids.StateMotion
{
    public abstract class MotionStates
    {
        public abstract void DoMotion(State state, float horizontal, float vertical, float deltaTime, float speed, Transform ship);
    }
}