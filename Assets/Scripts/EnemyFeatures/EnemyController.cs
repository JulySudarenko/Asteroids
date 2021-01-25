using UnityEngine;

namespace Asteroids
{
    internal abstract class EnemyController
    {
        private ISpawnPoint _spawnPoint;
        private Transform _target;

        public EnemyController(ISpawnPoint spawnPoint, Transform target)
        {
            _spawnPoint = spawnPoint;
            _target = target;
        }

        public abstract void InitializeEnemy();
        public abstract void ExecuteEnemy(float deltaTime);

        protected Vector3 GetStartPoint()
        {
            return SpawnPlaces.FindPoint(_target.position, _spawnPoint.SpawnDistance, _spawnPoint.StartAngle,
                _spawnPoint.FinishAngle);
        }
    }
}
