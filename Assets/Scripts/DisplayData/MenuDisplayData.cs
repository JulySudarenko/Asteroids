using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "MenuDisplay", menuName = "UI/MenuDisplay", order = 0)]
    public class MenuDisplayData : ScriptableObject
    {
        public GameObject MenuPanel;
        public Button PlayButton;
        public Button QuitButton;
    }
}
