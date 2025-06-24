namespace MathProject.Client.Client.Interfaces;

public interface IUserSettingsService
{
    Task<T?> GetSettingAsync<T>(string key);
    Task SetSettingAsync<T>(string key, T value);
}