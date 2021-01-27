using UnityEngine;

namespace Asteroids
{
    public class WorldInitialization
    {
        private readonly GameCamera _camera;

        public WorldInitialization(SpaceshipData data, Transform player)
        {
            _camera = new GameCamera(player);
            var space = new World(player, data);
            space.CreateWorld();
        }

        public Vector3 Camera => _camera.WorldPosition;
    }
}
