using UnityEngine;

namespace Asteroids
{
    public sealed class GameDisplayCommand : MainUICommand
    {
        private GameObject _menuPanel;

        public GameDisplayCommand(GameObject panel)
        {
            _menuPanel = panel;
        }

        public override void Activate()
        {
            _menuPanel.SetActive(true);
        }

        public override void Cancel()
        {
            _menuPanel.SetActive(false);
        }
    }
}
