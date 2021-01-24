using UnityEngine;

namespace TheFifthLessonTasks.Bridge
{
    internal sealed class Mag : IMove
    {
        public void Move()
        {
            Debug.Log("Mag is moving");
        }
    }
}
