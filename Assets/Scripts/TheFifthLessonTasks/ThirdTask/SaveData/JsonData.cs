using System.Collections.Generic;
using System.IO;
using System.Linq;
using static TheFifthLessonTasks.ThirdTask.JsonHelper;

namespace TheFifthLessonTasks.ThirdTask
{
    public class JsonData<T> : IData<T>
    {
        public List<T> Load(string path = null)
        {
            var str = File.ReadAllText(path);
            string jsonString = FixJson(str);
            return JsonHelper.FromJson<T>(jsonString).ToList();
        }
    }
}
