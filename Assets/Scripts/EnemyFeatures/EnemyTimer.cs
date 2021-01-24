using System;
using static UnityEngine.Time;


namespace Asteroids
{
    public class EnemyTimer
    {
        public event Action<string> MakeAndPushEnemy;
        private float _startTime = 0.0f;
        private float _interval;

        public EnemyTimer(float interval)
        {
            _interval = interval;
        }

        public void TimeCounter(string name)
        {
            _startTime += deltaTime;
            if (_startTime > _interval)
            {
                _startTime = 0.0f;
                MakeAndPushEnemy?.Invoke(name);
            }
        }
    }
}
