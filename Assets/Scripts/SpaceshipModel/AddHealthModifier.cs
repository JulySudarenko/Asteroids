namespace Asteroids
{
    internal sealed class AddHealthModifier : SpaceshipModifier
    {
        private float _deltaHealth;

        public AddHealthModifier(SpaceshipInitialization spaceship, float health)
            : base(spaceship)
        {
            _deltaHealth = health;
        }

        public override void Handle()
        {
            var oldHealth = _spaceship.SpaceshipHealth;
            _spaceship.ChangeHealth(oldHealth + _deltaHealth);
            base.Handle();
        }
    }
}
