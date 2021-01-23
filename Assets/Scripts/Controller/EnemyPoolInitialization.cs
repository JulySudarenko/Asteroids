using UnityEngine;
using static Asteroids.NameManager;
using static Asteroids.SpawnPlaces;
using static Asteroids.BuildAssistant;


namespace Asteroids
{
    public class EnemyPoolInitialization : IIinitialize, IExecute, ICleanup
    {
        private const float INTERVAL = 5.0f;

        private EnemyData _data;
        private Rigidbody2D _hunter;
        private Transform _target;
        private ContactCenter _contactCenter;
        private TrackingContacts _contact;
        private EnemyTimer _asteroidTimer;
        private EnemyTimer _cometTimer;


        public EnemyPoolInitialization(EnemyData enemyData, Transform target, ContactCenter contactCenter)
        {
            _data = enemyData;
            _target = target;
            _contactCenter = contactCenter;
        }

        public void Initialize()
        {
            ServiceLocator.SetService<IEnemyPool>(new EnemyPool(_data));

            _hunter = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NAME_HUNTER);
            AddContactSystem(_hunter.gameObject);
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
            AddContactSystem(enemy.gameObject);
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

        private void AddContactSystem(GameObject gameObject)
        {
            _contactCenter.AddContactInfo(gameObject);
            _contact = gameObject.GetOrAddComponent<TrackingContacts>();
            _contact.CollisionHappend += _contactCenter.IdentifyCollisionInfo;
        }
            
        public void Cleanup()
        {
            _asteroidTimer.MakeAndPushEnemy -= InitializeEnemy;
            _cometTimer.MakeAndPushEnemy -= InitializeEnemy;
            _contact.CollisionHappend -= _contactCenter.IdentifyCollisionInfo;
        }

    }
}
