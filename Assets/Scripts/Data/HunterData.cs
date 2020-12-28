using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Hunter", menuName = "Data/Hunter", order = 0)]
    public class HunterData : ScriptableObject, ISpeed, IHealth, IPoolSize
    {
        public Sprite HunterSprite;
        [SerializeField, Range(1, 50)] private float _hunterSpeed;
        [SerializeField, Range(1, 200)] private float _hunterHealth;
        [SerializeField, Range(1, 10)] private int _hunterPoolSize;

        public float Speed => _hunterSpeed;
        
        public float Health => _hunterHealth;

        public int PoolSize => _hunterPoolSize;
    }
}
