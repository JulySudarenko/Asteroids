using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TheFifthLessonTasks.Decorator
{
    public class ExampleDecoratorGunSight : MonoBehaviour
    {
        [Header("Start Gun")] [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")] [SerializeField]
        private AudioClip _audioClipMuffler;

        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        [Header("Gun Sight")] [SerializeField] private Transform _barrelGunSight;
        [SerializeField] private GameObject _gunSight;

        private IFire _fire;
        private Weapon _weaponOnStage;
        private ModificationWeapon _modificationWeapon;
        private ModificationWeapon _modificationGunSight;
        private float _weaponVolume;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _weaponOnStage = new Weapon(ammunition, _barrelPosition, 2000.0f,
                _audioSource, _audioClip);
            _weaponVolume = _audioSource.volume;
            var mufflerOnStage = new Muffler(_audioClipMuffler, _volumeFireOnMuffler,
                _barrelPosition, _muffler);
            var gunSightOnStage = new GunSight(_barrelGunSight, _gunSight);
            _modificationWeapon = new
                ModificationMuffler(_audioSource, mufflerOnStage, _barrelPositionMuffler.position);
            _modificationWeapon.ApplyModification(_weaponOnStage);
            _modificationGunSight = new ModificationGunSight(gunSightOnStage, _barrelGunSight.position);
            _modificationGunSight.ApplyModification(_weaponOnStage);
            _fire = _modificationWeapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _modificationGunSight.ActivateModification(_weaponOnStage, _audioClip, _weaponVolume);
            }
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                _modificationWeapon.ActivateModification(_weaponOnStage, _audioClip, _weaponVolume);
            }
        }
    }
}
