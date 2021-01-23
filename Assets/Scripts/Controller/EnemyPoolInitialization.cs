using UnityEngine;
using static Asteroids.NameManager;
using static Asteroids.SpawnPlaces;

namespace Asteroids
{
    public class EnemyPoolInitialization : IIinitialize, IExecute
    {
        private float AsteroidAddTime = 4.0f;
        private float CometAddTime = 3.0f;
        private float HunterAddTime = 10.0f;

        private EnemyData _data;
        private Rigidbody2D _hunter;
        private Transform _target;
        private ContactCenter _contactCenter;
        private ITimeRemaining _timeRemaining;

        public EnemyPoolInitialization(EnemyData enemyData, Transform target, ContactCenter contactCenter)
        {
            _data = enemyData;
            _target = target;
            _contactCenter = contactCenter;
        }

        public void Initialize()
        {
            ServiceLocator.SetService<IEnemyPool>(new EnemyPool(_data, _contactCenter));

            ActivateHunter();
            _timeRemaining = new TimeRemaining(InitializeAsteroid, AsteroidAddTime, true);
            _timeRemaining.AddTimeRemaining();
            _timeRemaining = new TimeRemaining(InitializeComet, CometAddTime, true);
            _timeRemaining.AddTimeRemaining();
        }

        public void Execute(float deltaTime)
        {
            StartHunt(_hunter, deltaTime);
        }

        private void InitializeAsteroid()
        {
            var enemy = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_ASTEROID);
            enemy.transform.position = GetStartPoint();
            enemy.gameObject.SetActive(true);
            enemy.AddForce((_target.position - enemy.transform.position) * _data.AsteroidData.Force);
        }
        
        private void InitializeComet()
        {
            var enemy = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_COMET);
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
                Vector3 direction = (_target.position - enemy.transform.localPosition).normalized;
                var speed = deltaTime * _data.HunterData.Speed;
                enemy.transform.position += direction * speed;
        }

        public void ActivateHunter()
        {
            _hunter = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_HUNTER);
            _hunter.gameObject.SetActive(true);
        }
    }
}
