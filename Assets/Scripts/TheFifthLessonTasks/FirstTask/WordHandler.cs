using System.Collections.Generic;
using UnityEngine;


namespace TheFifthLessonTasks.FirstTask
{
    public class WordHandler : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField] private WordHandlerScriptableObject _wordHandlerData;

        [SerializeField] private List<string> _keys = new List<string>();

        [SerializeField] private List<int> _values = new List<int>();

        private Dictionary<string, int> _someWords = new Dictionary<string, int>();

        public List<string> Keys => _keys;
        public List<int> Values => _values;

        public bool modifyValues;

        private void Awake()
        {
            for (int i = 0; i < Mathf.Min(_wordHandlerData.Keys.Count, _wordHandlerData.Values.Count); i++)
            {
                _someWords.Add(_wordHandlerData.Keys[i], _wordHandlerData.Values[i]);
            }
        }

        #region ISerializationCallbackReceiver

        public void OnBeforeSerialize()
        {
            if (modifyValues == false)
            {
                _keys.Clear();
                _values.Clear();
                for (int i = 0; i < Mathf.Min(_wordHandlerData.Keys.Count, _wordHandlerData.Values.Count); i++)
                {
                    _keys.Add(_wordHandlerData.Keys[i]);
                    _values.Add(_wordHandlerData.Values[i]);
                }
            }
        }

        public void OnAfterDeserialize()
        {
        }

        #endregion

        public void DeserializeDictionary()
        {
            Debug.Log("DESERIALIZATION");
            _someWords = new Dictionary<string, int>();
            _wordHandlerData.Keys.Clear();
            _wordHandlerData.Values.Clear();

            for (int i = 0; i < Mathf.Min(_keys.Count, _values.Count); i++)
            {
                _wordHandlerData.Keys.Add(_keys[i]);
                _wordHandlerData.Values.Add(_values[i]);
                _someWords.Add(_keys[i], _values[i]);
            }
        }
        
        public void PrintDictionary()
        {
            foreach (var pair in _someWords)
            {
                Debug.Log($"Key: {pair.Key}, value {pair.Value}");
            }
        }
    }
}
