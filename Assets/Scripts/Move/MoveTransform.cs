using UnityEngine;


namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        public float Speed { get; protected set; }

        private readonly Transform _transform;
        private Vector3 _move;

        public MoveTransform(Transform transform, ISpeed speed)
        {
            _transform = transform;
            Speed = speed.Speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }
    }
}
