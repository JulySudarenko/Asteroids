using System.Collections.Generic;

namespace TheFifthLessonTasks.ThirdTask
{
    public static class Extensions
    {
        public static T AddTo<T>(this T self, ICollection<T> coll)
        {
            coll.Add(self);
            return self;
        }
    }
}
