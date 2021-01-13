using System.Collections.Generic;

namespace TheFifthLessonTasks.ThirdTask
{
    public interface IData<T>
    {
        List<T> Load(string path = null);
    }
}
