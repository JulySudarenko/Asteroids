using UnityEngine;

namespace Asteroids
{
    public class WorldInitialization
    {
        private GameCamera _camera;
        private SpaceshipInitialization _spaceshipInitialization;
        
        public WorldInitialization(SpaceshipData data)
        {
            var spaceshipFactory = new SpaceshipFactory(data);
            var healthKeeper = new HealthKeeper(data);
            _spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory, healthKeeper);
            _camera = new GameCamera(_spaceshipInitialization.GetTransform());
            var space = new World(_spaceshipInitialization.GetTransform(), data);
            space.CreateWorld();
        }

        public Vector3 Camera => _camera.WorldPosition;
        public Transform Spaceship => _spaceshipInitialization.GetTransform();
    }
}
