using FwksLabs.Libs.Core.Outputs;

namespace FwksLabs.Libs.Core.Extensions;

public static class PagingExtensions
{
    public static PageOutput<T> ToPagedOutput<T>(
        this IEnumerable<T> source, int pageNumber = 1, int pageSize = -1) => PageOutput<T>.Create(source, pageNumber, pageSize);
}