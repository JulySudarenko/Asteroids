using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class MenuDisplayInitialization
    {
        private IMenuDisplay _menuDisplay;

        public MenuDisplayInitialization(IMenuDisplay menuDisplay)
        {
            _menuDisplay = menuDisplay;
        }

        public GameObject GetMenuPanel()
        {
            return _menuDisplay.CreateMenuDisplay();
        }

        public Button GetPlayButton()
        {
            return _menuDisplay.CreatePlayButton();
        }

        public Button GetQuitButton()
        {
            return _menuDisplay.CreateQuitButton();
        }
    }
}
