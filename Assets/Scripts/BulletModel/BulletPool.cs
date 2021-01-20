﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Asteroids.NameManager;
using static Asteroids.TimeRemainingExtensions;
using Object = UnityEngine.Object;


namespace Asteroids
{
    public sealed class BulletPool
    {
        private Action _reloadingBullet;
        
        private readonly Dictionary<string, HashSet<Rigidbody2D>> _bulletPool;
        private BulletInitialization _bulletInitialization;
        private ITimeRemaining _timeRemaining;
        private Transform _rootPool;
        private readonly int _capacityPool;

        
        public BulletPool(BulletFactory bulletFactory, int capacityPool)
        {
            _timeRemaining = new TimeRemaining(_reloadingBullet, 5);
            _reloadingBullet += ReloadBullet;
            _bulletPool = new Dictionary<string, HashSet<Rigidbody2D>>();
            _bulletInitialization = new BulletInitialization(bulletFactory);
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new
                    GameObject(POOL_AMMUNITION).transform;
            }
        }

        public Rigidbody2D GetBullet(string type)
        {
            Rigidbody2D result;
            switch (type)
            {
                case "Bullet":
                    result = GetBullet(GetListBullets(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type,
                        "Не предусмотрен в программе");
            }
        
            return result;
        }

        private HashSet<Rigidbody2D> GetListBullets(string type)
        {
            return _bulletPool.ContainsKey(type) ? _bulletPool[type] : _bulletPool[type] = new HashSet<Rigidbody2D>();
        }

        private Rigidbody2D GetBullet(HashSet<Rigidbody2D> bullets)
        {
            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = _bulletInitialization.GetBullet();
                    ReturnToPool(instantiate.transform);
                    _timeRemaining.AddTimeRemaining();
                    bullets.Add(instantiate);
                }
                GetBullet(bullets);
            }
        
            bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }
 
        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }

        private void ReloadBullet()
        {
            Debug.Log("Time is over.");
        }
    }
}
