using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class ShotPoint
    {
        private Transform _parrent;
        private Transform _shotPoint;

        public ShotPoint(Transform parrent, IShotPoint shotPoint)
        {
            _parrent = parrent;
            _shotPoint = shotPoint.ShotPoint;
        }
            
        public Transform GetShotPoint()
        {
            var barrel = new GameObject(NAME_SHOT_POINT).AddTransform(_shotPoint);
            barrel.transform.SetParent(_parrent.transform);
            return barrel.transform;
        }
    }
}
