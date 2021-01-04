using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public class ThirdTaskComposite : MonoBehaviour
    {
        public void Start()
        {
            IUnit infantry = new InfantryFactory();
            IUnit mag = new MagFactory();
            Unit unitInfantry = new Unit(infantry, 100.0f, 100.0f);
            Unit unitMag = new Unit(mag, 50, 50);
            UnitComposite units = new UnitComposite();
            units.AddUnit(infantry);
            units.AddUnit(mag);
            units.AddUnit(new InfantryFactory());
            units.GetUnit();
        }
    }
}
