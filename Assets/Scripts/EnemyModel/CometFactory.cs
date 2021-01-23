using UnityEngine;


namespace Asteroids
{
    public class CometFactory : IEnemyFactory
    {
        private readonly EnemyData _enemyData;
        private const float _mass = 1.0f;

        public CometFactory(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }
 
        public GameObject CreateEnemy()
        {
            return new GameObject(NameManager.NAME_COMET)
                .AddSprite(_enemyData.CometData.CometSprite)
                .AddTrackingSystem()
                .AddRigidbody2D(_mass)
                .AddCircleCollider2D();
        }
    }
}
