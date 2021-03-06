﻿using UnityEngine;
using static Asteroids.AxisManager;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class InputAttackController
    {
        private BulletPool _bulletPool;
        private IForce _force;
        private IPoolSize _capacityPool;

        public InputAttackController(BulletFactory bulletFactory, IForce force, IPoolSize poolSize)
        {
            _force = force;
            _capacityPool = poolSize;
            _bulletPool = new BulletPool(bulletFactory, _capacityPool.PoolSize);
        }

        public void Shoot(Transform shotPoint)
        {
            if (Input.GetButtonDown(FIRE))
            {
                var bullet = _bulletPool.GetBullet(NAME_AMMUNITION);
                bullet.gameObject.AddTransform(shotPoint);
                bullet.gameObject.SetActive(true);
                bullet.AddForce(shotPoint.up * _force.Force);
            }
        }
    }
}
