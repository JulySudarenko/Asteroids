using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "Asteroid", menuName = "Data/Asteroid", order = 0)]
    public class AsteroidData : ScriptableObject, IForce, IHealth, IPoolSize, IPower, IPoints
    {
        public Sprite AsteroidSprite;

        [SerializeField, Range(1, 50)] private float _asteroidForce;
        [SerializeField, Range(1, 200)] private float _asteroidHealth;
        [SerializeField, Range(1, 100)] private float _asteroidPower;
        [SerializeField, Range(1, 5000)] private float _asteroidPoints;
        [SerializeField, Range(1, 50)] private int _asteroidPoolSize;


        public float Force => _asteroidForce;
        public float Health => _asteroidHealth;
        public float Power => _asteroidPower;
        public float Points => _asteroidPoints;
        public int PoolSize => _asteroidPoolSize;
    }
}
