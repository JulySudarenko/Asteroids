using System.IO;
using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/AsteroidsData")]
    public class AsteroidsData : ScriptableObject
    {
        [SerializeField] private string _spaceshipDataPath;
        [SerializeField] private string _bulletDataPath;
        [SerializeField] private string _enemyDataPath;
        private SpaceshipData _spaceshipData;
        private BulletData _bulletData;
        private EnemyData _enemyData;

        public SpaceshipData SpaceshipData
        {
            get
            {
                if (_spaceshipData == null)
                {
                    _spaceshipData = Load<SpaceshipData>("Data/" + _spaceshipDataPath);
                }

                return _spaceshipData;
            }
        }

        public BulletData BulletData
        {
            get
            {
                _bulletData = Load<BulletData>("Data/" + _bulletDataPath);
                return _bulletData;
            }
        }
        
        public EnemyData EnemyData
        {
            get
            {
                _enemyData = Load<EnemyData>("Data/" + _enemyDataPath);
                return _enemyData;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
