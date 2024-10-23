using Humanizer;
using Microsoft.AspNetCore.Routing;

namespace FwksLabs.Libs.AspNetCore.Transformers;

public sealed class SlugCaseParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value) => value!.ToString()!.Kebaberize();
}
