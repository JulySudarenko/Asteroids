using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public List<UnitFactory> Load()
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new ArgumentException("File not found");
            }

            List<UnitFactory> units = new List<UnitFactory>();

            var loadGame = _data.Load(file);
            foreach (var str in loadGame)
            {
                switch (str.unit.type)
                {
                    case "mag":
                        units.Add(new UnitFactory(new MagFactory(), str.unit.health));
                        break;
                    case "infantry":
                        units.Add(new UnitFactory(new InfantryFactory(), str.unit.health));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(str.unit), str.unit.type,
                            "Unidentified object detected");
                }
            }

            return units;
        }
    }
}
