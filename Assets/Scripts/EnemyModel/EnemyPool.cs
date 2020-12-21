using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Asteroids.NameManager;
using Object = UnityEngine.Object;


namespace Asteroids
{
    public sealed class EnemyPool : IEnemyPool
    {
        private readonly Dictionary<string, HashSet<Rigidbody2D>> _enemyPool;
        private EnemyInitialization _asteroidInitialization;
        private EnemyInitialization _cometInitialization;
        private EnemyInitialization _hunterInitialization;
        private readonly IPoolSize _capacityPool;
        private Transform _rootPool;

        public EnemyPool(IPoolSize poolSize, EnemyData enemyData)
        {
            _enemyPool = new Dictionary<string, HashSet<Rigidbody2D>>();
            _capacityPool = poolSize;
            if (!_rootPool)
            {
                _rootPool = new
                    GameObject(POOL_ENEMIES).transform;
            }
            _asteroidInitialization = new EnemyInitialization(new AsteroidFactory(enemyData), enemyData.AsteroidData);
            _cometInitialization = new EnemyInitialization(new CometFactory(enemyData), enemyData.CometData);
            _hunterInitialization = new EnemyInitialization(new HunterFactory(enemyData), enemyData.HunterData);
        }

        public Rigidbody2D GetEnemy(string type)
        {
            Rigidbody2D result;
            switch (type)
            {
                case NAME_ASTEROID:
                    result = ActivateEnemy(GetListEnemies(type), _asteroidInitialization, _capacityPool.PoolSize);
                    break;
                case NAME_COMET:
                    result = ActivateEnemy(GetListEnemies(type), _cometInitialization, _capacityPool.PoolSize);
                    break;
                case NAME_HUNTER:
                    result = ActivateEnemy(GetListEnemies(type), _hunterInitialization, _capacityPool.PoolSize);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type,
                        "Не предусмотрен в программе");
            }
        
            return result;
        }

        private HashSet<Rigidbody2D> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Rigidbody2D>();
        }

        private Rigidbody2D ActivateEnemy(HashSet<Rigidbody2D> enemies, EnemyInitialization initialize, int poolSize)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                for (var i = 0; i < poolSize; i++)
                {
                    var instantiate = initialize.GetEnemy();
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }
            
                ActivateEnemy(enemies, initialize, poolSize);
            }
            
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
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
    }
}
