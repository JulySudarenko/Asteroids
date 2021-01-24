using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public class ThirdTaskComposite : MonoBehaviour
    {
        public void Start()
        {
            var saveDataRepository = new SaveDataRepository();
            var units = new UnitComposite();

            IFactory infantry = new InfantryFactory();
            IFactory mag = new MagFactory();

            IUnit unitInf = new UnitFactory(infantry, 97.0f);
            IUnit unitM = new UnitFactory(mag, 95.0f);

            UnitFactory unitInfantry = new UnitFactory(infantry, 100.0f);
            UnitFactory unitMag = new UnitFactory(mag, 50.0f);

            units.AddUnit(unitInf);
            units.AddUnit(unitM);

            units.AddUnit(unitInfantry);
            units.AddUnit(unitMag);

            units.AddUnit(new UnitFactory(new MagFactory(), 80.0f));
            units.AddUnit(new UnitFactory(new InfantryFactory(), 90.0f));

            units.RemoveUnit(unitInf);
            units.RemoveUnit(unitM);
            units.RemoveUnit(unitInfantry);
            units.RemoveUnit(unitMag);

            var loadUnits = saveDataRepository.Load();

            units.AddManyUnits(loadUnits.ToArray());
            
            units.GetUnit();
        }
    }
}
