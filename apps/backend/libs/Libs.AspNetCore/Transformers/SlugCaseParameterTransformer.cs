using Microsoft.AspNetCore.Routing;
using FwksLab.Libs.Core.Extensions;

namespace FwksLab.Libs.AspNetCore.Transformers;

public sealed class SlugCaseParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value) => value!.ToString()!.ToSlugCase();
}
