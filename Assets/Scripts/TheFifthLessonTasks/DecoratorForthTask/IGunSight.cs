using UnityEngine;

namespace TheFifthLessonTasks.Decorator
{
    internal interface IGunSight
    {
        Transform BarrelPositionGunSight { get; }
        GameObject GunSightInstance { get; }
    }
}
