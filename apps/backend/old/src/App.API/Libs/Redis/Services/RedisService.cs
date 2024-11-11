using System.Text.Json;
using FwksLabs.Libs.Core.Abstractions.Services;
using FwksLabs.Libs.Core.Extensions;
using StackExchange.Redis;

namespace FwksLabs.Libs.Infra.Redis.Services;

public sealed class RedisService(
    Lazy<IConnectionMultiplexer> connection,
    IDatabase database) : IRedisService
{
    private readonly ISubscriber _subscriber = connection.Value.GetSubscriber();

    public async Task<string> GetAsync(string key, bool fireAndForget = false) => (await database.StringGetAsync(key, Flag(fireAndForget))).ToString();

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> fallback, bool fireAndForget = false, Action<JsonSerializerOptions>? serializerOptions = null)
    {
        var value = await database.StringGetAsync(key, Flag(fireAndForget));

        if (value.HasValue)
            return value.ToString().Deserialize<T>(serializerOptions);

        return await fallback();
    }

    public Task SetAsync(string key, string value, TimeSpan? expiry = default, bool keepTtl = false, bool overwrite = true, bool fireAndForget = false) =>
        database.StringSetAsync(key, value, expiry, keepTtl, Overwrite(overwrite), Flag(fireAndForget));

    public Task SetAsync<T>(string key, string value, TimeSpan? expiry = default, bool keepTtl = false, bool overwrite = true, bool fireAndForget = false, Action<JsonSerializerOptions>? serializerOptions = null)
    {
        var serialized = value!.Serialize(serializerOptions);

        return SetAsync(key, serialized, expiry, keepTtl, overwrite, fireAndForget);
    }

    public Task SubscribeAsync(string channel, Action<string, string> action, bool fireAndForget = false)
    {
        var redisChannel = GetChannel(channel);

        return _subscriber.SubscribeAsync(redisChannel, (_, value) => action(channel, value.ToString()), Flag(fireAndForget));
    }

    public Task PublishAsync(string channel, object content, bool fireAndForget = false, Action<JsonSerializerOptions>? serializerOptions = null)
    {
        var redisChannel = GetChannel(channel);

        return _subscriber.PublishAsync(redisChannel, content.Serialize(serializerOptions), Flag(fireAndForget));
    }

    private static CommandFlags Flag(bool fireAndForget) => fireAndForget ? CommandFlags.FireAndForget : CommandFlags.None;
    private static When Overwrite(bool overwrite) => overwrite ? When.Always : When.NotExists;
    private static RedisChannel GetChannel(string channel) => new(channel, RedisChannel.PatternMode.Auto);

}

