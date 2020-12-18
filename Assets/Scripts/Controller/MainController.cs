using UnityEngine;


namespace Asteroids
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private GameCamera _camera;

        private SpaceshipInitialization _spaceshipInitialization;
        private EnemyInitialization _enemyInitialization;

        private Transform _shotPoint;
        private InputMoveController _inputMoveController;
        private InputAttackController _inputAttackController;


        private void Awake()
        {
            var spaceshipFactory = new SpaceshipFactory(_data.SpaceshipData);
            var healthKeeper = new HealthKeeper(_data.SpaceshipData);
            _spaceshipInitialization = new SpaceshipInitialization(spaceshipFactory, healthKeeper);
            _camera = new GameCamera(_spaceshipInitialization.GetTransform());
            var space = new World(_spaceshipInitialization.GetTransform(), _data.SpaceshipData);
            space.CreateWorld();

            var barrel = new ShotPoint(_spaceshipInitialization.GetTransform(), _data.SpaceshipData);
            _shotPoint = barrel.GetShotPoint();
            var bulletFactory = new BulletFactory(_data.BulletData);
            _inputAttackController = new InputAttackController(bulletFactory, _data.BulletData, _data.BulletData);

            var moveTransform = new AccelerationMove(_spaceshipInitialization.GetTransform(),
                _data.SpaceshipData, _data.SpaceshipData);
            var rotation = new RotationSpaceship(_spaceshipInitialization.GetTransform());
            var movement = new SpaceshipMovement(moveTransform, rotation, _data.SpaceshipData);
            _inputMoveController = new InputMoveController(movement);

            var platform = new PlatformFactory().Create(Application.platform);
            
            var asteroidInitialization = new EnemyInitialization(
                new AsteroidFactory(_data.EnemyData), _data.EnemyData.AsteroidData);
            asteroidInitialization.GetEnemy();
            
            EnemyPool asteroidPool = new EnemyPool(_data.EnemyData.AsteroidData, _data.EnemyData);
            var asteroid = asteroidPool.GetEnemy(NameManager.NAME_ASTEROID);
            asteroid.transform.position = SpawnPlaces.FindPoint(
                _spaceshipInitialization.GetTransform().position, _data.EnemyData.SpawnDistance, _data.EnemyData.StartAngle, _data.EnemyData.FinishAngle);
            asteroid.gameObject.SetActive(true);
            
            asteroid.AddForce((_spaceshipInitialization.GetTransform().position - asteroid.transform.position) * _data.EnemyData.AsteroidData.Force);
            
            EnemyPool cometPool = new EnemyPool(_data.EnemyData.CometData, _data.EnemyData);
            var comet = cometPool.GetEnemy(NameManager.NAME_COMET);
            comet.transform.position = SpawnPlaces.FindPoint(
                _spaceshipInitialization.GetTransform().position, _data.EnemyData.SpawnDistance, _data.EnemyData.StartAngle, _data.EnemyData.FinishAngle);
            comet.gameObject.SetActive(true);
            
            comet.AddForce((_spaceshipInitialization.GetTransform().position - comet.transform.position) * _data.EnemyData.CometData.Force);
            
            EnemyPool hunterPool = new EnemyPool(_data.EnemyData.HunterData, _data.EnemyData);
            var hunter = hunterPool.GetEnemy(NameManager.NAME_HUNTER);
            hunter.transform.position = SpawnPlaces.FindPoint(
                _spaceshipInitialization.GetTransform().position, _data.EnemyData.SpawnDistance, _data.EnemyData.StartAngle, _data.EnemyData.FinishAngle);
            hunter.gameObject.SetActive(true);
            
            hunter.AddForce((_spaceshipInitialization.GetTransform().position - hunter.transform.position) * _data.EnemyData.HunterData.Speed);
        }

        private void FixedUpdate()
        {
            var direction = Input.mousePosition - _camera.WorldPosition;
            _inputMoveController.CheckInput(direction);
        }

        private void Update()
        {
            _inputAttackController.Shoot(_shotPoint);

            //_enemyInitialization.Execute(Time.deltaTime);
        }
    }
}
