using System.Collections.Generic;

namespace TheFifthLessonTasks.ThirdTask
{
    public class UnitComposite
    {
        public List<IUnit> Units = new List<IUnit>();
    
        public void AddUnit(IUnit unit)
        {
            Units.Add(unit);
        }

        public void AddManyUnits(IUnit[] units)
        {
            foreach (var u in units)
            {
                Units.Add(u);
            }
        }

        public void RemoveUnit(IUnit unit)
        {
            Units.Remove(unit);
        }

        public void GetUnit()
        {
            foreach (var unit in Units)
            {
                unit.CreateUnit();
            }
        }
    }
}
