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
        
        public void CauseDamage(float power)
        {
            Current -= power;
            if (Current <= 0)
            {
                Destroy();
            }
        }

        private void Destroy()
        {
            Debug.Log("Player is dead");
        }
    }
}
