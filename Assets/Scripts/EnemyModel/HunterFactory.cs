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

        public Enemy Create(Health hp)
        {
            Enemy enemy = new GameObject(NameManager.NAME_HUNTER)
                .AddSprite(_enemyData.HunterSprite)
                .AddRigidbody2D(_mass)
                .AddPoligonCollider2D()
                .AddComponent<Hunter>();

            enemy.Health = hp;
            return enemy;
        }
    }
}
