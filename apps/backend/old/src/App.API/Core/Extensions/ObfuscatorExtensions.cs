using FwksLabs.Libs.Core.Entities;
using FwksLabs.Libs.Core.Security.Extensions;

namespace FwksLabs.AppService.Core.Extensions;

public static class ObfuscatorExtensions
{
    public static string EncodeId<TEntity>(this TEntity entity) where TEntity : Entity<int> =>
        entity.Id.Encode<TEntity>();
}
