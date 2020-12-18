using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Comet", menuName = "Data/Comet", order = 0)]
    public class CometData : ScriptableObject, IForce, IHealth, IPoolSize
    {
        public Sprite CometSprite;
        [SerializeField, Range(1, 50)] private float _cometForce;
        [SerializeField, Range(1, 200)] private float _cometHealth;
        [SerializeField, Range(1, 50)] private int _cometPoolSize;


        public float Force => _cometForce;
        public float Health => _cometHealth;
        public int PoolSize => _cometPoolSize;
    }
}
