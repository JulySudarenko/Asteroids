using UnityEngine;
using Object = UnityEngine.Object;


namespace Asteroids
{
    public class World
    {
        private Transform _stars;
        private Transform _parent;

        public World(Transform player, IWorld stars)
        {
            _parent = player;
            _stars = stars.Stars;
        }

        public Transform CreateWorld()
        {
            return Object.Instantiate(_stars, _parent);
        }
    }
}
