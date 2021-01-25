

namespace Asteroids
{
    public class DisplayInitialization : IIinitialize, IExecute, ICleanup
    {
        private MenuDisplayFactory _menuDisplayFactory;
        private GameDisplayFactory _gameDisplayFactory;
        private ContactCenter _contactCenter;
        private MessageBroker _messageBroker;
        private DisplayCommand _displayCommand;
        private DisplayHealthPoints _healthPoints;
        private DisplayGamePoints _gamePoints;
        private DisplayHunterMessage _hunterMessage;

        public DisplayInitialization(UIData data, ContactCenter contactCenter, MessageBroker messageBroker)
        {
            _menuDisplayFactory = new MenuDisplayFactory(data.MenuDisplayData, data);
            _gameDisplayFactory = new GameDisplayFactory(data.GameDisplayData, data);
            _contactCenter = contactCenter;
            _messageBroker = messageBroker;
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
            _hunterMessage=new DisplayHunterMessage(gameDisplayInitialization.GetHunterPointsText());

            _contactCenter.TransferPointsOnScreen += _gamePoints.ShowGamePoints;
            _messageBroker.SendMessage += _hunterMessage.ShowHunterMessage;
        }

        public void Execute(float deltaTime)
        {
            _displayCommand.CheckInput();
        }

        public void Cleanup()
        {
            _contactCenter.TransferPointsOnScreen -=_gamePoints.ShowGamePoints;
            _messageBroker.SendMessage -= _hunterMessage.ShowHunterMessage;
        }
    }
}
