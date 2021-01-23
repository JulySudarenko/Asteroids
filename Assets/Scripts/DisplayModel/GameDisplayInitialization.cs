using UnityEngine;
using UnityEngine.UI;

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
        
        public Text GetHealthPointsText()
        {
            return _gameDisplay.CreateHealthPointsText();
        }

        public Text GetGamePointsText()
        {
            return _gameDisplay.CreateGamePointsText();
        }
        
        public Text GetHunterPointsText()
        {
            return _gameDisplay.CreateHunterPointsText();
        }
    }
}
