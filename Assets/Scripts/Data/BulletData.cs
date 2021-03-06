﻿using UnityEngine;
using UnityEngine.Serialization;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/Bullet", order = 0)]
    public class BulletData : ScriptableObject, IForce, IPoolSize, IDamage
    {
        public Sprite BulletSprite;

        [SerializeField, Range(1, 5000)] private float _bulletForce;
        [SerializeField, Range(1, 100)] private float _bulletDamage;
        [SerializeField, Range(1, 50)] private int _bulletPoolSize;

        public float Force => _bulletForce;
        public float Damage => _bulletDamage;

        public int PoolSize => _bulletPoolSize;
    }
}
