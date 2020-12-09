using System.IO;
using UnityEngine;


namespace Asteroids
{
    public class Data
    {
        [CreateAssetMenu(fileName = "Data", menuName = "Data/AsteroidsData")]
        public class AsteroidsData : ScriptableObject
        {
            [SerializeField] private string _playerDataPath;
            private SpaceshipData _spaceshipData;
        
            public SpaceshipData SpaceshipData
            {
                get
                {
                    if (_spaceshipData == null)
                    {
                        _spaceshipData = Load<SpaceshipData>("Data/" + _playerDataPath);
                    }

                    return _spaceshipData;
                }
            }
        
            private T Load<T>(string resourcesPath) where T : Object =>
                Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        }
    }
}
