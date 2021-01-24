using UnityEngine;
using static Asteroids.BuildAssistant;

namespace TheFifthLessonTasks.ThirdTask
{
    public sealed class MagFactory : IFactory
    {
        public const string NAME = "mag";

        public GameObject CreateFactory()
        {
            return GameObject.CreatePrimitive(PrimitiveType.Sphere).AddName(NAME);
        }
    }
}
