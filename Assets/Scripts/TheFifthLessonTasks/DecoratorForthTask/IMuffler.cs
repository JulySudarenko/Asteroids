using UnityEngine;


namespace TheFifthLessonTasks.Decorator
{
    internal interface IMuffler
    {
        AudioClip AudioClipMuffler { get; }
        float VolumeFireOnMuffler { get; }

        Transform BarrelPositionMuffler { get; }
        GameObject MufflerInstance { get; }
    }
}
