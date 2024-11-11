using Microsoft.AspNetCore.Routing;
using FwksLabs.Libs.Core.Extensions;

namespace FwksLabs.Libs.AspNetCore.Transformers;

public sealed class SlugCaseParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value) => value!.ToString()!.ToSlugCase();
}
