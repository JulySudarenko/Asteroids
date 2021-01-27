using UnityEngine;

namespace Asteroids
{
    public class SpaceshipController : IIinitialize, ICleanup
    {
        private readonly SpaceshipInitialization _spaceshipInitialization;
        private readonly SpaceshipHealthController _spaceshipHealthController;
        private readonly ContactCenter _contactCenter;
        private ITimeRemaining _timeRemaining;
        private float _healthBonus = 10.0f;
        private float _bonusTime = 20.0f;

        public SpaceshipController(SpaceshipData data, ContactCenter contactCenter)
        {
            var spaceshipFactory = new SpaceshipFactory(data);
            _spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory);
            _spaceshipHealthController = new SpaceshipHealthController(data);
            _contactCenter = contactCenter;
        }

        public SpaceshipHealthController SpaceshipHealthController => _spaceshipHealthController;
        public Transform Spaceship => _spaceshipInitialization.GetTransform();
        public Rigidbody2D Rigidbody => _spaceshipInitialization.GetRigidbody();

        public void Initialize()
        {
            _contactCenter.AddContactInfo(Spaceship.gameObject);
            _contactCenter.SpaceshipHit += _spaceshipHealthController.CauseSpaceshipDamage;

            _timeRemaining = new TimeRemaining(AddModifier, _bonusTime);
            _timeRemaining.AddTimeRemaining();
        }

        private void AddModifier()
        {
            var root = new SpaceshipModifier(_spaceshipInitialization);
            root.Add(new AddHealthModifier(_spaceshipInitialization, _spaceshipHealthController, _healthBonus));
            root.Add(new AddHealthModifier(_spaceshipInitialization, _spaceshipHealthController, _healthBonus));
            root.Add(new AddHealthModifier(_spaceshipInitialization, _spaceshipHealthController, _healthBonus));
            root.Handle();
        }

        public void Cleanup()
        {
            _contactCenter.SpaceshipHit += _spaceshipHealthController.CauseSpaceshipDamage;
        }
    }
}
