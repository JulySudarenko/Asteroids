using UnityEngine;

namespace Asteroids
{
    public class GameDisplayInitialization
    {
        private IGameDisplay _gameDisplay;

        public GameDisplayInitialization(IGameDisplay gameDisplay)
        {
            _gameDisplay = gameDisplay;
        }

        public GameObject GetGamePanel()
        {
            return _gameDisplay.CreateGamePanel();
        }
        
        public void CreateGameDisplay()
        {
            _gameDisplay.CreateHealthPointsText();
            _gameDisplay.CreateGamePointsText();
            _gameDisplay.CreateHunterPointsText();
        }

    }
}
