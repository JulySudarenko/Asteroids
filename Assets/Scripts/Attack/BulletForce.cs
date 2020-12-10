

namespace Asteroids
{
    public class BulletForce
    {
        private IForce _bulletForce;

        public BulletForce(IForce force)
        {
            _bulletForce = force;
        }

        public float GetForce()
        {
            return _bulletForce.BulletForce;
        }
    }
}
