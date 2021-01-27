using UnityEngine;

namespace Asteroids
{
    public class SpaceshipInitialization
    {
        private ISpaceshipFactory _spaceshipFactory;
        private GameObject _spaceship;

        public SpaceshipInitialization(ISpaceshipFactory spaceshipFactory)
        {
            _spaceshipFactory = spaceshipFactory;
            _spaceship = _spaceshipFactory.CreateSpaceship();
        }

        public Transform GetTransform()
        {
            return _spaceship.transform;
        }

        public Rigidbody2D GetRigidbody()
        {
            return _spaceship.GetComponent<Rigidbody2D>();
        }
    }
}
