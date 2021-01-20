using UnityEngine;

namespace TheSixthLessonTasks.Patterns.CommandSecond
{
    internal abstract class BaseUi : MonoBehaviour
    {
        public abstract void Execute();

        public abstract void Cancel();
        //public abstract void Repeat();

        //....
    }
}


