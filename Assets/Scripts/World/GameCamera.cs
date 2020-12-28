using UnityEngine;


namespace Asteroids
{
    public class GameCamera
    {
        private Camera _camera;
        private Vector3 _worldPosition;
    
        public GameCamera(Transform player)
        {
            _camera = Camera.main;
            _camera.transform.parent = player;
            _worldPosition = _camera.WorldToScreenPoint(_camera.transform.position);
        }
        public Vector3 WorldPosition => _worldPosition;

    }
}
