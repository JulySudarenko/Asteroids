using UnityEngine;


namespace Asteroids
{
    public class HunterFactory : IEnemyFactory
    {
        private readonly EnemyData _enemyData;
        private const float _mass = 1.0f;

        public HunterFactory(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public GameObject CreateEnemy()
        {
            return new GameObject(NameManager.NAME_HUNTER)
                .AddSprite(_enemyData.HunterData.HunterSprite)
                .AddRigidbody2D(_mass)
                .AddTrackingSystem()
                .AddPoligonCollider2D();
        }
    }
}
