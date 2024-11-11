using FwksLabs.Libs.AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.Libs.AspNetCore.Attributes;

public sealed class AppProblemResponseAttribute(int statusCode) : ProducesResponseTypeAttribute(typeof(AppProblem), statusCode);