using UnityEngine;

namespace TheFifthLessonTasks.Proxy
{
    internal sealed class ExampleProxy : MonoBehaviour
    {
        private void Start()
        {
            var unlockWeapon = new UnlockWeapon(false);
            var weapon = new Weapon();
            var weaponProxy = new WeaponProxy(weapon, unlockWeapon);
            weaponProxy.Fire();
            unlockWeapon.IsUnlock = true;
            weaponProxy.Fire();
        }
    }
}
