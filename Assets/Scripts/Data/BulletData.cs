using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/Bullet", order = 0)]
    public class BulletData : ScriptableObject, IForce
    {
        public Sprite BulletSprite;

        [SerializeField, Range(1, 5000)] private float _bulletForce;
        [SerializeField, Range(1, 50)] private int _bulletPoolSize;

        public float BulletForce => _bulletForce;

        public int BulletPoolSize => _bulletPoolSize;
    }
}
