using System;
using UnityEngine;

namespace Asteroids.Memento
{
    public class MementoController : MonoBehaviour
    {
        [SerializeField] private float recordTime = 5f;
        [SerializeField] private GameObject[] gameObjectsToRecord;
        private TimeBody _timeBody;

        private void Start()
        {
            _timeBody = new TimeBody(recordTime);
            
            foreach (var item in gameObjectsToRecord)
            {
                _timeBody.AddRigidbodyToList(item.GetComponent<Rigidbody>());
            }
        }

        private void Update () 
       {
           if (Input.GetKeyDown(KeyCode.Q))
           {
               _timeBody.StartRewind();
           }

           if (Input.GetKeyUp(KeyCode.Q))
           {
               _timeBody.StopRewind();
           }
       }

       private void FixedUpdate ()
       {
           if (_timeBody.IsRewinding)
           {
               _timeBody.Rewind();
           }
           else
           {
               _timeBody.Record();
           }
       }
        
    }
}