using UnityEngine;

namespace TheFifthLessonTasks.Proxy
{
    public sealed class Weapon : IWeapon
    {
        public void Fire()
        {
            Debug.Log("Fire");
        }
    }
}
