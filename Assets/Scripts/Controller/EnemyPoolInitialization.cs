using UnityEngine;
using static Asteroids.NameManager;
using static Asteroids.SpawnPlaces;


namespace Asteroids
{
    public class EnemyPoolInitialization : IExecute
    {
        private EnemyData _data;

        private EnemyPool _asteroidPool;
        private EnemyPool _cometPool;
        private EnemyPool _hunterPool;
        private Rigidbody2D _asteroid;
        private Rigidbody2D _comet;
        private Rigidbody2D _hunter;
        private Transform _target;

        public EnemyPoolInitialization(EnemyData enemyData, Transform target)
        {
            _data = enemyData;
            _target = target;
            
            //_asteroidPool = new EnemyPool(_data.AsteroidData, _data);
            // _cometPool = new EnemyPool(_data.CometData, _data);
            // _hunterPool = new EnemyPool(_data.HunterData, _data);
            
            //_asteroid = InitializeEnemy(_asteroidPool, NAME_ASTEROID);
            // _comet = InitializeEnemy(_cometPool, NAME_COMET);
            //_hunter = InitializeEnemy(_hunterPool, NAME_HUNTER);
            // PushEnemy(_asteroid);
            // PushEnemy(_comet);

            // ServiceLocator.SetService<IService>(new Service());
            // ServiceLocator.Resolve<IService>().Test();

            ServiceLocator.SetService<IEnemyPool>(new EnemyPool(_data.AsteroidData, _data));
            // ServiceLocator.SetService<IEnemyPool>(new EnemyPool(_data.CometData, _data));
            // ServiceLocator.SetService<IEnemyPool>(new EnemyPool(_data.HunterData, _data));
            var asteroid = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_ASTEROID);
            asteroid.transform.position = GetStartPoint();
            asteroid.gameObject.SetActive(true);
            PushEnemy(asteroid);
            
            var comet = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_COMET);
            comet.transform.position = GetStartPoint();
            comet.gameObject.SetActive(true);
            PushEnemy(comet);
            
            _hunter = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_HUNTER);
            _hunter.transform.position = GetStartPoint();
            _hunter.gameObject.SetActive(true);
        }


        public void Execute(float deltaTime)
        {
            // var asteroid = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_ASTEROID);
            // asteroid.transform.position = GetStartPoint();
            // asteroid.gameObject.SetActive(true);
            // PushEnemy(asteroid);
            
            StartHunt(_hunter, deltaTime);

        }

        public Vector3 GetStartPoint()
        {
            return FindPoint(_target.position, _data.SpawnDistance, _data.StartAngle, _data.FinishAngle);
        }

        public Rigidbody2D InitializeEnemy(EnemyPool pool, string name)
        {
            var enemy = pool.GetEnemy(name);
            enemy.transform.position = GetStartPoint();
            enemy.gameObject.SetActive(true);
            return enemy;
        }

        public void PushEnemy(Rigidbody2D enemy)
        {
            enemy.AddForce((_target.position - enemy.transform.position) * _data.CometData.Force);
        }

        public void StartHunt(Rigidbody2D enemy, float deltaTime)
        {
            if ((enemy.transform.localPosition - _target.position).sqrMagnitude >=
                _data.HunterData.HunterStopDistance * _data.HunterData.HunterStopDistance)
            {
                Vector3 direction = (_target.position - enemy.transform.localPosition).normalized;
                var speed = deltaTime * _data.HunterData.Speed;
                enemy.transform.position += direction * speed;
            }
            else
            {
                _hunter.velocity = Vector2.zero;
            }
        }
    }
}
