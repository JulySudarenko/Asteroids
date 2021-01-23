using UnityEngine;


namespace Asteroids
{
    public sealed class AsteroidFactory : IEnemyFactory
    {
        private readonly EnemyData _enemyData;
        private const float _mass = 1.0f;

        public AsteroidFactory(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public GameObject CreateEnemy()
        {
            return new GameObject(NameManager.NAME_ASTEROID)
                .AddSprite(_enemyData.AsteroidData.AsteroidSprite)
                .AddTrackingSystem()
                .AddRigidbody2D(_mass)
                .AddCircleCollider2D();
        }
    }
}
