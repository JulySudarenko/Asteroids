using System.Collections.Generic;

namespace TheFifthLessonTasks.ThirdTask
{
    public class UnitComposite
    {
        private List<IUnit> _units = new List<IUnit>();

        public void AddUnit(IUnit unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(IUnit unit)
        {
            _units.Remove(unit);
        }

        public void GetUnit()
        {
            foreach (var unit in _units)
            {
                unit.CreateUnit();
            }
        }
    }
}
