using UnityEngine;
using static Asteroids.AxisManager;


namespace Asteroids
{
    public sealed class InputController
    {
        //private Camera _camera;
        private SpaceshipMovement _movement;

        public InputController(SpaceshipMovement movement)
        {
            //_camera = camera;
            _movement = movement;
        }

        public void CheckInput(Vector3 direction)
        {
            // var direction = Input.mousePosition -
            //                 _camera.WorldToScreenPoint(transform.position);
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
