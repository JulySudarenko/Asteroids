using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Spaceship", menuName = "Data/Spaceship", order = 0)]
    public class SpaceshipData : ScriptableObject, ISpeed, IHealth, IAcceleration, IShotPoint, IWorld, IPower
    {
        public Transform SpaceshipTransform;

        public Sprite SpaceshipSprite;
        [SerializeField] private Transform _stars;
        [SerializeField] private Transform _shotPoint;
        [SerializeField, Range(1, 100)] private float _spaceshipHealth;
        [SerializeField, Range(1, 50)] private float _spaceshipSpeed;
        [SerializeField, Range(1, 50)] private float _spaceshipAcceleration;
        [SerializeField, Range(1, 1000)] private float _spaceshipPower;

        public Transform Stars => _stars;
        public Transform ShotPoint => _shotPoint;
        
        public float Health => _spaceshipHealth;

        public float Speed => _spaceshipSpeed;

        public float Acceleration => _spaceshipAcceleration;
        public float Power => _spaceshipPower;


    }
}
