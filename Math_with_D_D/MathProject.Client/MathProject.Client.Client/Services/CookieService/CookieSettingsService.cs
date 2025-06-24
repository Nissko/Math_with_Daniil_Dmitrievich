using System.Text.Json;
using MathProject.Client.Client.Interfaces;
using Microsoft.JSInterop;

namespace MathProject.Client.Client.Services.CookieService;

public class CookieSettingsService : IUserSettingsService
{
    private readonly IJSRuntime _jsRuntime;

    public CookieSettingsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime ??  throw new ArgumentNullException(nameof(jsRuntime));
    }
    
    public async Task<T?> GetSettingAsync<T>(string key)
    {
        var json = await _jsRuntime.InvokeAsync<string>("eval", $"Cookies.get('{key}')");
        if (string.IsNullOrEmpty(json))
            return default;

        try
        {
            return JsonSerializer.Deserialize<T>(json);
        }
        catch
        {
            return default;
        }
    }

    public async Task SetSettingAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        await _jsRuntime.InvokeVoidAsync("eval", $"Cookies.set('{key}', `{json}`)");
    }
}