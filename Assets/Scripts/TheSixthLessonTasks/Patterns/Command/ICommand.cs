using UnityEngine;

namespace TheSixthLessonTasks.Patterns.Command
{
    public interface ICommand
    {
        bool Succeeded { get; }
        bool Execute(Transform box);
        void Undo(Transform box);
    }
}
