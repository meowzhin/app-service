using FwksLab.Libs.AspNetCore.Transformers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace FwksLab.Libs.AspNetCore.Conventions;

public sealed class SlugCaseRouteTransformerConvention : IActionModelConvention
{
    public void Apply(ActionModel action) => action.RouteParameterTransformer = new SlugCaseParameterTransformer();
}
