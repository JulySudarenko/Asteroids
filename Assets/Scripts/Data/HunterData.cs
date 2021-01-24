using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Hunter", menuName = "Data/Hunter", order = 0)]
    public class HunterData : ScriptableObject, ISpeed, IHealth, IPoolSize, IDamage
    {
        public Sprite HunterSprite;
        [SerializeField, Range(1, 50)] private float _hunterSpeed;
        [SerializeField, Range(1, 200)] private float _hunterHealth;
        [SerializeField, Range(1, 100)] private float _hunterDamage;
        [SerializeField, Range(1, 10)] private float _hunterStopDistance;
        [SerializeField, Range(1, 10)] private int _hunterPoolSize;

        public float Speed => _hunterSpeed;
        
        public float Health => _hunterHealth;

        public float Damage => _hunterDamage;

        public float HunterStopDistance => _hunterStopDistance;

        public int PoolSize => _hunterPoolSize;
        
    }
}
