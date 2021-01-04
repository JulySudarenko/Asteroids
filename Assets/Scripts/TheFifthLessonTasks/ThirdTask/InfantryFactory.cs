using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public sealed class InfantryFactory : IUnit
    {
        public GameObject CreateUnit()
        {
            return GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
    }
}
