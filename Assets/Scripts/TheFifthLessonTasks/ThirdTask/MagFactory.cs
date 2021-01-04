using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public sealed class MagFactory : IUnit
    {
        public GameObject CreateUnit()
        {
            return GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
    }
}
