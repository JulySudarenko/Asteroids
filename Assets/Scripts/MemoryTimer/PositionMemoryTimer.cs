using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PositionMemoryTimer : IExecute, IFixedExecute
    {
        private float _recordTime = 5.0f;
        private List<PointInTime> _pointsInTime;
        private Rigidbody2D _rb;

        private bool _isRewinding;


        public PositionMemoryTimer(Rigidbody2D rigidbody)
        {
            _pointsInTime = new List<PointInTime>();
            _rb = rigidbody;
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartRewind();
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                StopRewind();
            }
        }

        public void FixedExecute(float deltaTime)
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        private void Rewind()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _rb.transform.position = pointInTime.Position;
                _rb.transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _rb.transform.position = pointInTime.Position;
                _rb.transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        private void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }

            _pointsInTime.Insert(0, new PointInTime(_rb.transform.position,
                _rb.transform.rotation, _rb.velocity));
        }

        private void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
            foreach (var point in _pointsInTime)
            {
                Debug.Log(point.ToString());
            }
        }

        private void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
        }
    }
}
