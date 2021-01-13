using UnityEngine;
using static Asteroids.BuildAssistant;

namespace TheFifthLessonTasks.ThirdTask
{
    public sealed class InfantryFactory : IFactory
    {
        public const string NAME = "infantry";

        public GameObject CreateFactory()
        {
            return GameObject.CreatePrimitive(PrimitiveType.Cube).AddName(NAME);
        }
    }
}
