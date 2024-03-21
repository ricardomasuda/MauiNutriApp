using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace MauiLib1.ApiClient.PushNotification;

public class DeviceTokenApi
{
    private readonly HttpClient _httpClient;

    public DeviceTokenApi()
    {
        _httpClient = new HttpClient();
        var httpClientHandler = new HttpClientHandler();
        httpClientHandler.ServerCertificateCustomValidationCallback = 
            (message, cert, chain, errors) => { return true; };

        _httpClient = new HttpClient(httpClientHandler);
        //SetHeaders();
    }
    
    public async Task<bool> SetNotificationToken(string userId, string username, string tokenPushNotification, string authorization)
    {
        SetHeaders(authorization);
        
        var data = new
        {
            userId,
            userName = username,
            product = ApiParameter.Product,
            device = ApiParameter.Product,
            token = tokenPushNotification
        };
        
        string jsonData = JsonConvert.SerializeObject(data);
        HttpContent jsonContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(ApiParameter.UrlLocal, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<dynamic>(responseJson);
            var notifications = responseObj.notifications;
            foreach (var notification in notifications)
            {
                if (notification == "O token informado já existe na base de dados.")
                {
                    return true;
                }
            }
            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private void SetHeaders(string authorization)
    {
        _httpClient.DefaultRequestHeaders.Remove("X-Tenant");
        _httpClient.DefaultRequestHeaders.Add("X-Tenant", ApiParameter.TenantEnganharia);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
    }
}