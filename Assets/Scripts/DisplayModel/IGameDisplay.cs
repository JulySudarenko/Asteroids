using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public interface IGameDisplay
    {
        GameObject CreateGamePanel();
        Text CreateHealthPointsText();
        Text CreateGamePointsText();
        Text CreateHunterPointsText();

    }
}
