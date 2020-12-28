using UnityEngine;


namespace Asteroids
{
    public sealed class SpaceshipMovement : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly ISpeed _speed;

        private readonly IRotation _rotationImplementation;
        public float Speed => _speed.Speed;

        public SpaceshipMovement(IMove moveImplementation, IRotation rotationImplementation, ISpeed speed)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
