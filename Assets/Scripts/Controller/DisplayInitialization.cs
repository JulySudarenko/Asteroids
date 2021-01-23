

namespace Asteroids
{
    public class DisplayInitialization : IIinitialize, IExecute, ICleanup
    {
        private MenuDisplayFactory _menuDisplayFactory;
        private GameDisplayFactory _gameDisplayFactory;
        private ContactCenter _contactCenter;
        private DisplayCommand _displayCommand;
        private DisplayHealthPoints _healthPoints;
        private DisplayGamePoints _gamePoints;

        public DisplayInitialization(UIData data, ContactCenter contactCenter)
        {
            _menuDisplayFactory = new MenuDisplayFactory(data.MenuDisplayData, data);
            _gameDisplayFactory = new GameDisplayFactory(data.GameDisplayData, data);
            _contactCenter = contactCenter;
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
            gameDisplayInitialization.GetHunterPointsText();

            _contactCenter.TransferPointsOnScreen += ShowGamePoints;
        }

        public void Execute(float deltaTime)
        {
            _displayCommand.CheckInput();
        }

        private void ShowGamePoints(string points)
        {
            _gamePoints.ShowGamePoints(points);
        }

        public void Cleanup()
        {
            _contactCenter.TransferPointsOnScreen -= ShowGamePoints;
        }
    }
}
