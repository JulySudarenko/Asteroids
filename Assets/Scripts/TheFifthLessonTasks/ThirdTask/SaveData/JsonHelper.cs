using System;
using System.Linq;
using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Units;
        }

        public static string FixJson(string value)
        {
            //value = "{\"Units\":" + value + "}";
            value = String.Concat("{\"Units\":", value, "}");
            return value;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Units;
        }
    }
}
