using MauiLib1.User;

namespace MauiLib1.Service.User;

public interface IUserService
{
    UserPreferenceUserInfo? GetUserInfo();
    void SaveUserInfo(UserPreferenceUserInfo userPreferenceUserInfo);
    void ClearUserInfo();
}