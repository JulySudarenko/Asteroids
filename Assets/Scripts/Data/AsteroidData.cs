using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Asteroid", menuName = "Data/Asteroid", order = 0)]
    public class AsteroidData : ScriptableObject, IForce, IHealth, IPoolSize
    {
        public Sprite AsteroidSprite;

        [SerializeField, Range(1, 50)] private float _asteroidForce;
        [SerializeField, Range(1, 200)] private float _asteroidHealth;
        [SerializeField, Range(1, 50)] private int _asteroidPoolSize;


        public float Force => _asteroidForce;
        public float Health => _asteroidHealth;
        public int PoolSize => _asteroidPoolSize;
    }
}
