using UnityEngine.UI;

namespace Asteroids
{
    public sealed class DisplayHunterMessage
    {
        private readonly Text _hinterMessageLabel;

        public DisplayHunterMessage(Text text)
        {
            _hinterMessageLabel = text;
        }

        public void ShowHunterMessage(string message)
        {
            _hinterMessageLabel.text = message;
        }
    }
}
