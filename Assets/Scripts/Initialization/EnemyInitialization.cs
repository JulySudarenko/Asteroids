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
            _health = new Health(health.Health, health.Health);
        }
 
        public Rigidbody2D GetEnemy()
        {
            var enemy = _enemyFactory.CreateEnemy().GetComponent<Rigidbody2D>();
            return enemy;
        }

        //private Transform _target;
        //private Hunter _hunter;

        // public EnemyInitialization(Transform target, EnemyData enemyData, IEnemyFactory enemyFactory, IHealth health)
        // {
        //     _target = target;
        //     _enemyData = ScriptableObject.CreateInstance<EnemyData>();
        //
        // }

        // public void Execute(float deltaTime)
        // {
        // Vector3 direction = (_target.position - _hunter.transform.localPosition).normalized;
        // var speed = deltaTime * _enemyData.HunterSpeed;
        // _hunter.transform.position += direction * speed;
        // }

    }
}
