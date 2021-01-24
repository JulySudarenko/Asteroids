using UnityEngine;

namespace TheFifthLessonTasks.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;

        protected abstract Weapon AddModification(Weapon weapon);
        public abstract void ActivateModification(Weapon weapon, AudioClip newClip, float volume);

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
