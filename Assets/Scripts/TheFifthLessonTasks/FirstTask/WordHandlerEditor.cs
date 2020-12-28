using UnityEditor;
using UnityEngine;


namespace TheFifthLessonTasks.FirstTask
{
    [CustomEditor(typeof(WordHandler))]
    public class WordHandlerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (((WordHandler) target).modifyValues)
            {
                if (GUILayout.Button("Save changes"))
                {
                    ((WordHandler)target).DeserializeDictionary();
                }
            }

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            if (GUILayout.Button("Print Dictionary"))
            {
                ((WordHandler)target).PrintDictionary();
            }
        }
        

    }
}
