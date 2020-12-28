using System.Collections.Generic;
using UnityEngine;


namespace TheFifthLessonTasks.FirstTask
{
    [CreateAssetMenu(fileName = "WordHandler", menuName = "Data/WordHandler", order = 0)]
    public class WordHandlerScriptableObject : ScriptableObject
    {
        [SerializeField] private List<string> _keys = new List<string>();

        [SerializeField] private List<int> _values = new List<int>();

        public List<string> Keys => _keys;
        public List<int> Values => _values;
    }
}
