using UnityEngine;

namespace Asteroids
{
    public class EnemyPoolInitialization : IIinitialize, IExecute
    {
        private EnemyController _asteroidController;
        private EnemyController _cometController;
        private EnemyController _hunterController;

        private ITimeRemaining _timeRemaining;

        private float _asteroidAddTime = 4.0f;
        private float _cometAddTime = 3.0f;
        private float _hunterAddTime = 10.0f;

        public EnemyPoolInitialization(EnemyData enemyData, Transform target, ContactCenter contactCenter)
        {
            ServiceLocator.SetService<IEnemyPool>(new EnemyPool(enemyData, contactCenter));
            _hunterController = new HunterController(enemyData, enemyData.HunterData, target);
            _asteroidController = new AsteroidController(enemyData, enemyData.AsteroidData, target);
            _cometController = new CometController(enemyData, enemyData.CometData, target);
        }

        public void Initialize()
        {
            _timeRemaining = new TimeRemaining(_hunterController.InitializeEnemy, _hunterAddTime, true);
            _timeRemaining.AddTimeRemaining();

            _timeRemaining = new TimeRemaining(_asteroidController.InitializeEnemy, _asteroidAddTime, true);
            _timeRemaining.AddTimeRemaining();

            _timeRemaining = new TimeRemaining(_cometController.InitializeEnemy, _cometAddTime, true);
            _timeRemaining.AddTimeRemaining();
        }

        public void Execute(float deltaTime)
        {
            _hunterController.ExecuteEnemy(deltaTime);
        }
    }
}
