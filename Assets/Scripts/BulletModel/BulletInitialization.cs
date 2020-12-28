using UnityEngine;


namespace Asteroids
{
    public class BulletInitialization
    {
        private IBulletFactory _bulletFactory;
        private CollisionCenter _collisionCenter;

        public BulletInitialization(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _collisionCenter = new CollisionCenter();
        }

        public Rigidbody2D GetBullet()
        {
            var bullet = _bulletFactory.CreateBullet().GetComponent<Rigidbody2D>();
            GameObject o = bullet.gameObject;
            _collisionCenter.DependencyInjectionHealth(o);
            return bullet;
        }
    }
}
