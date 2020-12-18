using System.IO;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private string _asteroidDataPath;
        [SerializeField] private string _cometDataPath;
        [SerializeField] private string _hunterDataPath;
        private AsteroidData _asteroidData;
        private CometData _cometData;
        private HunterData _hunterData;

        // [Header("Asteroids")] 
        // public Sprite AsteroidSprite;
        // [SerializeField, Range(1, 50)] private float _asteroidForce;
        // [SerializeField, Range(1, 200)] private float _asteroidHealth;
        // [SerializeField, Range(1, 50)] private int _asteroidPoolSize;
        //
        // [Header("Comet")] 
        // public Sprite CometSprite;
        // [SerializeField, Range(1, 50)] private float _cometForce;
        // [SerializeField, Range(1, 200)] private float _cometHealth;
        // [SerializeField, Range(1, 50)] private int _cometPoolSize;
        //
        // [Header("Hunter")] 
        // public Sprite HunterSprite;
        // [SerializeField, Range(1, 50)] private float _hunterSpeed;
        // [SerializeField, Range(1, 200)] private float _hunterHealth;

        [Header("Spawn Point")] 
        [SerializeField, Range(1, 50)] private float _radius;
        [SerializeField, Range(1, 360)] private int _startAngle;
        [SerializeField, Range(1, 360)] private int _finishAngle;


        // public float AsteroidForce => _asteroidForce;
        //
        // public float CometForce => _cometForce;
        //
        // public float HunterSpeed => _hunterSpeed;

        public float SpawnDistance => _radius;

        // public float AsteroidHealth => _asteroidHealth;
        //
        // public float CometHealth => _cometHealth;
        //
        // public float HunterHealth => _hunterHealth;
        //
        // public int AsteroidPoolSize => _asteroidPoolSize;

        public int StartAngle => _startAngle;

        public int FinishAngle => _finishAngle;

        public AsteroidData AsteroidData
        {
            get
            {
                if (_asteroidData == null)
                {
                    _asteroidData = Load<AsteroidData>("Data/" + _asteroidDataPath);
                }

                return _asteroidData;
            }
        }

        public CometData CometData
        {
            get
            {
                if (_cometData == null)
                {
                    _cometData = Load<CometData>("Data/" + _cometDataPath);
                }

                return _cometData;
            }
        }

        public HunterData HunterData
        {
            get
            {
                if (_hunterData == null)
                {
                    _hunterData = Load<HunterData>("Data/" + _hunterDataPath);
                }

                return _hunterData;
            }
        }


        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
