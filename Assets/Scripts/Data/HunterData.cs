using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Hunter", menuName = "Data/Hunter", order = 0)]
    public class HunterData : ScriptableObject, ISpeed, IHealth, IPoolSize, IPower, IPoints
    {
        public Sprite HunterSprite;
        [SerializeField, Range(1, 50)] private float _hunterSpeed;
        [SerializeField, Range(1, 200)] private float _hunterHealth;
        [SerializeField, Range(1, 100)] private float _hunterPower;
        [SerializeField, Range(1, 5000)] private float _hunterPoints;
        [SerializeField, Range(1, 10)] private float _hunterStopDistance;
        [SerializeField, Range(1, 10)] private int _hunterPoolSize;

        public float Speed => _hunterSpeed;
        
        public float Health => _hunterHealth;

        public float Power => _hunterPower;
        
        public float Points => _hunterPoints;

        public float HunterStopDistance => _hunterStopDistance;

        public int PoolSize => _hunterPoolSize;
        
    }
}
