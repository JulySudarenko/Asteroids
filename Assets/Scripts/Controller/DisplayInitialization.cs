namespace Asteroids
{
    public class DisplayInitialization : IIinitialize, IExecute
    {
        private MenuDisplayFactory _menuDisplayFactory;
        private GameDisplayFactory _gameDisplayFactory;
        private DisplayCommand _displayCommand;
        private DisplayHealthPoints _healthPoints;
        private DisplayGamePoints _gamePoints;
        private DisplayHunterMessage _hunterMessage;

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

            _displayCommand = new DisplayCommand(menuDisplayCommand, gameDisplayCommand,
                menuDisplayInitialization.GetPlayButton(), menuDisplayInitialization.GetQuitButton());
            _displayCommand.MakeStartPosition();
            _displayCommand.AddButtonsListener();

            _healthPoints = new DisplayHealthPoints(gameDisplayInitialization.GetHealthPointsText());
            _gamePoints = new DisplayGamePoints(gameDisplayInitialization.GetGamePointsText());
            _hunterMessage = new DisplayHunterMessage(gameDisplayInitialization.GetHunterPointsText());
        }

        public void ShowGameScore(string message)
        {
            _gamePoints.ShowGamePoints(message);
        }

        public void ShowHuntersDeathScore(string message)
        {
            _hunterMessage.ShowHunterMessage(message);
        }

        public void ShowPlayerHealth(string message)
        {
            _healthPoints.ShowHealthPoints(message);
        }

        public void Execute(float deltaTime)
        {
            _displayCommand.CheckInput();
        }
    }
}
