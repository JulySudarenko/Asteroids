using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class MenuDisplayFactory : IMenuDisplay
    {
        private readonly MenuDisplayData _data;
        private Canvas _canvas;
        private GameObject _panel;

        public MenuDisplayFactory(MenuDisplayData data, ICanvas canvas)
        {
            _data = data;
            _canvas = canvas.Canvas;
        }

        public GameObject CreateMenuDisplay()
        {
            _panel = Object.Instantiate(_data.MenuPanel, _canvas.transform);
            return _panel;
        }
        
        public Button CreatePlayButton()
        {
            var play = Object.Instantiate(_data.PlayButton, _panel.transform);
            return play;
        }
        
        public Button CreateQuitButton()
        {
            var quit = Object.Instantiate(_data.QuitButton, _panel.transform);
            return quit;
        }
    }
}
