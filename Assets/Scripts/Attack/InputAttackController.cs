using UnityEngine;
using static Asteroids.AxisManager;


namespace Asteroids
{
    public class InputAttackController
    {
        private BulletInitialization _bulletInitialization;
        private IForce _force;

        public InputAttackController(BulletFactory bulletFactory, IForce force)
        {
            _bulletInitialization = new BulletInitialization(bulletFactory);
            _force = force;
        }

        public void Shoot(Transform point)
        {
            if (Input.GetButtonDown(FIRE))
            {
                var bullet = _bulletInitialization.GetBullet(point);
                var rigidbody = bullet.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(bullet.transform.up * _force.BulletForce);
                    //надо пули делать дешевле :)
                    //уничтожать или менять позицию и видимость.
            }
        }
    }
}
