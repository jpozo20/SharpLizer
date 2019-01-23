using Newtonsoft.Json;
using SharpLizer.Configuration.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

namespace SharpLizer.Configuration.Json
{
    [Export]
    internal class SettingsLoader
    {
        private const string _settingsFolderName = "SharpLizer";
        private const string _settingsFileName = _settingsFolderName + ".settings";

        internal void SaveSettings(ApplicationSettings settings)
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

        internal ApplicationSettings LoadSettings()
        {
            var settings = new ApplicationSettings();
            try
            {
                string path = GetSettingsLocationPath();
                string json = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    settings = JsonConvert.DeserializeObject<ApplicationSettings>(json);
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