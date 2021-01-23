using UnityEngine;


namespace Asteroids
{
    public class SpaceshipInitialization
    {
        private ISpaceshipFactory _spaceshipFactory;
        private GameObject _spaceship;
        private ContactCenter _contactCenter;
        private Health _health;

        public SpaceshipInitialization(ISpaceshipFactory spaceshipFactory, IHealth health, ContactCenter contactCenter)
        {
            _spaceshipFactory = spaceshipFactory;
            _spaceship = _spaceshipFactory.CreateSpaceship();

            _contactCenter = contactCenter;
            _health = new Health(health, health.Health);

            _contactCenter.AddContactInfo(_spaceship);
            _contactCenter.SpaceshipHit += _health.CauseSpaceshipDamage;
        }

        public Transform GetTransform()
        {
            return _spaceship.transform;
        }

        public void Cleanup()
        {
            _contactCenter.SpaceshipHit -= _health.CauseSpaceshipDamage;
        }
    }
}
