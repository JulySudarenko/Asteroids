namespace Asteroids
{
    public sealed class Facade
    {
        private Controllers _controllers;
        private WorldInitialization _worldInitialization;

        public Facade(Data data)
        {
            _worldInitialization = new WorldInitialization(data.SpaceshipData);

            _controllers = new Controllers();
            _controllers.Add(new MovementInitialization(_worldInitialization.Spaceship, data.SpaceshipData,
                _worldInitialization.Camera));
            _controllers.Add(new AttackInitialization(_worldInitialization.Spaceship, data.SpaceshipData,
                data.BulletData));
            _controllers.Add(new EnemyPoolInitialization(data.EnemyData, _worldInitialization.Spaceship));
        }

        public void FacadeInitialize() => _controllers.Initialize();
        public void FacadeFixedExecute(float deltaTime) => _controllers.FixedExecute(deltaTime);
        public void FacadeExecute(float deltaTime) => _controllers.Execute(deltaTime);
        public void FacadeCleanup() => _controllers.Cleanup();
    }
}
