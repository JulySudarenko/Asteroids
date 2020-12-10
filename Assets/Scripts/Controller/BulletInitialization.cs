using UnityEngine;


namespace Asteroids
{
    public class BulletInitialization
    {
        private IBulletFactory _bulletFactory;

        public BulletInitialization(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public GameObject GetBullet(Transform transform)
        {
            return _bulletFactory.CreateBullet().AddTransform(transform);
        }
    }
}
