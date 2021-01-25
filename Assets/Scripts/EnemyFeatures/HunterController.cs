using UnityEngine;

namespace Asteroids
{
    internal class HunterController : EnemyController
    {
        private Rigidbody2D _hunter;
        private Transform _target;
        private ISpeed _speed;

        public HunterController(ISpawnPoint spawnPoint, ISpeed speed, Transform target) : base(spawnPoint, target)
        {
            _target = target;
            _speed = speed;

            _hunter = ServiceLocator.Resolve<IEnemyPool>().GetEnemy(NameManager.NAME_HUNTER);
            var abilityController = new AbilityController();
            abilityController.AbilityDemonstration();
        }

        public override void InitializeEnemy()
        {
            if (!_hunter.gameObject.activeSelf)
            {
                _hunter.transform.position = GetStartPoint();
                _hunter.gameObject.SetActive(true);
            }
        }

        public override void ExecuteEnemy(float deltaTime)
        {
            Vector3 direction = (_target.position - _hunter.transform.localPosition).normalized;
            var speed = deltaTime * _speed.Speed;
            _hunter.transform.position += direction * speed;
        }
    }
}
