using UnityEngine;

namespace TheFifthLessonTasks.Bridge
{
    internal sealed class Infantry : IMove
    {
        public void Move()
        {
            Debug.Log("Infantry is moving");
        }
    }
}
