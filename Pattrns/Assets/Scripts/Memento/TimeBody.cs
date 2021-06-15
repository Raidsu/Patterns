using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids.Memento
{
    public class TimeBody
    {
        private float _recordTime;
        private List<PointInTime> _pointsInTime;
        private readonly List<Rigidbody> _recordableGameObjectsRigidbodies;
        public bool IsRewinding { get; private set; }

        public TimeBody(float recordTime)
        {
            _pointsInTime = new List<PointInTime>();
            _recordableGameObjectsRigidbodies = new List<Rigidbody>();
            IsRewinding = false;
            _recordTime = recordTime;
        }

        public void AddRigidbodyToList(Rigidbody addedRigidbody)
        {
            _recordableGameObjectsRigidbodies.Add(addedRigidbody);
        }

        internal void Rewind ()
        {
            foreach (var objectInRigidBodiesList in _recordableGameObjectsRigidbodies.Select(itemInList => itemInList.gameObject.transform))
            {
                if (_pointsInTime.Count > 1)
                {
                    var pointInTime = _pointsInTime[0];
                    objectInRigidBodiesList.position = pointInTime.Position;
                    objectInRigidBodiesList.rotation = pointInTime.Rotation;
                    _pointsInTime.RemoveAt(0);
                } 
                else
                {
                    var pointInTime = _pointsInTime[0];
                    objectInRigidBodiesList.position = pointInTime.Position;
                    objectInRigidBodiesList.rotation = pointInTime.Rotation;
                    StopRewind();
                }
            }
        }

        internal void Record ()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }

            foreach (var item in _recordableGameObjectsRigidbodies)
            {
                var o = item.gameObject;
                _pointsInTime.Insert(0, new PointInTime(o.transform.position, o.transform.rotation, item.velocity, item.angularVelocity));
            }
            
        }

        internal void StartRewind ()
        {
            IsRewinding = true;
            foreach (var item in _recordableGameObjectsRigidbodies)
            {
                item.isKinematic = true;    
            }
            
        }

        internal void StopRewind ()
        {
            IsRewinding = false;
            foreach (var item in _recordableGameObjectsRigidbodies)
            {
                item.isKinematic = false;
                item.velocity = _pointsInTime[0].Velocity;
                item.angularVelocity = _pointsInTime[0].AngularVelocity;    
            }
        }
    }
}