using UnityEngine;


namespace Asteroids
{
    public class SpaceshipInitialization
    {
        private ISpaceshipFactory _spaceshipFactory;
        private GameObject _spaceship;
        private TrackingSpaceshipContacts _contacts;

        public SpaceshipInitialization(ISpaceshipFactory spaceshipFactory, HealthKeeper contacts)
        {
            _spaceshipFactory = spaceshipFactory;
            _spaceship = _spaceshipFactory.CreateSpaceship();
            _contacts = _spaceship.AddComponent<TrackingSpaceshipContacts>();
        }
        
        public Transform GetTransform()
        {
            return _contacts.transform;
        }
    }
}
