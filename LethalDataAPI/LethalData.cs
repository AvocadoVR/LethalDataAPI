using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LethalDataAPI
{
    public class LethalData
    {
        private static string dir = "";

        public LethalData(string modName)
        {
            string _dir = dir;

            dir = Path.Combine(_dir, modName);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public static void Save<T>(string key, T value)
        {
            string currentSave = Plugin.currentSave;
            if (string.IsNullOrEmpty(currentSave)) return;
            string _dir = Path.Combine(dir, currentSave + ".json");

            Dictionary<string, object> currentData;

            if (File.Exists(_dir))
            {
                string jsonContent = File.ReadAllText(_dir);
                currentData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
            }
            else
            {
                currentData = new Dictionary<string, object>();
                using (FileStream fs = File.Create(_dir)) { }
            }

            currentData[key] = value;

            string jsonData = JsonConvert.SerializeObject(currentData, Formatting.Indented);
            File.WriteAllText(_dir, jsonData);
        }

        public static T? Load<T>(string key)
        {
            string currentSave = Plugin.currentSave;
            string _dir = Path.Combine(dir, currentSave + ".json");

            Dictionary<string, object> currentData = new Dictionary<string, object>();

            if (File.Exists(_dir))
            {
                string jsonContent = File.ReadAllText(_dir);
                currentData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
            }
            else
            {
                using (FileStream fs = File.Create(_dir)) { };
            }

            if (currentData.TryGetValue(key, out var value))
            {
                return (T?)value;
            }

            return default(T);
        }
    }
}