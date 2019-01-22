using Newtonsoft.Json;
using SharpLizer.Configuration.Settings;
using System;
using System.Collections.Generic;
using System.IO;

namespace SharpLizer.Configuration.Json
{
    internal class SettingsLoader
    {
        private const string _settingsFolderName = "SharpLizer";
        private const string _settingsFileName = _settingsFolderName + "Colors.settings";

        internal void SaveSettings(IEnumerable<CategorySettings> settings)
        {
            string json = JsonConvert.SerializeObject(settings);
            string path = GetSettingsLocationPath();
            try
            {
                File.WriteAllText(path, json);
            }
            catch (Exception)
            {
                // TO-DO: Log exceptions
            }
        }

        internal IList<CategorySettings> LoadSettings()
        {
            List<CategorySettings> settings = new List<CategorySettings>();
            try
            {
                string path = GetSettingsLocationPath();
                string json = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    IEnumerable<CategorySettings> loadedSettings = JsonConvert.DeserializeObject<IEnumerable<CategorySettings>>(json);
                    settings.AddRange(loadedSettings);
                }
            }
            catch (Exception)
            {
                // TODO: Log exception
            }
            return settings;
        }

        private string GetSettingsLocationPath()
        {
            string applicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string settingsPath = Path.Combine(applicationDataFolder, _settingsFolderName);
            if (!Directory.Exists(settingsPath)) Directory.CreateDirectory(settingsPath);
            return Path.Combine(settingsPath, _settingsFileName);
        }
    }
}