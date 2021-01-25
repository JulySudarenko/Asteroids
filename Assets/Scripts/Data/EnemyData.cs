using static Asteroids.Extentions;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy", order = 0)]
    public class EnemyData : ScriptableObject, ISpawnPoint
    {
        [SerializeField] private string _asteroidDataPath;
        [SerializeField] private string _cometDataPath;
        [SerializeField] private string _hunterDataPath;
        private AsteroidData _asteroidData;
        private CometData _cometData;
        private HunterData _hunterData;

        [Header("Spawn Point")] 
        [SerializeField, Range(1, 50)] private float _radius;
        [SerializeField, Range(1, 360)] private int _startAngle;
        [SerializeField, Range(1, 360)] private int _finishAngle;

        public float SpawnDistance => _radius;

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
    }
}
