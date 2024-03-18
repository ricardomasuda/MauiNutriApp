using MauiLib1.User;

namespace MauiLib1.Service.Config;

public interface IConfigPreference
{
    ConfigModel GetConfiguration();
    void SaveConfiguration(ConfigModel configurationPreferenceInfo);
    void ClearConfiguration();
}