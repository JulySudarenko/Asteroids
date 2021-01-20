using UnityEngine;


namespace Asteroids
{
    public class BulletInitialization
    {
        private IBulletFactory _bulletFactory;
        private ContactObjectsCenter _contactObjectsCenter;

        public BulletInitialization(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _contactObjectsCenter = new ContactObjectsCenter();
        }

        public Rigidbody2D GetBullet()
        {
            var bullet = _bulletFactory.CreateBullet().GetComponent<Rigidbody2D>();
            _contactObjectsCenter.AddContactInfo(bullet.gameObject);
            return bullet;
        }
    }
}
