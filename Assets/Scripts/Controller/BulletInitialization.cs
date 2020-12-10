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

        public Transform GetBullet()
        {
            return _bulletFactory.CreateBullet().transform;
        }
    }
}
