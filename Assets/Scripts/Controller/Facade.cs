namespace Asteroids
{
    public sealed class Facade
    {
        private Controllers _controllers;

        public Facade(Data data, UIData uiData)
        {

            var contactCenter = new ContactCenter(data.EnemyData, data);
            var view = new DisplayInitialization(uiData);
            var spaceship = new SpaceshipController(data.SpaceshipData, contactCenter);
            var messageBroker = new MessageBroker(contactCenter, view, spaceship.SpaceshipHealthController);
      
            var worldInitialization = new WorldInitialization(data.SpaceshipData, spaceship.Spaceship);
            _controllers = new Controllers();
            _controllers.Add(spaceship);
            _controllers.Add(messageBroker);
            _controllers.Add(new TimeRemainingController());
            _controllers.Add(new PositionMemoryTimer(spaceship.Rigidbody));
            _controllers.Add(new MovementInitialization(spaceship.Spaceship, data.SpaceshipData,
                worldInitialization.Camera));
            _controllers.Add(new AttackInitialization(spaceship.Spaceship, data.SpaceshipData,
                data.BulletData, contactCenter));
            _controllers.Add(new EnemyPoolInitialization(data.EnemyData, spaceship.Spaceship, contactCenter));
            _controllers.Add(view);
            
            
        }

        public void FacadeInitialize() => _controllers.Initialize();
        public void FacadeFixedExecute(float deltaTime) => _controllers.FixedExecute(deltaTime);
        public void FacadeExecute(float deltaTime) => _controllers.Execute(deltaTime);
        public void FacadeCleanup() => _controllers.Cleanup();
    }
}
