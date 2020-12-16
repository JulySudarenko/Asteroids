using UnityEngine;


namespace Asteroids
{
    public class EnemyInitialization
    {
        private Transform _target;
        private EnemyData _enemyData;

        public EnemyInitialization(Transform target)
        {
            _target = target;
            _enemyData = ScriptableObject.CreateInstance<EnemyData>();
        }

        public void Initialize()
        {
            
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            Enemy.CreateCometEnemy(new Health(50.0f, 50.0f));

            IEnemyFactory asteroidFactory = new AsteroidFactory();
            asteroidFactory.Create(new Health(100.0f, 100.0f));

            IEnemyFactory cometFactory = new CometFactory();
            cometFactory.Create(new Health(50.0f, 50.0f));

            Enemy.Factory = new AsteroidFactory();
            Enemy.Factory.Create(new Health(100.0f, 100.0f));

            Enemy.Factory = new CometFactory();
            Enemy.Factory.Create(new Health(50.0f, 50.0f));

            EnemyPool enemyPool = new EnemyPool(_enemyData.AsteroidPoolSize);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = SpawnPlaces.FindPoint(
                _target.position, _enemyData.SpawnDistance, _enemyData.StartAngle, _enemyData.FinishAngle);
            enemy.gameObject.SetActive(true);
            var rigidbody = enemy.GetComponent<Rigidbody2D>();
            rigidbody.AddForce((_target.position - enemy.transform.position) * _enemyData.AsteroidForce);
        }

        public void Execute()
        {
            EnemyPool enemyPool = new EnemyPool(_enemyData.AsteroidPoolSize);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = SpawnPlaces.FindPoint(
                _target.position, _enemyData.SpawnDistance, _enemyData.StartAngle, _enemyData.FinishAngle);
            enemy.gameObject.SetActive(true);
            var rigidbody = enemy.GetComponent<Rigidbody2D>();
            rigidbody.AddForce((_target.position - enemy.transform.position) * _enemyData.AsteroidForce);
        }
    }
}
