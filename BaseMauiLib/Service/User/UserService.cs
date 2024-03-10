using System.Text.Json;
using MauiLib1.User;

namespace MauiLib1.Service.User;

public class UserService : IUserService
{
    private const string UserInfoKey = "UserInfo";

    public UserPreferenceUserInfo GetUserInfo()
    {
        var userInfoJson = Preferences.Get(UserInfoKey, string.Empty);
        if (!string.IsNullOrEmpty(userInfoJson))
        {
            UserPreferenceUserInfo? user = JsonSerializer.Deserialize<UserPreferenceUserInfo>(userInfoJson);
            if (user == null) return null;
            user.Password = CryptoHelper.DecryptString(user.Password);
            return user;
        }
        return null;
    }

    public void SaveUserInfo(UserPreferenceUserInfo userPreferenceUserInfo)
    {
        userPreferenceUserInfo.Password = CryptoHelper.EncryptString(userPreferenceUserInfo.Password);
        string userInfoJson = JsonSerializer.Serialize(userPreferenceUserInfo);
        Preferences.Set(UserInfoKey, userInfoJson);
    }

    public void ClearUserInfo()
    {
        Preferences.Remove(UserInfoKey);
    }
}