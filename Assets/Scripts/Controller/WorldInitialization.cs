using UnityEngine;

namespace Asteroids
{
    public class WorldInitialization : IIinitialize, ICleanup
    {
        private GameCamera _camera;
        private SpaceshipInitialization _spaceshipInitialization;
        private float _healthBonus = 10.0f;
        
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

        public void Initialize()
        {
            var root = new SpaceshipModifier(_spaceshipInitialization);
            root.Add(new AddHealthModifier(_spaceshipInitialization, _healthBonus));
            root.Add(new AddHealthModifier(_spaceshipInitialization, _healthBonus));
            root.Add(new AddHealthModifier(_spaceshipInitialization, _healthBonus));
            root.Handle();
            Debug.Log(_spaceshipInitialization.SpaceshipHealth);
        }

        public void Cleanup()
        {
            _spaceshipInitialization.Cleanup();
        }
    }
}
