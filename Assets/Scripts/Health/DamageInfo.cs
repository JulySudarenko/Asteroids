namespace Asteroids
{
    public class DamageInfo
    {
        private IDamage _asteroidDamage;
        private IDamage _bulletDamage;

        public DamageInfo(Data data)
        {
            _asteroidDamage = data.EnemyData.AsteroidData;
        }
    }
}
