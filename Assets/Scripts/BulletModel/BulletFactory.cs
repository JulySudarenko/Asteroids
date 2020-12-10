using UnityEngine;


namespace Asteroids
{
    public class BulletFactory : IBulletFactory
    {
        private BulletData _bulletData;
        private Transform _bulletTransform;
        private float _mass = 1.0f;

        public BulletFactory(Transform spaceshipTransform, BulletData bulletData)
        {
            _bulletData = bulletData;
            // _bulletTransform.position = new Vector3(
            //     spaceshipTransform.position.x + bulletData.deltaX, 
            //     spaceshipTransform.position.y + bulletData.deltaY, 
            //     spaceshipTransform.position.z);
        }
        
        public GameObject CreateBullet()
        {
            return new GameObject()
                .AddSprite(_bulletData.BulletSprite)
                .AddRigidbody2D(_mass)
                .AddTransform(_bulletTransform);
        }
    }
}
