using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/Bullet", order = 0)]
    public class BulletData : ScriptableObject, IForce, IShotPoint
    {
        public Sprite BulletSprite;

        [SerializeField, Range(1, 5000)] private float _bulletForce;
        [SerializeField, Range(0, 3)] private float _shotPoint;

        public float BulletForce => _bulletForce;
        public float ShotPoint => _shotPoint;
    }
}
