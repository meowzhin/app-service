using Microsoft.AspNetCore.Mvc;

namespace FwksLab.AppService.App.Api.Controllers.Common;

[ApiController]
[Route("v{v:apiVersion}/[controller]")]
public abstract class V1Controller : ControllerBase;