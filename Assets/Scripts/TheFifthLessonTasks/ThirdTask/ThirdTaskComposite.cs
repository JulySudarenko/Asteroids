using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public class ThirdTaskComposite : MonoBehaviour
    {
        private UnitComposite _units;
        private SaveDataRepository _saveDataRepository;
        private SavedData _savedData;

        public void Start()
        {
            _saveDataRepository = new SaveDataRepository();
            _units = new UnitComposite();

            IFactory infantry = new InfantryFactory();
            IFactory mag = new MagFactory();
            
            IUnit unitInf = new UnitFactory(infantry, 97.0f);
            IUnit unitM = new UnitFactory(mag, 95.0f);
            
            UnitFactory unitInfantry = new UnitFactory(infantry, 100.0f);
            UnitFactory unitMag = new UnitFactory(mag, 50.0f);
            
            _units.AddUnit(unitInf);
            _units.AddUnit(unitM);
            
            _units.AddUnit(unitInfantry);
            _units.AddUnit(unitMag);
            
            _units.AddUnit(new UnitFactory(new MagFactory(), 80.0f));
            _units.AddUnit(new UnitFactory(new InfantryFactory(), 90.0f));

            _units.RemoveUnit(unitInf);
            _units.RemoveUnit(unitM);
            _units.RemoveUnit(unitInfantry);
            _units.RemoveUnit(unitMag);

            var loadUnits = _saveDataRepository.Load();

            _units.AddManyUnits(loadUnits.ToArray());
            
            // var unitData = DeserializeUnitsData();
            // Debug.Log(unitData.ToString());
            // _units.AddUnit(new UnitFactory(new MagFactory(), unitData.health));
            //
            // var savedData = DeserializeSavedData();
            // savedData.Print();
            // _units.AddUnit(new UnitFactory(new MagFactory(), savedData.unit.health));
            //
            // var saveDatas = Deserialize();
            // for (var i = 0; i < saveDatas.Length; i++)
            // {
            //     saveDatas[i].Print();
            // }

            _units.GetUnit();
        }

        private UnitsData DeserializeUnitsData()
        {
            string jsonString = "{ \"type\": \"mag\", \"health\": \"100\" }";
            Debug.Log(jsonString);
            return JsonUtility.FromJson<UnitsData>(jsonString);
        }

        private SavedData DeserializeSavedData()
        {
            string jsonString = "{ \"unit\": { \"type\": \"mag\", \"health\": \"100\" }}";
            Debug.Log(jsonString);
            return JsonUtility.FromJson<SavedData>(jsonString);
        }

        private SavedData[] Deserialize()
        {
            string jsonString =
                "[{ \"unit\": { \"type\": \"mag\", \"health\": \"100\" }}, " +
                "{ \"unit\": { \"type\": \"infantry\", \"health\": \"150\" }}, " +
                "{ \"unit\": {\"type\": \"mag\", \"health\": \"50\" } } ]";
            string newJsonString = FixJson(jsonString);
            Debug.Log(jsonString);
            Debug.Log(newJsonString);

            return JsonHelper.FromJson<SavedData>(newJsonString);
        }
        
        private string FixJson(string value) 
        {
            value = "{\"Units\":" + value + "}";
            return value;
        }
    }
}
