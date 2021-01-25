namespace Asteroids
{
    public sealed class Facade
    {
        private Controllers _controllers;

        public Facade(Data data, UIData uiData)
        {
            var messageBroker = new MessageBroker();
            var contactCenter = new ContactCenter(data.EnemyData, data, messageBroker);

            var worldInitialization = new WorldInitialization(data.SpaceshipData, contactCenter);

            
            _controllers = new Controllers();
            _controllers.Add(new TimeRemainingController());
            _controllers.Add(worldInitialization);
            _controllers.Add(contactCenter);
            _controllers.Add(new MovementInitialization(worldInitialization.Spaceship, data.SpaceshipData,
                worldInitialization.Camera));
            _controllers.Add(new AttackInitialization(worldInitialization.Spaceship, data.SpaceshipData,
                data.BulletData, contactCenter));
            _controllers.Add(new EnemyPoolInitialization(data.EnemyData, worldInitialization.Spaceship, contactCenter));
            _controllers.Add(new DisplayInitialization(uiData, contactCenter, messageBroker));
        }

        public void FacadeInitialize() => _controllers.Initialize();
        public void FacadeFixedExecute(float deltaTime) => _controllers.FixedExecute(deltaTime);
        public void FacadeExecute(float deltaTime) => _controllers.Execute(deltaTime);
        public void FacadeCleanup() => _controllers.Cleanup();
    }
}
