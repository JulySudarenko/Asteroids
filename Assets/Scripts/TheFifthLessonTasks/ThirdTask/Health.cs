namespace TheFifthLessonTasks.ThirdTask
{
    public class Health
    {
        private float _health;

        public Health(float health)
        {
            _health = health;
        }

        public override string ToString()
        {
            return $"{_health}";
        }
    }
}
