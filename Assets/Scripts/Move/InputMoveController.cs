using UnityEngine;
using static Asteroids.AxisManager;


namespace Asteroids
{
    public sealed class InputMoveController
    {
        private SpaceshipMovement _movement;

        public InputMoveController(SpaceshipMovement movement)
        {
            _movement = movement;
        }

        public void CheckInput(Vector3 direction)
        {
            _movement.Rotation(direction);

            _movement.Move(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL),
                Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _movement.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _movement.RemoveAcceleration();
            }
        }
    }
}
