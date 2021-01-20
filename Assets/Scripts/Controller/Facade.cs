namespace Asteroids
{
    public sealed class Facade
    {
        private Controllers _controllers;

        public Facade(Data data, UIData uiData)
        {
            var worldInitialization = new WorldInitialization(data.SpaceshipData);

            _controllers = new Controllers();
            _controllers.Add(new MovementInitialization(worldInitialization.Spaceship, data.SpaceshipData,
                worldInitialization.Camera));
            _controllers.Add(new AttackInitialization(worldInitialization.Spaceship, data.SpaceshipData,
                data.BulletData));
            _controllers.Add(new EnemyPoolInitialization(data.EnemyData, worldInitialization.Spaceship));
            _controllers.Add(new DisplayInitialization(uiData));
        }

        public void FacadeInitialize() => _controllers.Initialize();
        public void FacadeFixedExecute(float deltaTime) => _controllers.FixedExecute(deltaTime);
        public void FacadeExecute(float deltaTime) => _controllers.Execute(deltaTime);
        public void FacadeCleanup() => _controllers.Cleanup();
    }
}
