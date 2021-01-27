namespace Asteroids
{
    internal sealed class AddHealthModifier : SpaceshipModifier
    {
        private SpaceshipHealthController _spaceshipHealthController;
        private float _deltaHealth;

        public AddHealthModifier(SpaceshipInitialization spaceship, SpaceshipHealthController healthController, float health)
            : base(spaceship)
        {
            _spaceshipHealthController = healthController;
            _deltaHealth = health;
        }

        public override void Handle()
        {
            _spaceshipHealthController.HealthModifier(_deltaHealth);
            base.Handle();
        }
    }
}
