using System.Text.Json;
using MauiLib1.User;

namespace MauiLib1.Service.Config;

public class ConfigPreference : IConfigPreference
{
    private const string ConfigurationInfoKey = "ConfigModel";

    public ConfigModel GetConfiguration()
    {
        var configurationJson = Preferences.Get(ConfigurationInfoKey, string.Empty);
        if (!string.IsNullOrEmpty(configurationJson))
        {
            ConfigModel? Configuration = JsonSerializer.Deserialize<ConfigModel>(configurationJson);
            if (Configuration == null) return null;
            return Configuration;
        }
        return null;
    }

    public void SaveConfiguration(ConfigModel configurationPreferenceInfo)
    {
        string configurationInfoJson = JsonSerializer.Serialize(configurationPreferenceInfo);
        Preferences.Set(ConfigurationInfoKey, configurationInfoJson);
    }

    public void ClearConfiguration()
    {
        Preferences.Remove(ConfigurationInfoKey);
    }
}