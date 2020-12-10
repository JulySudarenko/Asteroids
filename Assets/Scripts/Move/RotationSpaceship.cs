using UnityEngine;


namespace Asteroids
{
    internal sealed class RotationSpaceship : IRotation
    {
        private readonly Transform _transform;

        public RotationSpaceship(Transform transform)
        {
            _transform = transform;
        }

        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle,
                Vector3.forward);
        }

    }
}
