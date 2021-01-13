using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public class UnitFactory : IUnit
    {
        private readonly IFactory _factory;
        private readonly Health _health;

        public UnitFactory(IFactory factoryFactory, float health)
        {
            _factory = factoryFactory;
            _health = new Health(health);
        }

        public GameObject CreateUnit()
        {
            var unit = _factory.CreateFactory();
            Debug.Log($"{unit.name} {_health}");
            return unit;
        }
    }
}
