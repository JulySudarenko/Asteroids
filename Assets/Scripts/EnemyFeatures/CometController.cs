using UnityEngine;

namespace Asteroids
{
    internal sealed class CometController : EnemyController
    {
        private Transform _target;
        private IForce _force;

        public CometController(ISpawnPoint spawnPoint, IForce forse, Transform target) : base(spawnPoint, target)
        {
            _target = target;
            _force = forse;
        }

        public override void InitializeEnemy()
        {
            var enemy = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NameManager.NAME_COMET);
            enemy.transform.position = GetStartPoint();
            enemy.gameObject.SetActive(true);
            enemy.AddForce((_target.position - enemy.transform.position) * _force.Force);
        }

        public override void ExecuteEnemy(float deltaTime)
        {
        }
    }
}
