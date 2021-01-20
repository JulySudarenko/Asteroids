namespace Asteroids
{
    public class DisplayInitialization : IIinitialize, IExecute
    {
        private MenuDisplayFactory _menuDisplayFactory;
        private GameDisplayFactory _gameDisplayFactory;
        private DisplayCommand _displayCommand;

        public DisplayInitialization(UIData data)
        {
            _menuDisplayFactory = new MenuDisplayFactory(data.MenuDisplayData, data);
            _gameDisplayFactory = new GameDisplayFactory(data.GameDisplayData, data);
        }

        public void Initialize()
        {
            var menuDisplayInitialization = new MenuDisplayInitialization(_menuDisplayFactory);
            var gameDisplayInitialization = new GameDisplayInitialization(_gameDisplayFactory);

            var gameDisplayCommand = new GameDisplayCommand(gameDisplayInitialization.GetGamePanel());
            var menuDisplayCommand = new MenuDisplayCommand(menuDisplayInitialization.GetMenuPanel());

            _displayCommand = new DisplayCommand(menuDisplayCommand, gameDisplayCommand);
            _displayCommand.MakeStartPosition();

            menuDisplayInitialization.CreateMainMenu();
            gameDisplayInitialization.CreateGameDisplay();
        }

        public void Execute(float deltaTime)
        {
            _displayCommand.CheckInput();
        }
    }
}
