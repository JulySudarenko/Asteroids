using UnityEngine;


namespace Asteroids
{
    public class AttackInitialization : IExecute, IIinitialize
    {
        private InputAttackControllerProxy _inputAttackController;
        private ShotPoint _barrel;
        private BulletFactory _bulletFactory;
        private Transform _shotPoint;
        private AttackLock _attackLock;
        private EnemyTimer _lockTimer;

        public AttackInitialization(Transform transform,
            SpaceshipData spaceshipData, BulletData bulletData, ContactCenter contactCenter)
        {
            _barrel = new ShotPoint(transform, spaceshipData);
            _bulletFactory = new BulletFactory(bulletData);
            
            _attackLock = new AttackLock(false);
            _inputAttackController = new InputAttackControllerProxy(
                new InputAttackController(_bulletFactory, bulletData, bulletData, contactCenter), _attackLock);
       }

        public void Initialize()
        {
            _shotPoint = _barrel.GetShotPoint();
            _inputAttackController.Shoot(_shotPoint);
            UnlockAttack();
        }

        public void Execute(float deltaTime)
        {
            _inputAttackController.Shoot(_shotPoint);
            
        }

        public void UnlockAttack()
        {
            _attackLock.IsUnlock = true;
        }
    }
}
