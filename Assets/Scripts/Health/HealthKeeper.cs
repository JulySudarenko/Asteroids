using System;


namespace Asteroids
{
    public class HealthKeeper
    {
        public Action<float> DamageDone;
        public Action<float> FirstAidReceived;
        private IHealth _maxHealth;
        private float _spaceshipHealth;

        public float SpaceshipHealth => _spaceshipHealth;

        public HealthKeeper(IHealth maxHealth)
        {
            _maxHealth = maxHealth;
            _spaceshipHealth = _maxHealth.Health;

            DamageDone = CauseDamage;
            FirstAidReceived = Heal;
        }

        private void CauseDamage(float point)
        {
            _spaceshipHealth -= point;
            if (_spaceshipHealth <= 0)
            {
                Destroy();
            }
        }

        private void Heal(float point)
        {
            _spaceshipHealth += point;
            if (_spaceshipHealth >= _maxHealth.Health)
            {
                _spaceshipHealth = _maxHealth.Health;
            }
        }

        private void Destroy()
        {
            //тут будет событие. Пока не делали вьюшку.
        }
    }
}
