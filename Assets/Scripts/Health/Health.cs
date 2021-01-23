using UnityEngine;

namespace Asteroids
{
    public sealed class Health
    {
        private float _max;
        public float Current { get; private set; }

        public Health(IHealth max, float current)
        {
            _max = max.Health;
            Current = current;
        }
        
        public void CauseSpaceshipDamage(float power)
        {
            Current -= power;
            if (Current <= 0)
            {
                Debug.Log("Player is dead");
            }
            Debug.Log($"Spaceship health {Current}");
        }

        public void CauseEnemyDamage(Transform transform, float power)
        {
            Current -= power;
            if (Current <= 0)
            {
                Debug.Log($"{transform.name} is dead.");
            }
            Debug.Log($"{transform.name} health {Current}");
        }
    }
}
