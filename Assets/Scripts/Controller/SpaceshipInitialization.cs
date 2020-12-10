using UnityEngine;


namespace Asteroids
{
    public class SpaceshipInitialization
    {
        private ISpaceshipFactory _spaceshipFactory;
        private GameObject _spaceship;
        // private TrackingSpaceshipContacts _contacts;

        public SpaceshipInitialization(ISpaceshipFactory spaceshipFactory)//, TrackingSpaceshipContacts contacts)
        {
            _spaceshipFactory = spaceshipFactory;
            _spaceship = _spaceshipFactory.CreateSpaceship();
            // _spaceship.AddComponent<TrackingSpaceshipContacts>();
            // _contacts = contacts;
        }

        public GameObject GetSpaceship()
        {
            return _spaceship;
        }
        
        public Transform GetTransform()
        {
            return _spaceship.transform;
        }
    }
}
