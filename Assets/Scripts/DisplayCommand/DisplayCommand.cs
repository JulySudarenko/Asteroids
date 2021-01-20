using UnityEngine;

namespace Asteroids
{
    public class DisplayCommand
    {
        private MenuDisplayCommand _menuDisplayCommand;
        private GameDisplayCommand _gameDisplayCommand;
        private MainUICommand _currentWindow;

        public DisplayCommand(MenuDisplayCommand menuDisplayCommand, GameDisplayCommand gameDisplayCommand)
        {
            _menuDisplayCommand = menuDisplayCommand;
            _gameDisplayCommand = gameDisplayCommand;
        }
        
        public void MakeStartPosition()
        {
            _menuDisplayCommand.Activate();
            _gameDisplayCommand.Cancel();
            _currentWindow = _menuDisplayCommand;
            Time.timeScale = 0.0f;
        }

        public void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ChangePanel(StateUI.PanelOne);
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangePanel(StateUI.PanelTwo);
            }
        }
        
        private void ChangePanel(StateUI stateUI)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }

            switch (stateUI)
            {
                case StateUI.PanelOne:
                    _currentWindow = _menuDisplayCommand;
                    Time.timeScale = 0.0f;
                    break;
                case StateUI.PanelTwo:
                    _currentWindow = _gameDisplayCommand;
                    Time.timeScale = 1.0f;
                    break;
                default:
                    break;
            }
            
            _currentWindow.Activate();
        }
    }
}
