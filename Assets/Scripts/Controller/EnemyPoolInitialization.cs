using UnityEngine;
using static Asteroids.NameManager;
using static Asteroids.SpawnPlaces;


namespace Asteroids
{
    public class EnemyPoolInitialization : IIinitialize, IExecute, ICleanup
    {
        private const float INTERVAL = 5.0f;
        
        private EnemyData _data;
        private Rigidbody2D _hunter;
        private Transform _target;
        private EnemyTimer _asteroidTimer;
        private EnemyTimer _cometTimer;


        public EnemyPoolInitialization(EnemyData enemyData, Transform target)
        {
            _data = enemyData;
            _target = target;
        }

        public void Initialize()
        {
            ServiceLocator.SetService<IEnemyPool>(new EnemyPool(_data));

            _hunter = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_HUNTER);
            _hunter.transform.position = GetStartPoint();
            _hunter.gameObject.SetActive(true);
            
            _asteroidTimer = new EnemyTimer(INTERVAL);
            _cometTimer = new EnemyTimer(INTERVAL);
            _asteroidTimer.MakeAndPushEnemy += InitializeEnemy;
            _cometTimer.MakeAndPushEnemy += InitializeEnemy;
        }


        public void Execute(float deltaTime)
        {
            _asteroidTimer.TimeCounter(NAME_ASTEROID);
            _cometTimer.TimeCounter(NAME_COMET);
            StartHunt(_hunter, deltaTime);
        }

        private void InitializeEnemy(string name)
        {
            var enemy = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(name);
            enemy.transform.position = GetStartPoint();
            enemy.gameObject.SetActive(true);
            enemy.AddForce((_target.position - enemy.transform.position) * _data.CometData.Force);
        }

        public Vector3 GetStartPoint()
        {
            return FindPoint(_target.position, _data.SpawnDistance, _data.StartAngle, _data.FinishAngle);
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

        public void Cleanup()
        {
            _asteroidTimer.MakeAndPushEnemy -= InitializeEnemy;
            _cometTimer.MakeAndPushEnemy -= InitializeEnemy;
        }
    }
}
