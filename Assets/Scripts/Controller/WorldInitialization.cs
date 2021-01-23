using UnityEngine;

namespace Asteroids
{
    public class WorldInitialization : ICleanup
    {
        private GameCamera _camera;
        private SpaceshipInitialization _spaceshipInitialization;
        
        public WorldInitialization(SpaceshipData data, ContactCenter contactCenter)
        {
            var spaceshipFactory = new SpaceshipFactory(data);
            _spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory, data, contactCenter);
            _camera = new GameCamera(_spaceshipInitialization.GetTransform());
            var space = new World(_spaceshipInitialization.GetTransform(), data);
            space.CreateWorld();
        }

        public Vector3 Camera => _camera.WorldPosition;
        public Transform Spaceship => _spaceshipInitialization.GetTransform();
        public void Cleanup()
        {
            _spaceshipInitialization.Cleanup();
        }
    }
}
