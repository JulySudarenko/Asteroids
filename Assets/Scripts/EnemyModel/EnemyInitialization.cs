using UnityEngine;


namespace Asteroids
{
    public class EnemyInitialization
    {
        private IEnemyFactory _enemyFactory;
        private Health _health;
 
        public EnemyInitialization(IEnemyFactory enemyFactory, IHealth health)
        {
            _enemyFactory = enemyFactory;
            _health = new Health(health, health.Health);
        }
 
        public Rigidbody2D GetEnemy()
        {
            var enemy = _enemyFactory.CreateEnemy().GetComponent<Rigidbody2D>();
            return enemy;
        }


    }
}
