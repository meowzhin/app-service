using FwksLabs.Libs.Core.Extensions;
using FwksLabs.Libs.Core.Types;

namespace FwksLabs.ResumeService.Core.Extensions;

public static class ObfuscatorExtensions
{
    public static string EncodeId<TEntity>(this TEntity entity) where TEntity : Entity<int> =>
        entity.Id.Encode<TEntity>();
}
