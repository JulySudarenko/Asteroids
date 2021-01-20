using UnityEngine;

namespace TheSixthLessonTasks.Patterns.Command
{
    internal sealed class DoNothing : ICommand
    {
        public bool Succeeded { get; private set; }

        public bool Execute(Transform box)
        {
            Succeeded = true;
            return Succeeded;
        }

        public void Undo(Transform box)
        {
        }
    }
}
