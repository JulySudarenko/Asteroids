using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class SpaceshipHealthController
    {
        public Action<string> HeathOnScreen;

        private Health _health;

        public SpaceshipHealthController(IHealth health)
        {
            _health = new Health(health, health.Health);
            HeathOnScreen?.Invoke(_health.Current.ToString());
        }

        public void CauseSpaceshipDamage(float damage)
        {
            var health = _health.Current;
            health -= damage;
            if (health <= 0)
            {
                health = 0f;
                Debug.Log("Player is dead");
            }

            _health.ChangeCurrentHealth(health);
            HeathOnScreen?.Invoke(health.ToString());
        }

        public void HealthModifier(float bonus)
        {
            var health = _health.Current;
            health += bonus;
            if (health > _health.MAXHealth)
            {
                health = _health.MAXHealth;
            }
            
            _health.ChangeCurrentHealth(health);
            HeathOnScreen?.Invoke(health.ToString());
        }
    }
}
