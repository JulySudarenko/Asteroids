using UnityEngine;

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

        public void CreateMainMenu()
        {
            _menuDisplay.CreatePlayButton();
            _menuDisplay.CreateQuitButton();
        }
    }
}
