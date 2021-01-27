namespace Asteroids
{
    public sealed class Health
    {

        private float _maxHealth;
        public float Current { get; private set; }

        public Health(IHealth max, float current)
        {
            _maxHealth = max.Health;
            ChangeCurrentHealth(current);
        }

        public float MAXHealth => _maxHealth;

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
    }
}
