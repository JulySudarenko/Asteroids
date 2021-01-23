using UnityEngine;


namespace Asteroids
{
    public class SpaceshipInitialization
    {
        private ISpaceshipFactory _spaceshipFactory;
        private GameObject _spaceship;
        private TrackingContacts _contacts;
        private ContactCenter _contactCenter;
        private Health _health;

        public SpaceshipInitialization(ISpaceshipFactory spaceshipFactory,  IHealth health, ContactCenter contactCenter)
        {
            _spaceshipFactory = spaceshipFactory;
            _spaceship = _spaceshipFactory.CreateSpaceship();
            
            _contactCenter = contactCenter;
            _health = new Health(health, health.Health);
            
            _contactCenter.AddContactInfo(_spaceship);
        }

        public Transform GetTransform()
        {
            return _spaceship.transform;
        }
    }
}
