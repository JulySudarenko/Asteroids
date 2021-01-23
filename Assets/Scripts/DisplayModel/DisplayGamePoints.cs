using UnityEngine.UI;

namespace Asteroids
{
    public class DisplayGamePoints
    {
        private readonly Text _gamePointsLabel;

        public DisplayGamePoints(Text text)
        {
            _gamePointsLabel = text;
        }

        public void ShowGamePoints(string points)
        {
            _gamePointsLabel.text = $"Points: {points}";
        }
    }
}
