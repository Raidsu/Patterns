using UnityEngine;
namespace Asteroids.StateMotion
{
    public class MoveForward : MotionStates
    {
     public override void DoMotion(State state, float horizontal, float vertical, float deltaTime, float speed, Transform ship)
        {
            var shipSpeed = deltaTime * speed;
            var move = new Vector3(horizontal * speed, vertical * speed, 0.0f);
            ship.localPosition += move;
        }
    }
}