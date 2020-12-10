using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Spaceship", menuName = "Data/Spaceship", order = 0)]
    public class SpaceshipData : ScriptableObject, ISpeed, IHealth, IAcceleration
    {
        public Transform SpaceshipTransform;
        public Sprite SpaceshipSprite;
        [SerializeField, Range(1, 100)] private float _spaceshipHealth;
        [SerializeField, Range(1, 50)] private float _spaceshipSpeed;
        [SerializeField, Range(1, 50)] private float _spaceshipAcceleration;
           
        public float Health => _spaceshipHealth;

        public float Speed => _spaceshipSpeed;

        public float Acceleration => _spaceshipAcceleration;
    }
}
