using UnityEngine;

namespace Asteroids
{
    public class HealthInitialization
    {
        private TrackingSpaceshipContacts _contacts;
        private GameObject _spaceship;


        public HealthInitialization(SpaceshipInitialization spaceship, HealthKeeper _healthKeeper)
        {
            _contacts = new TrackingSpaceshipContacts(_healthKeeper);
            //_spaceship.AddComponent(_contacts);
        }
    }
}
