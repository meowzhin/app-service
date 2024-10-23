using System.Text.Json;

namespace FwksLabs.Libs.Core.Abstractions.Services;

public interface IRedisService
{
    Task<string> GetAsync(string key, bool fireAndForget = false);
    Task<T> GetAsync<T>(string key, Func<Task<T>> fallback, bool fireAndForget = false, Action<JsonSerializerOptions>? serializerOptions = null);
    Task PublishAsync(string channel, object content, bool fireAndForget = false, Action<JsonSerializerOptions>? serializerOptions = null);
    Task SetAsync(string key, string value, TimeSpan? expiry = null, bool keepTtl = false, bool overwrite = true, bool fireAndForget = false);
    Task SetAsync<T>(string key, string value, TimeSpan? expiry = null, bool keepTtl = false, bool overwrite = true, bool fireAndForget = false, Action<JsonSerializerOptions>? serializerOptions = null);
    Task SubscribeAsync(string channel, Action<string, string> action, bool fireAndForget = false);
}
