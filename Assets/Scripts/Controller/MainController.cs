using UnityEngine;


namespace Asteroids
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private GameCamera _camera;
        private ContactObjectsCenter _contactObjectsCenter;
        
        private SpaceshipInitialization _spaceshipInitialization;
        private AttackInitialization _attackInitialization;
        private EnemyPoolInitialization _enemyPoolInitialization;
        private MovementInitialization _movementInitialization;

        private void Awake()
        {
            var spaceshipFactory = new SpaceshipFactory(_data.SpaceshipData);
            var healthKeeper = new HealthKeeper(_data.SpaceshipData);
            _spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory, healthKeeper);
            _camera = new GameCamera(_spaceshipInitialization.GetTransform());
            var space = new World(_spaceshipInitialization.GetTransform(), _data.SpaceshipData);
            space.CreateWorld();
        
            _movementInitialization = new MovementInitialization(_spaceshipInitialization.GetTransform(),
                _data.SpaceshipData, _camera.WorldPosition);
        
            _attackInitialization = new AttackInitialization(_spaceshipInitialization.GetTransform(),
                _data.SpaceshipData, _data.BulletData);
        
            _enemyPoolInitialization = new EnemyPoolInitialization(_data.EnemyData,
                _spaceshipInitialization.GetTransform());
        }
        
        private void FixedUpdate()
        {
            _movementInitialization.FixedExecute(Time.deltaTime);
        }
        
        private void Update()
        {
            _attackInitialization.Execute(Time.deltaTime);
            _enemyPoolInitialization.Execute(Time.deltaTime);
        }
    }
}
