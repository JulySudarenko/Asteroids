using UnityEngine;
using UnityEngine.Serialization;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [FormerlySerializedAs("_asteroidSprite")] [Header("Asteroids")] 
        public Sprite AsteroidSprite;
        [SerializeField, Range(1, 50)] private float _asteroidForce = 5.0f;
        [SerializeField, Range(1, 50)] private int _asteroidPoolSize = 5;
        [FormerlySerializedAs("_cometSprite")] [Header("Comet")] 
        public Sprite CometSprite;
        [SerializeField, Range(1, 50)] private float _cometForce = 7.0f;
        [FormerlySerializedAs("_hunterSprite")] [Header("Hunter")] 
        public Sprite HunterSprite;
        [SerializeField, Range(1, 50)] private float _hunterSpeed = 7.0f;
        [Header("Spawn Point")]
        [SerializeField, Range(1, 50)] private float _radius = 10.0f;
        [SerializeField, Range(1, 360)] private int _startAngle = 1;
        [SerializeField, Range(1, 360)] private int _finishAngle = 180;


        public float AsteroidForce => _asteroidForce;

        public float CometForce => _cometForce;

        public float HunterSpeed => _hunterSpeed;
        public float SpawnDistance => _radius;

        public int AsteroidPoolSize => _asteroidPoolSize;

        public int StartAngle => _startAngle;

        public int FinishAngle => _finishAngle;
    }
}

