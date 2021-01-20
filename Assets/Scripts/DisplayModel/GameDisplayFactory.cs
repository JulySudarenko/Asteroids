using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class GameDisplayFactory : IGameDisplay
    {
        private readonly GameDisplayData _data;
        private Canvas _canvas;
        private GameObject _panel;

        public GameDisplayFactory(GameDisplayData data, ICanvas canvas)
        {
            _data = data;
            _canvas = canvas.Canvas;
        }
        
        public GameObject CreateGamePanel()
        {
            _panel = Object.Instantiate(_data.GamePanel, _canvas.transform);
            return _panel;
        }

        public Text CreateHealthPointsText()
        {
            var text = Object.Instantiate(_data.HealthPoints, _panel.transform);
            return text;
        }

        public Text CreateGamePointsText()
        {
            var text = Object.Instantiate(_data.GamePoints, _panel.transform);
            return text;
        }

        public Text CreateHunterPointsText()
        {
            var text = Object.Instantiate(_data.HunterPoints, _panel.transform);
            return text;
        }
    }
}
