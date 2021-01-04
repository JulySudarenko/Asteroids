using System;
using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public class Unit
    {
        private IUnit _unitFactory;
        private Health _health;
 
        public Unit(IUnit unitFactory, float max, float current)
        {
            _unitFactory = unitFactory;
            _health = new Health(max, current);
        }
 
        public GameObject GetUnit()
        {
            return _unitFactory.CreateUnit();
        }
    }
}
