using UnityEngine;
using static Asteroids.AxisManager;


namespace Asteroids
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private AsteroidsData _asteroidsData;
        private Camera _camera;
        
        private BulletFactory _bulletFactory;
        private BulletForce _force;
        
        private SpaceshipMovement _movement;
        private InputController _inputController;

        private void Awake()
        {
            var spaceshipFactory = new SpaceshipFactory(_asteroidsData.SpaceshipData);
            var spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory);
            _camera = Camera.main;

            _bulletFactory = new BulletFactory(spaceshipInitialization.GetTransform(), _asteroidsData.BulletData);
            _force = new BulletForce(_asteroidsData.BulletData);

            var moveTransform = new AccelerationMove(spaceshipInitialization.GetTransform(),
                _asteroidsData.SpaceshipData,
                _asteroidsData.SpaceshipData);
            var rotation = new RotationSpaceship(spaceshipInitialization.GetTransform());
            var movement = new SpaceshipMovement(moveTransform, rotation, _asteroidsData.SpaceshipData);
            _inputController = new InputController(movement);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _inputController.CheckInput(direction);

            if (Input.GetButtonDown(FIRE))
            {
                var bulletInitialization = new BulletInitialization(_bulletFactory);
                var temAmmunition = bulletInitialization.GetBullet();
                var rig = temAmmunition.GetComponent<Rigidbody2D>();
                //Instantiate(_bullet, _barrel.position,
                //    _barrel.rotation);
                rig.AddForce(temAmmunition.transform.up * _force.GetForce());
            }
        }
    }
}
