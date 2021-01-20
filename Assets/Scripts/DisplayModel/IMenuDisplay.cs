using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public interface IMenuDisplay
    {
        GameObject CreateMenuDisplay();
        Button CreatePlayButton();
        Button CreateQuitButton();
    }
}
