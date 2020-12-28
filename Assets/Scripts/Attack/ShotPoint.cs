using UnityEngine;


namespace Asteroids
{
    public class ShotPoint
    {
        private Transform _point;
        private Vector3 _vector;
        private float _deltaY;

        public ShotPoint(Transform transform, IShotPoint point)
        {
            _point = transform;
            _deltaY = point.ShotPoint;
        }

        public Transform GetPoint()
        {
            _vector = _point.position;
            _vector.y += _deltaY;
            var point = new GameObject();
            point.transform.position = _vector;
            point.transform.rotation = _point.rotation;
                
            return point.transform;
        }
    }
}
