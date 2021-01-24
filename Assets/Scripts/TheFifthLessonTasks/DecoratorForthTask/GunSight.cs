using UnityEngine;

namespace TheFifthLessonTasks.Decorator
{
    internal sealed class GunSight : IGunSight
    {
        public Transform BarrelPositionGunSight { get; }
        public GameObject GunSightInstance { get; }

        public GunSight(Transform barrelPositionMuffler, GameObject mufflerInstance)
        {
            BarrelPositionGunSight = barrelPositionMuffler;
            GunSightInstance = mufflerInstance;
        }
    }
}
