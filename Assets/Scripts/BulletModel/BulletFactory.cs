using UnityEngine;


namespace Asteroids
{
    public class BulletFactory : IBulletFactory
    {
        private BulletData _bulletData;
        private string _name = "Bullet";
        private float _mass = 1.0f;

        public BulletFactory(BulletData bulletData)
        {
            _bulletData = bulletData;
        }
        
        public GameObject CreateBullet()
        {
            return new GameObject(_name)
                .AddSprite(_bulletData.BulletSprite)
                .AddCircleCollider2D()
                .AddRigidbody2D(_mass);
        }
    }
}
