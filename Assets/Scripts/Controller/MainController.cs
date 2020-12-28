using UnityEngine;


namespace Asteroids
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private AsteroidsData _asteroidsData;
        private Camera _camera;

        private ShotPoint _shotPoint;

        private SpaceshipInitialization _spaceshipInitialization;
        private InputMoveController _inputMoveController;
        private InputAttackController _inputAttackController;

        private void Awake()
        {
            var spaceshipFactory = new SpaceshipFactory(_asteroidsData.SpaceshipData);
            var healthKeeper = new HealthKeeper(_asteroidsData.SpaceshipData);
            _spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory, healthKeeper);
            _camera = Camera.main;

            var bulletFactory = new BulletFactory(_asteroidsData.BulletData);
            _inputAttackController = new InputAttackController(bulletFactory, _asteroidsData.BulletData);

            var moveTransform = new AccelerationMove(_spaceshipInitialization.GetTransform(),
                _asteroidsData.SpaceshipData,
                _asteroidsData.SpaceshipData);
            var rotation = new RotationSpaceship(_spaceshipInitialization.GetTransform());
            var movement = new SpaceshipMovement(moveTransform, rotation, _asteroidsData.SpaceshipData);
            _inputMoveController = new InputMoveController(movement);
            _shotPoint = new ShotPoint(_spaceshipInitialization.GetTransform(), _asteroidsData.BulletData);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _inputMoveController.CheckInput(direction);

            _inputAttackController.Shoot(_shotPoint.GetPoint(), direction);
        }
    }
}
