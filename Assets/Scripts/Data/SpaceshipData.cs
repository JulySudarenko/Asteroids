using UnityEngine;


namespace Asteroids
{
     [CreateAssetMenu(fileName = "Spaceship", menuName = "Data/Spaceship", order = 0)]
    public class SpaceshipData : ScriptableObject
    {
        public Transform SpaceshipTransform;
        public Mesh SpaceshipPrefab;
        [SerializeField, Range(1, 100)] private float _spaceshipHealth;
        [SerializeField, Range(1, 100)] private float _spaceshipSpeed;

        public float SpaceshipHealth => _spaceshipHealth;

        public float SpaceshipSpeed => _spaceshipSpeed;
    }
}