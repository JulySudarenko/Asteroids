using UnityEngine;


namespace Asteroids
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private AsteroidsData _asteroidsData;
        private GameCamera _camera;

        private SpaceshipInitialization _spaceshipInitialization;
        private EnemyInitialization _enemyInitialization;

        private Transform _shotPoint;
        private InputMoveController _inputMoveController;
        private InputAttackController _inputAttackController;


        private void Awake()
        {
            var spaceshipFactory = new SpaceshipFactory(_asteroidsData.SpaceshipData);
            var healthKeeper = new HealthKeeper(_asteroidsData.SpaceshipData);
            _spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory, healthKeeper);
            _camera = new GameCamera(_spaceshipInitialization.GetTransform());
            var space = new World(_spaceshipInitialization.GetTransform(), _asteroidsData.SpaceshipData);
            space.CreateWorld();

            var barrel = new ShotPoint(_spaceshipInitialization.GetTransform(), _asteroidsData.SpaceshipData);
            _shotPoint = barrel.GetShotPoint();
            var bulletFactory = new BulletFactory(_asteroidsData.BulletData);
            _inputAttackController = new InputAttackController(bulletFactory, _asteroidsData.BulletData, _asteroidsData.BulletData);

            var moveTransform = new AccelerationMove(_spaceshipInitialization.GetTransform(),
                _asteroidsData.SpaceshipData,
                _asteroidsData.SpaceshipData);
            var rotation = new RotationSpaceship(_spaceshipInitialization.GetTransform());
            var movement = new SpaceshipMovement(moveTransform, rotation, _asteroidsData.SpaceshipData);
            _inputMoveController = new InputMoveController(movement);

            var platform = new PlatformFactory().Create(Application.platform);

            _enemyInitialization = new EnemyInitialization(_spaceshipInitialization.GetTransform(), _asteroidsData.EnemyData);
            _enemyInitialization.Initialize();
        }

        private void FixedUpdate()
        {
            var direction = Input.mousePosition - _camera.WorldPosition;
            _inputMoveController.CheckInput(direction);
        }

        private void Update()
        {
            _inputAttackController.Shoot(_shotPoint);

            _enemyInitialization.Execute(Time.deltaTime);
        }
    }
}
