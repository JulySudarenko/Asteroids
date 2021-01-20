using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "GameDisplay", menuName = "UI/GameDisplay", order = 0)]
    public class GameDisplayData : ScriptableObject
    {
        public GameObject GamePanel;
        public Text HealthPoints;
        public Text GamePoints;
        public Text HunterPoints;
    }
}
