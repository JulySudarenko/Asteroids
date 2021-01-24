using UnityEngine;

namespace TheFifthLessonTasks.Decorator
{
    internal sealed class ModificationGunSight : ModificationWeapon
    {
        private readonly IGunSight _gunSight;
        private Renderer _renderer;
        private readonly Vector3 _gunSightPosition;

        public ModificationGunSight(IGunSight gunSight,
            Vector3 mufflerPosition)
        {
            _gunSight = gunSight;
            _gunSightPosition = mufflerPosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            var gunSight = Object.Instantiate(_gunSight.GunSightInstance,
                _gunSightPosition, Quaternion.identity);
            _renderer = gunSight.GetComponent<Renderer>();
            return weapon;
        }

        public override void ActivateModification(Weapon weapon, AudioClip newClip, float volume)
        {
            if (_renderer.enabled)
            {
                _renderer.enabled = false;
            }
            else
            {
                _renderer.enabled = true;
            }
        }
    }
}
