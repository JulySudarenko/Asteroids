using UnityEngine;


namespace Asteroids
{
    public class AttackInitialization : IExecute
    {
        private InputAttackController _inputAttackController;
        private Transform _shotPoint;

        public AttackInitialization(Transform transform, 
            SpaceshipData spaceshipData, BulletData bulletData)
        {
            var barrel = new ShotPoint(transform, spaceshipData);
            _shotPoint = barrel.GetShotPoint();
            var bulletFactory = new BulletFactory(bulletData);

            _inputAttackController = new InputAttackController(bulletFactory, bulletData, bulletData);
        }

        public void Execute(float deltaTime)
        {
            _inputAttackController.Shoot(_shotPoint);
        }
    }
}
