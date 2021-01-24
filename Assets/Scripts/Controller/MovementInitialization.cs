using UnityEngine;


namespace Asteroids
{
    public class MovementInitialization : IFixedExecute
    {
        private InputMoveController _inputMoveController;
        private Vector3 _cameraPosition;

        public MovementInitialization(Transform spaceship, SpaceshipData data, Vector3 cameraPosition)
        {
            var moveTransform = new AccelerationMove(spaceship, data, data);
            var rotation = new RotationSpaceship(spaceship);
            var movement = new SpaceshipMovement(moveTransform, rotation, data);
            _inputMoveController = new InputMoveController(movement);
            _cameraPosition = cameraPosition;
        }

        public void FixedExecute(float deltaTime)
        {
            var direction = Input.mousePosition - _cameraPosition;
            _inputMoveController.CheckInput(direction);
        }
    }
}
