using Asteroids.StateMotion;
using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;
        private State _motionStates;

        public float Speed { get; protected set; }
        
        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
            _motionStates = new State(new MoveForward());
        }
        

        public void Move(float horizontal, float vertical,  float deltaTime)
        {
            _motionStates.Horizontal=horizontal;
            _motionStates.Vertival = vertical;
            _motionStates.DeltaTime = deltaTime;
            _motionStates.Speed = Speed;
            _motionStates.ShipObject = _transform;
            _motionStates.Request();
            
            //Вариант без паттерна State
            /*var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;*/
        }
    }
}
