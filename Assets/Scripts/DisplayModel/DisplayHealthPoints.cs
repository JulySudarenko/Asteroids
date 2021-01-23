using UnityEngine.UI;

namespace Asteroids
{
    public class DisplayHealthPoints
    {
        private readonly Text _healthPointsLabel;

        public DisplayHealthPoints(Text text)
        {
            _healthPointsLabel = text;
        }

        public void ShowHealthPoints(float health)
        {
            _healthPointsLabel.text = $"Health points: {health}";
        }
    }
}
