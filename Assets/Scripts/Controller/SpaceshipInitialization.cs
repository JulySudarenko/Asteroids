using UnityEngine;


namespace Asteroids
{
    public class SpaceshipInitialization
    {
        private ISpaceshipFactory _spaceshipFactory;
        private GameObject _spaceship;
        private TrackingSpaceshipContacts _contacts;
        private HealthKeeper _health;

        public SpaceshipInitialization(ISpaceshipFactory spaceshipFactory, HealthKeeper health)
        {
            _spaceshipFactory = spaceshipFactory;
            _spaceship = _spaceshipFactory.CreateSpaceship();
            _spaceship.AddComponent<TrackingSpaceshipContacts>();
            _health = health;
            _contacts = _spaceship.GetComponent<TrackingSpaceshipContacts>();
            _contacts.CollisionHapend += _health.DetermineContact;
        }

        public Transform GetTransform()
        {
            return _spaceship.transform;
        }

        public void Cleanup()
        {
            _contacts.CollisionHapend -= _health.DetermineContact;
        }
    }
}
