using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/Bullet", order = 0)]
    public class BulletData : ScriptableObject, IForce
    {
        public Sprite BulletSprite;

        public float deltaX = 0.02f;
        public float deltaY = 0.4f;

        [SerializeField, Range(1, 100)] private float _bulletForce;

        public float BulletForce => _bulletForce;
    }
}
