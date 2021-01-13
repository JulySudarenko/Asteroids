using System;
using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    [Serializable]
    public sealed class SavedData
    {
        public UnitsData unit;

        public void Print()=> Debug.Log(unit.ToString());
    }

    [Serializable]
    public struct UnitsData
    {
        public string type;
        public float health;

        public UnitsData(string type, float health)
        {
            this.type = type;
            this.health = health;
        }
        public override string ToString() => $"Type {type} Health {health}";
    }
}
