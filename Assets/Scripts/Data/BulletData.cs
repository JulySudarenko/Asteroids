using UnityEngine;
using UnityEngine.Serialization;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/Bullet", order = 0)]
    public class BulletData : ScriptableObject, IForce, IPoolSize
    {
        public Sprite BulletSprite;

        [SerializeField, Range(1, 5000)] private float _force;
        [SerializeField, Range(1, 50)] private int _bulletPoolSize;

        public float Force => _force;

        public int PoolSize => _bulletPoolSize;
    }
}
