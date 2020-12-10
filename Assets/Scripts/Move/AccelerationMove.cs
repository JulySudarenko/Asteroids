using UnityEngine;


namespace Asteroids
{
    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;
        public AccelerationMove(Transform transform, ISpeed speed, IAcceleration acceleration)
            : base(transform, speed)
        {
            _acceleration = acceleration.Acceleration;
        }
        public void AddAcceleration()
        {
            Speed += _acceleration;
        }
        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}

