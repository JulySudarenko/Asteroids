using UnityEngine;

namespace TheFifthLessonTasks.Bridge
{
    internal sealed class Archer : IMove
    {
        public void Move()
        {
            Debug.Log("Archer is moving");
        }
    }
}
