using UnityEngine;
using static Asteroids.NameManager;
using static Asteroids.SpawnPlaces;


namespace Asteroids
{
    public class EnemyPoolInitialization : IExecute
    {
        private EnemyPool _asteroidPool;
        private EnemyPool _cometPool;
        private EnemyPool _hunterPool;
        private EnemyData _data;
        private Transform _target;
        private Rigidbody2D _asteroid;
        private Rigidbody2D _comet;
        private Rigidbody2D _hunter;

        public EnemyPoolInitialization(EnemyData enemyData, Transform target)
        {
            _data = enemyData;
            _target = target;
            _asteroidPool = new EnemyPool(_data.AsteroidData, _data);
            _cometPool = new EnemyPool(_data.CometData, _data);
            _hunterPool = new EnemyPool(_data.HunterData, _data);

            _asteroid = InitializeEnemy(_asteroidPool, NAME_ASTEROID);
            _comet = InitializeEnemy(_cometPool, NAME_COMET);
            _hunter = InitializeEnemy(_hunterPool, NAME_HUNTER);

            PushEnemy(_asteroid);
            PushEnemy(_comet);
        }


        public void Execute(float deltaTime)
        {
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
            Vector3 direction = (_target.position - enemy.transform.localPosition).normalized;
            var speed = deltaTime * _data.HunterData.Speed;
            enemy.transform.position += direction * speed;
        }
    }
}
