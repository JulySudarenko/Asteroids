using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class DisplayCommand
    {
        private MenuDisplayCommand _menuDisplayCommand;
        private GameDisplayCommand _gameDisplayCommand;
        private Button _playButoon;
        private Button _quitButton;
        private MainUICommand _currentWindow;

        public DisplayCommand(MenuDisplayCommand menuDisplayCommand, GameDisplayCommand gameDisplayCommand,
            Button playButton, Button quitButton)
        {
            _menuDisplayCommand = menuDisplayCommand;
            _gameDisplayCommand = gameDisplayCommand;
            _playButoon = playButton;
            _quitButton = quitButton;
        }

        public void MakeStartPosition()
        {
            _menuDisplayCommand.Activate();
            _gameDisplayCommand.Cancel();
            _currentWindow = _menuDisplayCommand;
            Time.timeScale = 0.0f;
        }

        public void AddButtonsListener()
        {
            _playButoon.onClick.AddListener(ChangePanelOnClick);
            _quitButton.onClick.AddListener(Exit);
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

        private void ChangePanelOnClick()
        {
            ChangePanel(StateUI.PanelTwo);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
